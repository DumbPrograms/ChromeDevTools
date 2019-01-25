using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools.Protocol
{

    /// <summary>
    /// This domain is deprecated - use Runtime or Log instead.
    /// </summary>
    namespace Console
    {

        /// <summary>
        /// Console message.
        /// </summary>
        public class ConsoleMessage
        {

            /// <summary>
            /// Message source.
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// Message severity.
            /// </summary>
            [JsonProperty("level")]
            public string Level { get; set; }

            /// <summary>
            /// Message text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// URL of the message origin.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Line number in the resource that generated this message (1-based).
            /// </summary>
            [JsonProperty("line")]
            public int Line { get; set; }

            /// <summary>
            /// Column number in the resource that generated this message (1-based).
            /// </summary>
            [JsonProperty("column")]
            public int Column { get; set; }
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        public class ClearMessagesCommand : ICommand
        {
            string ICommand.Name { get; } = "Console.clearMessages";
        }

        /// <summary>
        /// Disables console domain, prevents further console messages from being reported to the client.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Console.disable";
        }

        /// <summary>
        /// Enables console domain, sends the messages collected so far to the client by means of the
        /// `messageAdded` notification.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Console.enable";
        }
    }

    /// <summary>
    /// Debugger domain exposes JavaScript debugging capabilities. It allows setting and removing
    /// breakpoints, stepping through execution, exploring stack traces, etc.
    /// </summary>
    namespace Debugger
    {

        /// <summary>
        /// Breakpoint identifier.
        /// </summary>
        public struct BreakpointId : IAlias<string>
        {
            public string Value { get; private set; }

            public BreakpointId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Call frame identifier.
        /// </summary>
        public struct CallFrameId : IAlias<string>
        {
            public string Value { get; private set; }

            public CallFrameId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Location in the source code.
        /// </summary>
        public class Location
        {

            /// <summary>
            /// Script identifier as reported in the `Debugger.scriptParsed`.
            /// </summary>
            [JsonProperty("scriptId")]
            public Runtime.ScriptId ScriptId { get; set; }

            /// <summary>
            /// Line number in the script (0-based).
            /// </summary>
            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            /// <summary>
            /// Column number in the script (0-based).
            /// </summary>
            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }
        }

        /// <summary>
        /// Location in the source code.
        /// </summary>
        public class ScriptPosition
        {

            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }
        }

        /// <summary>
        /// JavaScript call frame. Array of call frames form the call stack.
        /// </summary>
        public class CallFrame
        {

            /// <summary>
            /// Call frame identifier. This identifier is only valid while the virtual machine is paused.
            /// </summary>
            [JsonProperty("callFrameId")]
            public CallFrameId CallFrameId { get; set; }

            /// <summary>
            /// Name of the JavaScript function called on this call frame.
            /// </summary>
            [JsonProperty("functionName")]
            public string FunctionName { get; set; }

            /// <summary>
            /// Location in the source code.
            /// </summary>
            [JsonProperty("functionLocation")]
            public Location FunctionLocation { get; set; }

            /// <summary>
            /// Location in the source code.
            /// </summary>
            [JsonProperty("location")]
            public Location Location { get; set; }

            /// <summary>
            /// JavaScript script name or url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Scope chain for this call frame.
            /// </summary>
            [JsonProperty("scopeChain")]
            public Scope[] ScopeChain { get; set; }

            /// <summary>
            /// `this` object for this call frame.
            /// </summary>
            [JsonProperty("this")]
            public Runtime.RemoteObject This { get; set; }

            /// <summary>
            /// The value being returned, if the function is at return point.
            /// </summary>
            [JsonProperty("returnValue")]
            public Runtime.RemoteObject ReturnValue { get; set; }
        }

        /// <summary>
        /// Scope description.
        /// </summary>
        public class Scope
        {

            /// <summary>
            /// Scope type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Object representing the scope. For `global` and `with` scopes it represents the actual
            /// object; for the rest of the scopes, it is artificial transient object enumerating scope
            /// variables as its properties.
            /// </summary>
            [JsonProperty("object")]
            public Runtime.RemoteObject Object { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Location in the source code where scope starts
            /// </summary>
            [JsonProperty("startLocation")]
            public Location StartLocation { get; set; }

            /// <summary>
            /// Location in the source code where scope ends
            /// </summary>
            [JsonProperty("endLocation")]
            public Location EndLocation { get; set; }
        }

        /// <summary>
        /// Search match for resource.
        /// </summary>
        public class SearchMatch
        {

            /// <summary>
            /// Line number in resource content.
            /// </summary>
            [JsonProperty("lineNumber")]
            public double LineNumber { get; set; }

            /// <summary>
            /// Line with match content.
            /// </summary>
            [JsonProperty("lineContent")]
            public string LineContent { get; set; }
        }

        public class BreakLocation
        {

            /// <summary>
            /// Script identifier as reported in the `Debugger.scriptParsed`.
            /// </summary>
            [JsonProperty("scriptId")]
            public Runtime.ScriptId ScriptId { get; set; }

            /// <summary>
            /// Line number in the script (0-based).
            /// </summary>
            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            /// <summary>
            /// Column number in the script (0-based).
            /// </summary>
            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        /// <summary>
        /// Continues execution until specific location is reached.
        /// </summary>
        public class ContinueToLocationCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.continueToLocation";
        }

        /// <summary>
        /// Disables debugger for given page.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.disable";
        }

        /// <summary>
        /// Enables debugger for the given page. Clients should not assume that the debugging has been
        /// enabled until the result for this command is received.
        /// </summary>
        public class EnableCommand : ICommand<EnableResponse>
        {
            string ICommand.Name { get; } = "Debugger.enable";
        }

        public class EnableResponse
        {
        }

        /// <summary>
        /// Evaluates expression on a given call frame.
        /// </summary>
        public class EvaluateOnCallFrameCommand : ICommand<EvaluateOnCallFrameResponse>
        {
            string ICommand.Name { get; } = "Debugger.evaluateOnCallFrame";
        }

        public class EvaluateOnCallFrameResponse
        {
        }

        /// <summary>
        /// Returns possible locations for breakpoint. scriptId in start and end range locations should be
        /// the same.
        /// </summary>
        public class GetPossibleBreakpointsCommand : ICommand<GetPossibleBreakpointsResponse>
        {
            string ICommand.Name { get; } = "Debugger.getPossibleBreakpoints";
        }

        public class GetPossibleBreakpointsResponse
        {
        }

        /// <summary>
        /// Returns source for the script with given id.
        /// </summary>
        public class GetScriptSourceCommand : ICommand<GetScriptSourceResponse>
        {
            string ICommand.Name { get; } = "Debugger.getScriptSource";
        }

        public class GetScriptSourceResponse
        {
        }

        /// <summary>
        /// Returns stack trace with given `stackTraceId`.
        /// </summary>
        public class GetStackTraceCommand : ICommand<GetStackTraceResponse>
        {
            string ICommand.Name { get; } = "Debugger.getStackTrace";
        }

        public class GetStackTraceResponse
        {
        }

        /// <summary>
        /// Stops on the next JavaScript statement.
        /// </summary>
        public class PauseCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.pause";
        }

        public class PauseOnAsyncCallCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.pauseOnAsyncCall";
        }

        /// <summary>
        /// Removes JavaScript breakpoint.
        /// </summary>
        public class RemoveBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.removeBreakpoint";
        }

        /// <summary>
        /// Restarts particular call frame from the beginning.
        /// </summary>
        public class RestartFrameCommand : ICommand<RestartFrameResponse>
        {
            string ICommand.Name { get; } = "Debugger.restartFrame";
        }

        public class RestartFrameResponse
        {
        }

        /// <summary>
        /// Resumes JavaScript execution.
        /// </summary>
        public class ResumeCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.resume";
        }

        /// <summary>
        /// Searches for given string in script content.
        /// </summary>
        public class SearchInContentCommand : ICommand<SearchInContentResponse>
        {
            string ICommand.Name { get; } = "Debugger.searchInContent";
        }

        public class SearchInContentResponse
        {
        }

        /// <summary>
        /// Enables or disables async call stacks tracking.
        /// </summary>
        public class SetAsyncCallStackDepthCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setAsyncCallStackDepth";
        }

        /// <summary>
        /// Replace previous blackbox patterns with passed ones. Forces backend to skip stepping/pausing in
        /// scripts with url matching one of the patterns. VM will try to leave blackboxed script by
        /// performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
        /// </summary>
        public class SetBlackboxPatternsCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setBlackboxPatterns";
        }

        /// <summary>
        /// Makes backend skip steps in the script in blackboxed ranges. VM will try leave blacklisted
        /// scripts by performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
        /// Positions array contains positions where blackbox state is changed. First interval isn't
        /// blackboxed. Array should be sorted.
        /// </summary>
        public class SetBlackboxedRangesCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setBlackboxedRanges";
        }

        /// <summary>
        /// Sets JavaScript breakpoint at a given location.
        /// </summary>
        public class SetBreakpointCommand : ICommand<SetBreakpointResponse>
        {
            string ICommand.Name { get; } = "Debugger.setBreakpoint";
        }

        public class SetBreakpointResponse
        {
        }

        /// <summary>
        /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
        /// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
        /// `locations` property. Further matching script parsing will result in subsequent
        /// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
        /// </summary>
        public class SetBreakpointByUrlCommand : ICommand<SetBreakpointByUrlResponse>
        {
            string ICommand.Name { get; } = "Debugger.setBreakpointByUrl";
        }

        public class SetBreakpointByUrlResponse
        {
        }

        /// <summary>
        /// Sets JavaScript breakpoint before each call to the given function.
        /// If another function was created from the same source as a given one,
        /// calling it will also trigger the breakpoint.
        /// </summary>
        public class SetBreakpointOnFunctionCallCommand : ICommand<SetBreakpointOnFunctionCallResponse>
        {
            string ICommand.Name { get; } = "Debugger.setBreakpointOnFunctionCall";
        }

        public class SetBreakpointOnFunctionCallResponse
        {
        }

        /// <summary>
        /// Activates / deactivates all breakpoints on the page.
        /// </summary>
        public class SetBreakpointsActiveCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setBreakpointsActive";
        }

        /// <summary>
        /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or
        /// no exceptions. Initial pause on exceptions state is `none`.
        /// </summary>
        public class SetPauseOnExceptionsCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setPauseOnExceptions";
        }

        /// <summary>
        /// Changes return value in top frame. Available only at return break position.
        /// </summary>
        public class SetReturnValueCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setReturnValue";
        }

        /// <summary>
        /// Edits JavaScript source live.
        /// </summary>
        public class SetScriptSourceCommand : ICommand<SetScriptSourceResponse>
        {
            string ICommand.Name { get; } = "Debugger.setScriptSource";
        }

        public class SetScriptSourceResponse
        {
        }

        /// <summary>
        /// Makes page not interrupt on any pauses (breakpoint, exception, dom exception etc).
        /// </summary>
        public class SetSkipAllPausesCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setSkipAllPauses";
        }

        /// <summary>
        /// Changes value of variable in a callframe. Object-based scopes are not supported and must be
        /// mutated manually.
        /// </summary>
        public class SetVariableValueCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.setVariableValue";
        }

        /// <summary>
        /// Steps into the function call.
        /// </summary>
        public class StepIntoCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.stepInto";
        }

        /// <summary>
        /// Steps out of the function call.
        /// </summary>
        public class StepOutCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.stepOut";
        }

        /// <summary>
        /// Steps over the statement.
        /// </summary>
        public class StepOverCommand : ICommand
        {
            string ICommand.Name { get; } = "Debugger.stepOver";
        }
    }

    namespace HeapProfiler
    {

        /// <summary>
        /// Heap snapshot object id.
        /// </summary>
        public struct HeapSnapshotObjectId : IAlias<string>
        {
            public string Value { get; private set; }

            public HeapSnapshotObjectId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Sampling Heap Profile node. Holds callsite information, allocation statistics and child nodes.
        /// </summary>
        public class SamplingHeapProfileNode
        {

            /// <summary>
            /// Function location.
            /// </summary>
            [JsonProperty("callFrame")]
            public Runtime.CallFrame CallFrame { get; set; }

            /// <summary>
            /// Allocations size in bytes for the node excluding children.
            /// </summary>
            [JsonProperty("selfSize")]
            public double SelfSize { get; set; }

            /// <summary>
            /// Node id. Ids are unique across all profiles collected between startSampling and stopSampling.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Child nodes.
            /// </summary>
            [JsonProperty("children")]
            public SamplingHeapProfileNode[] Children { get; set; }
        }

        /// <summary>
        /// A single sample from a sampling profile.
        /// </summary>
        public class SamplingHeapProfileSample
        {

            /// <summary>
            /// Allocation size in bytes attributed to the sample.
            /// </summary>
            [JsonProperty("size")]
            public double Size { get; set; }

            /// <summary>
            /// Id of the corresponding profile tree node.
            /// </summary>
            [JsonProperty("nodeId")]
            public int NodeId { get; set; }

            /// <summary>
            /// Time-ordered sample ordinal number. It is unique across all profiles retrieved
            /// between startSampling and stopSampling.
            /// </summary>
            [JsonProperty("ordinal")]
            public double Ordinal { get; set; }
        }

        /// <summary>
        /// Sampling profile.
        /// </summary>
        public class SamplingHeapProfile
        {

            [JsonProperty("head")]
            public SamplingHeapProfileNode Head { get; set; }

            [JsonProperty("samples")]
            public SamplingHeapProfileSample[] Samples { get; set; }
        }

        /// <summary>
        /// Enables console to refer to the node with given id via $x (see Command Line API for more details
        /// $x functions).
        /// </summary>
        public class AddInspectedHeapObjectCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.addInspectedHeapObject";
        }

        public class CollectGarbageCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.collectGarbage";
        }

        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.disable";
        }

        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.enable";
        }

        public class GetHeapObjectIdCommand : ICommand<GetHeapObjectIdResponse>
        {
            string ICommand.Name { get; } = "HeapProfiler.getHeapObjectId";
        }

        public class GetHeapObjectIdResponse
        {
        }

        public class GetObjectByHeapObjectIdCommand : ICommand<GetObjectByHeapObjectIdResponse>
        {
            string ICommand.Name { get; } = "HeapProfiler.getObjectByHeapObjectId";
        }

        public class GetObjectByHeapObjectIdResponse
        {
        }

        public class GetSamplingProfileCommand : ICommand<GetSamplingProfileResponse>
        {
            string ICommand.Name { get; } = "HeapProfiler.getSamplingProfile";
        }

        public class GetSamplingProfileResponse
        {
        }

        public class StartSamplingCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.startSampling";
        }

        public class StartTrackingHeapObjectsCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.startTrackingHeapObjects";
        }

        public class StopSamplingCommand : ICommand<StopSamplingResponse>
        {
            string ICommand.Name { get; } = "HeapProfiler.stopSampling";
        }

        public class StopSamplingResponse
        {
        }

        public class StopTrackingHeapObjectsCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.stopTrackingHeapObjects";
        }

        public class TakeHeapSnapshotCommand : ICommand
        {
            string ICommand.Name { get; } = "HeapProfiler.takeHeapSnapshot";
        }
    }

    namespace Profiler
    {

        /// <summary>
        /// Profile node. Holds callsite information, execution statistics and child nodes.
        /// </summary>
        public class ProfileNode
        {

            /// <summary>
            /// Unique id of the node.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Function location.
            /// </summary>
            [JsonProperty("callFrame")]
            public Runtime.CallFrame CallFrame { get; set; }

            /// <summary>
            /// Number of samples where this node was on top of the call stack.
            /// </summary>
            [JsonProperty("hitCount")]
            public int HitCount { get; set; }

            /// <summary>
            /// Child node ids.
            /// </summary>
            [JsonProperty("children")]
            public int[] Children { get; set; }

            /// <summary>
            /// The reason of being not optimized. The function may be deoptimized or marked as don't
            /// optimize.
            /// </summary>
            [JsonProperty("deoptReason")]
            public string DeoptReason { get; set; }

            /// <summary>
            /// An array of source position ticks.
            /// </summary>
            [JsonProperty("positionTicks")]
            public PositionTickInfo[] PositionTicks { get; set; }
        }

        /// <summary>
        /// Profile.
        /// </summary>
        public class Profile
        {

            /// <summary>
            /// The list of profile nodes. First item is the root node.
            /// </summary>
            [JsonProperty("nodes")]
            public ProfileNode[] Nodes { get; set; }

            /// <summary>
            /// Profiling start timestamp in microseconds.
            /// </summary>
            [JsonProperty("startTime")]
            public double StartTime { get; set; }

            /// <summary>
            /// Profiling end timestamp in microseconds.
            /// </summary>
            [JsonProperty("endTime")]
            public double EndTime { get; set; }

            /// <summary>
            /// Ids of samples top nodes.
            /// </summary>
            [JsonProperty("samples")]
            public int[] Samples { get; set; }

            /// <summary>
            /// Time intervals between adjacent samples in microseconds. The first delta is relative to the
            /// profile startTime.
            /// </summary>
            [JsonProperty("timeDeltas")]
            public int[] TimeDeltas { get; set; }
        }

        /// <summary>
        /// Specifies a number of samples attributed to a certain source position.
        /// </summary>
        public class PositionTickInfo
        {

            /// <summary>
            /// Source line number (1-based).
            /// </summary>
            [JsonProperty("line")]
            public int Line { get; set; }

            /// <summary>
            /// Number of samples attributed to the source line.
            /// </summary>
            [JsonProperty("ticks")]
            public int Ticks { get; set; }
        }

        /// <summary>
        /// Coverage data for a source range.
        /// </summary>
        public class CoverageRange
        {

            /// <summary>
            /// JavaScript script source offset for the range start.
            /// </summary>
            [JsonProperty("startOffset")]
            public int StartOffset { get; set; }

            /// <summary>
            /// JavaScript script source offset for the range end.
            /// </summary>
            [JsonProperty("endOffset")]
            public int EndOffset { get; set; }

            /// <summary>
            /// Collected execution count of the source range.
            /// </summary>
            [JsonProperty("count")]
            public int Count { get; set; }
        }

        /// <summary>
        /// Coverage data for a JavaScript function.
        /// </summary>
        public class FunctionCoverage
        {

            /// <summary>
            /// JavaScript function name.
            /// </summary>
            [JsonProperty("functionName")]
            public string FunctionName { get; set; }

            /// <summary>
            /// Source ranges inside the function with coverage data.
            /// </summary>
            [JsonProperty("ranges")]
            public CoverageRange[] Ranges { get; set; }

            /// <summary>
            /// Whether coverage data for this function has block granularity.
            /// </summary>
            [JsonProperty("isBlockCoverage")]
            public bool IsBlockCoverage { get; set; }
        }

        /// <summary>
        /// Coverage data for a JavaScript script.
        /// </summary>
        public class ScriptCoverage
        {

            /// <summary>
            /// JavaScript script id.
            /// </summary>
            [JsonProperty("scriptId")]
            public Runtime.ScriptId ScriptId { get; set; }

            /// <summary>
            /// JavaScript script name or url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Functions contained in the script that has coverage data.
            /// </summary>
            [JsonProperty("functions")]
            public FunctionCoverage[] Functions { get; set; }
        }

        /// <summary>
        /// Describes a type collected during runtime.
        /// </summary>
        public class TypeObject
        {

            /// <summary>
            /// Name of a type collected with type profiling.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        /// <summary>
        /// Source offset and types for a parameter or return value.
        /// </summary>
        public class TypeProfileEntry
        {

            /// <summary>
            /// Source offset of the parameter or end of function for return values.
            /// </summary>
            [JsonProperty("offset")]
            public int Offset { get; set; }

            /// <summary>
            /// The types for this parameter or return value.
            /// </summary>
            [JsonProperty("types")]
            public TypeObject[] Types { get; set; }
        }

        /// <summary>
        /// Type profile data collected during runtime for a JavaScript script.
        /// </summary>
        public class ScriptTypeProfile
        {

            /// <summary>
            /// JavaScript script id.
            /// </summary>
            [JsonProperty("scriptId")]
            public Runtime.ScriptId ScriptId { get; set; }

            /// <summary>
            /// JavaScript script name or url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Type profile entries for parameters and return values of the functions in the script.
            /// </summary>
            [JsonProperty("entries")]
            public TypeProfileEntry[] Entries { get; set; }
        }

        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.disable";
        }

        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.enable";
        }

        /// <summary>
        /// Collect coverage data for the current isolate. The coverage data may be incomplete due to
        /// garbage collection.
        /// </summary>
        public class GetBestEffortCoverageCommand : ICommand<GetBestEffortCoverageResponse>
        {
            string ICommand.Name { get; } = "Profiler.getBestEffortCoverage";
        }

        public class GetBestEffortCoverageResponse
        {
        }

        /// <summary>
        /// Changes CPU profiler sampling interval. Must be called before CPU profiles recording started.
        /// </summary>
        public class SetSamplingIntervalCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.setSamplingInterval";
        }

        public class StartCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.start";
        }

        /// <summary>
        /// Enable precise code coverage. Coverage data for JavaScript executed before enabling precise code
        /// coverage may be incomplete. Enabling prevents running optimized code and resets execution
        /// counters.
        /// </summary>
        public class StartPreciseCoverageCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.startPreciseCoverage";
        }

        /// <summary>
        /// Enable type profile.
        /// </summary>
        public class StartTypeProfileCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.startTypeProfile";
        }

        public class StopCommand : ICommand<StopResponse>
        {
            string ICommand.Name { get; } = "Profiler.stop";
        }

        public class StopResponse
        {
        }

        /// <summary>
        /// Disable precise code coverage. Disabling releases unnecessary execution count records and allows
        /// executing optimized code.
        /// </summary>
        public class StopPreciseCoverageCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.stopPreciseCoverage";
        }

        /// <summary>
        /// Disable type profile. Disabling releases type profile data collected so far.
        /// </summary>
        public class StopTypeProfileCommand : ICommand
        {
            string ICommand.Name { get; } = "Profiler.stopTypeProfile";
        }

        /// <summary>
        /// Collect coverage data for the current isolate, and resets execution counters. Precise code
        /// coverage needs to have started.
        /// </summary>
        public class TakePreciseCoverageCommand : ICommand<TakePreciseCoverageResponse>
        {
            string ICommand.Name { get; } = "Profiler.takePreciseCoverage";
        }

        public class TakePreciseCoverageResponse
        {
        }

        /// <summary>
        /// Collect type profile.
        /// </summary>
        public class TakeTypeProfileCommand : ICommand<TakeTypeProfileResponse>
        {
            string ICommand.Name { get; } = "Profiler.takeTypeProfile";
        }

        public class TakeTypeProfileResponse
        {
        }
    }

    /// <summary>
    /// Runtime domain exposes JavaScript runtime by means of remote evaluation and mirror objects.
    /// Evaluation results are returned as mirror object that expose object type, string representation
    /// and unique identifier that can be used for further object reference. Original objects are
    /// maintained in memory unless they are either explicitly released or are released along with the
    /// other objects in their object group.
    /// </summary>
    namespace Runtime
    {

        /// <summary>
        /// Unique script identifier.
        /// </summary>
        public struct ScriptId : IAlias<string>
        {
            public string Value { get; private set; }

            public ScriptId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique object identifier.
        /// </summary>
        public struct RemoteObjectId : IAlias<string>
        {
            public string Value { get; private set; }

            public RemoteObjectId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Primitive value which cannot be JSON-stringified. Includes values `-0`, `NaN`, `Infinity`,
        /// `-Infinity`, and bigint literals.
        /// </summary>
        public struct UnserializableValue : IAlias<string>
        {
            public string Value { get; private set; }

            public UnserializableValue(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Mirror object referencing original JavaScript object.
        /// </summary>
        public class RemoteObject
        {

            /// <summary>
            /// Object type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Object subtype hint. Specified for `object` type values only.
            /// </summary>
            [JsonProperty("subtype")]
            public string Subtype { get; set; }

            /// <summary>
            /// Object class (constructor) name. Specified for `object` type values only.
            /// </summary>
            [JsonProperty("className")]
            public string ClassName { get; set; }

            /// <summary>
            /// Remote object value in case of primitive values or JSON values (if it was requested).
            /// </summary>
            [JsonProperty("value")]
            public object Value { get; set; }

            /// <summary>
            /// Primitive value which can not be JSON-stringified does not have `value`, but gets this
            /// property.
            /// </summary>
            [JsonProperty("unserializableValue")]
            public UnserializableValue UnserializableValue { get; set; }

            /// <summary>
            /// String representation of the object.
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// Unique object identifier (for non-primitive values).
            /// </summary>
            [JsonProperty("objectId")]
            public RemoteObjectId ObjectId { get; set; }

            /// <summary>
            /// Preview containing abbreviated property values. Specified for `object` type values only.
            /// </summary>
            [JsonProperty("preview")]
            public ObjectPreview Preview { get; set; }

            [JsonProperty("customPreview")]
            public CustomPreview CustomPreview { get; set; }
        }

        public class CustomPreview
        {

            /// <summary>
            /// The JSON-stringified result of formatter.header(object, config) call.
            /// It contains json ML array that represents RemoteObject.
            /// </summary>
            [JsonProperty("header")]
            public string Header { get; set; }

            /// <summary>
            /// If formatter returns true as a result of formatter.hasBody call then bodyGetterId will
            /// contain RemoteObjectId for the function that returns result of formatter.body(object, config) call.
            /// The result value is json ML array.
            /// </summary>
            [JsonProperty("bodyGetterId")]
            public RemoteObjectId BodyGetterId { get; set; }
        }

        /// <summary>
        /// Object containing abbreviated remote object value.
        /// </summary>
        public class ObjectPreview
        {

            /// <summary>
            /// Object type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Object subtype hint. Specified for `object` type values only.
            /// </summary>
            [JsonProperty("subtype")]
            public string Subtype { get; set; }

            /// <summary>
            /// String representation of the object.
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// True iff some of the properties or entries of the original object did not fit.
            /// </summary>
            [JsonProperty("overflow")]
            public bool Overflow { get; set; }

            /// <summary>
            /// List of the properties.
            /// </summary>
            [JsonProperty("properties")]
            public PropertyPreview[] Properties { get; set; }

            /// <summary>
            /// List of the entries. Specified for `map` and `set` subtype values only.
            /// </summary>
            [JsonProperty("entries")]
            public EntryPreview[] Entries { get; set; }
        }

        public class PropertyPreview
        {

            /// <summary>
            /// Property name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Object type. Accessor means that the property itself is an accessor property.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// User-friendly property value string.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// Nested value preview.
            /// </summary>
            [JsonProperty("valuePreview")]
            public ObjectPreview ValuePreview { get; set; }

            /// <summary>
            /// Object subtype hint. Specified for `object` type values only.
            /// </summary>
            [JsonProperty("subtype")]
            public string Subtype { get; set; }
        }

        public class EntryPreview
        {

            /// <summary>
            /// Preview of the key. Specified for map-like collection entries.
            /// </summary>
            [JsonProperty("key")]
            public ObjectPreview Key { get; set; }

            /// <summary>
            /// Preview of the value.
            /// </summary>
            [JsonProperty("value")]
            public ObjectPreview Value { get; set; }
        }

        /// <summary>
        /// Object property descriptor.
        /// </summary>
        public class PropertyDescriptor
        {

            /// <summary>
            /// Property name or symbol description.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// The value associated with the property.
            /// </summary>
            [JsonProperty("value")]
            public RemoteObject Value { get; set; }

            /// <summary>
            /// True if the value associated with the property may be changed (data descriptors only).
            /// </summary>
            [JsonProperty("writable")]
            public bool Writable { get; set; }

            /// <summary>
            /// A function which serves as a getter for the property, or `undefined` if there is no getter
            /// (accessor descriptors only).
            /// </summary>
            [JsonProperty("get")]
            public RemoteObject Get { get; set; }

            /// <summary>
            /// A function which serves as a setter for the property, or `undefined` if there is no setter
            /// (accessor descriptors only).
            /// </summary>
            [JsonProperty("set")]
            public RemoteObject Set { get; set; }

            /// <summary>
            /// True if the type of this property descriptor may be changed and if the property may be
            /// deleted from the corresponding object.
            /// </summary>
            [JsonProperty("configurable")]
            public bool Configurable { get; set; }

            /// <summary>
            /// True if this property shows up during enumeration of the properties on the corresponding
            /// object.
            /// </summary>
            [JsonProperty("enumerable")]
            public bool Enumerable { get; set; }

            /// <summary>
            /// True if the result was thrown during the evaluation.
            /// </summary>
            [JsonProperty("wasThrown")]
            public bool WasThrown { get; set; }

            /// <summary>
            /// True if the property is owned for the object.
            /// </summary>
            [JsonProperty("isOwn")]
            public bool IsOwn { get; set; }

            /// <summary>
            /// Property symbol object, if the property is of the `symbol` type.
            /// </summary>
            [JsonProperty("symbol")]
            public RemoteObject Symbol { get; set; }
        }

        /// <summary>
        /// Object internal property descriptor. This property isn't normally visible in JavaScript code.
        /// </summary>
        public class InternalPropertyDescriptor
        {

            /// <summary>
            /// Conventional property name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// The value associated with the property.
            /// </summary>
            [JsonProperty("value")]
            public RemoteObject Value { get; set; }
        }

        /// <summary>
        /// Represents function call argument. Either remote object id `objectId`, primitive `value`,
        /// unserializable primitive value or neither of (for undefined) them should be specified.
        /// </summary>
        public class CallArgument
        {

            /// <summary>
            /// Primitive value or serializable javascript object.
            /// </summary>
            [JsonProperty("value")]
            public object Value { get; set; }

            /// <summary>
            /// Primitive value which can not be JSON-stringified.
            /// </summary>
            [JsonProperty("unserializableValue")]
            public UnserializableValue UnserializableValue { get; set; }

            /// <summary>
            /// Remote object handle.
            /// </summary>
            [JsonProperty("objectId")]
            public RemoteObjectId ObjectId { get; set; }
        }

        /// <summary>
        /// Id of an execution context.
        /// </summary>
        public struct ExecutionContextId : IAlias<int>
        {
            public int Value { get; private set; }

            public ExecutionContextId(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Description of an isolated world.
        /// </summary>
        public class ExecutionContextDescription
        {

            /// <summary>
            /// Unique id of the execution context. It can be used to specify in which execution context
            /// script evaluation should be performed.
            /// </summary>
            [JsonProperty("id")]
            public ExecutionContextId Id { get; set; }

            /// <summary>
            /// Execution context origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// Human readable name describing given context.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Embedder-specific auxiliary data.
            /// </summary>
            [JsonProperty("auxData")]
            public object AuxData { get; set; }
        }

        /// <summary>
        /// Detailed information about exception (or error) that was thrown during script compilation or
        /// execution.
        /// </summary>
        public class ExceptionDetails
        {

            /// <summary>
            /// Exception id.
            /// </summary>
            [JsonProperty("exceptionId")]
            public int ExceptionId { get; set; }

            /// <summary>
            /// Exception text, which should be used together with exception object when available.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Line number of the exception location (0-based).
            /// </summary>
            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            /// <summary>
            /// Column number of the exception location (0-based).
            /// </summary>
            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }

            /// <summary>
            /// Script ID of the exception location.
            /// </summary>
            [JsonProperty("scriptId")]
            public ScriptId ScriptId { get; set; }

            /// <summary>
            /// URL of the exception location, to be used when the script was not reported.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// JavaScript stack trace if available.
            /// </summary>
            [JsonProperty("stackTrace")]
            public StackTrace StackTrace { get; set; }

            /// <summary>
            /// Exception object if available.
            /// </summary>
            [JsonProperty("exception")]
            public RemoteObject Exception { get; set; }

            /// <summary>
            /// Identifier of the context where exception happened.
            /// </summary>
            [JsonProperty("executionContextId")]
            public ExecutionContextId ExecutionContextId { get; set; }
        }

        /// <summary>
        /// Number of milliseconds since epoch.
        /// </summary>
        public struct Timestamp : IAlias<double>
        {
            public double Value { get; private set; }

            public Timestamp(double value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Number of milliseconds.
        /// </summary>
        public struct TimeDelta : IAlias<double>
        {
            public double Value { get; private set; }

            public TimeDelta(double value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Stack entry for runtime errors and assertions.
        /// </summary>
        public class CallFrame
        {

            /// <summary>
            /// JavaScript function name.
            /// </summary>
            [JsonProperty("functionName")]
            public string FunctionName { get; set; }

            /// <summary>
            /// JavaScript script id.
            /// </summary>
            [JsonProperty("scriptId")]
            public ScriptId ScriptId { get; set; }

            /// <summary>
            /// JavaScript script name or url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// JavaScript script line number (0-based).
            /// </summary>
            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            /// <summary>
            /// JavaScript script column number (0-based).
            /// </summary>
            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }
        }

        /// <summary>
        /// Call frames for assertions or error messages.
        /// </summary>
        public class StackTrace
        {

            /// <summary>
            /// String label of this stack trace. For async traces this may be a name of the function that
            /// initiated the async call.
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// JavaScript function name.
            /// </summary>
            [JsonProperty("callFrames")]
            public CallFrame[] CallFrames { get; set; }

            /// <summary>
            /// Asynchronous JavaScript stack trace that preceded this stack, if available.
            /// </summary>
            [JsonProperty("parent")]
            public StackTrace Parent { get; set; }

            /// <summary>
            /// Asynchronous JavaScript stack trace that preceded this stack, if available.
            /// </summary>
            [JsonProperty("parentId")]
            public StackTraceId ParentId { get; set; }
        }

        /// <summary>
        /// Unique identifier of current debugger.
        /// </summary>
        public struct UniqueDebuggerId : IAlias<string>
        {
            public string Value { get; private set; }

            public UniqueDebuggerId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// If `debuggerId` is set stack trace comes from another debugger and can be resolved there. This
        /// allows to track cross-debugger calls. See `Runtime.StackTrace` and `Debugger.paused` for usages.
        /// </summary>
        public class StackTraceId
        {

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("debuggerId")]
            public UniqueDebuggerId DebuggerId { get; set; }
        }

        /// <summary>
        /// Add handler to promise with given promise object id.
        /// </summary>
        public class AwaitPromiseCommand : ICommand<AwaitPromiseResponse>
        {
            string ICommand.Name { get; } = "Runtime.awaitPromise";
        }

        public class AwaitPromiseResponse
        {
        }

        /// <summary>
        /// Calls function with given declaration on the given object. Object group of the result is
        /// inherited from the target object.
        /// </summary>
        public class CallFunctionOnCommand : ICommand<CallFunctionOnResponse>
        {
            string ICommand.Name { get; } = "Runtime.callFunctionOn";
        }

        public class CallFunctionOnResponse
        {
        }

        /// <summary>
        /// Compiles expression.
        /// </summary>
        public class CompileScriptCommand : ICommand<CompileScriptResponse>
        {
            string ICommand.Name { get; } = "Runtime.compileScript";
        }

        public class CompileScriptResponse
        {
        }

        /// <summary>
        /// Disables reporting of execution contexts creation.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.disable";
        }

        /// <summary>
        /// Discards collected exceptions and console API calls.
        /// </summary>
        public class DiscardConsoleEntriesCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.discardConsoleEntries";
        }

        /// <summary>
        /// Enables reporting of execution contexts creation by means of `executionContextCreated` event.
        /// When the reporting gets enabled the event will be sent immediately for each existing execution
        /// context.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.enable";
        }

        /// <summary>
        /// Evaluates expression on global object.
        /// </summary>
        public class EvaluateCommand : ICommand<EvaluateResponse>
        {
            string ICommand.Name { get; } = "Runtime.evaluate";
        }

        public class EvaluateResponse
        {
        }

        /// <summary>
        /// Returns the isolate id.
        /// </summary>
        public class GetIsolateIdCommand : ICommand<GetIsolateIdResponse>
        {
            string ICommand.Name { get; } = "Runtime.getIsolateId";
        }

        public class GetIsolateIdResponse
        {
        }

        /// <summary>
        /// Returns the JavaScript heap usage.
        /// It is the total usage of the corresponding isolate not scoped to a particular Runtime.
        /// </summary>
        public class GetHeapUsageCommand : ICommand<GetHeapUsageResponse>
        {
            string ICommand.Name { get; } = "Runtime.getHeapUsage";
        }

        public class GetHeapUsageResponse
        {
        }

        /// <summary>
        /// Returns properties of a given object. Object group of the result is inherited from the target
        /// object.
        /// </summary>
        public class GetPropertiesCommand : ICommand<GetPropertiesResponse>
        {
            string ICommand.Name { get; } = "Runtime.getProperties";
        }

        public class GetPropertiesResponse
        {
        }

        /// <summary>
        /// Returns all let, const and class variables from global scope.
        /// </summary>
        public class GlobalLexicalScopeNamesCommand : ICommand<GlobalLexicalScopeNamesResponse>
        {
            string ICommand.Name { get; } = "Runtime.globalLexicalScopeNames";
        }

        public class GlobalLexicalScopeNamesResponse
        {
        }

        public class QueryObjectsCommand : ICommand<QueryObjectsResponse>
        {
            string ICommand.Name { get; } = "Runtime.queryObjects";
        }

        public class QueryObjectsResponse
        {
        }

        /// <summary>
        /// Releases remote object with given id.
        /// </summary>
        public class ReleaseObjectCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.releaseObject";
        }

        /// <summary>
        /// Releases all remote objects that belong to a given group.
        /// </summary>
        public class ReleaseObjectGroupCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.releaseObjectGroup";
        }

        /// <summary>
        /// Tells inspected instance to run if it was waiting for debugger to attach.
        /// </summary>
        public class RunIfWaitingForDebuggerCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.runIfWaitingForDebugger";
        }

        /// <summary>
        /// Runs script with given id in a given context.
        /// </summary>
        public class RunScriptCommand : ICommand<RunScriptResponse>
        {
            string ICommand.Name { get; } = "Runtime.runScript";
        }

        public class RunScriptResponse
        {
        }

        /// <summary>
        /// Enables or disables async call stacks tracking.
        /// </summary>
        public class SetAsyncCallStackDepthCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.setAsyncCallStackDepth";
        }

        public class SetCustomObjectFormatterEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.setCustomObjectFormatterEnabled";
        }

        public class SetMaxCallStackSizeToCaptureCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.setMaxCallStackSizeToCapture";
        }

        /// <summary>
        /// Terminate current or next JavaScript execution.
        /// Will cancel the termination when the outer-most script execution ends.
        /// </summary>
        public class TerminateExecutionCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.terminateExecution";
        }

        /// <summary>
        /// If executionContextId is empty, adds binding with the given name on the
        /// global objects of all inspected contexts, including those created later,
        /// bindings survive reloads.
        /// If executionContextId is specified, adds binding only on global object of
        /// given execution context.
        /// Binding function takes exactly one argument, this argument should be string,
        /// in case of any other input, function throws an exception.
        /// Each binding function call produces Runtime.bindingCalled notification.
        /// </summary>
        public class AddBindingCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.addBinding";
        }

        /// <summary>
        /// This method does not remove binding function from global object but
        /// unsubscribes current runtime agent from Runtime.bindingCalled notifications.
        /// </summary>
        public class RemoveBindingCommand : ICommand
        {
            string ICommand.Name { get; } = "Runtime.removeBinding";
        }
    }

    /// <summary>
    /// This domain is deprecated.
    /// </summary>
    namespace Schema
    {

        /// <summary>
        /// Description of the protocol domain.
        /// </summary>
        public class Domain
        {

            /// <summary>
            /// Domain name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Domain version.
            /// </summary>
            [JsonProperty("version")]
            public string Version { get; set; }
        }

        /// <summary>
        /// Returns supported domains.
        /// </summary>
        public class GetDomainsCommand : ICommand<GetDomainsResponse>
        {
            string ICommand.Name { get; } = "Schema.getDomains";
        }

        public class GetDomainsResponse
        {
        }
    }
}
