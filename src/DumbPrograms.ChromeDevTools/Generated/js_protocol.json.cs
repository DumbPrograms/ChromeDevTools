using System;

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
        public class BreakpointId
        {
        }

        /// <summary>
        /// Call frame identifier.
        /// </summary>
        public class CallFrameId
        {
        }

        /// <summary>
        /// Location in the source code.
        /// </summary>
        public class Location
        {
        }

        /// <summary>
        /// Location in the source code.
        /// </summary>
        public class ScriptPosition
        {
        }

        /// <summary>
        /// JavaScript call frame. Array of call frames form the call stack.
        /// </summary>
        public class CallFrame
        {
        }

        /// <summary>
        /// Scope description.
        /// </summary>
        public class Scope
        {
        }

        /// <summary>
        /// Search match for resource.
        /// </summary>
        public class SearchMatch
        {
        }

        public class BreakLocation
        {
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
        public class HeapSnapshotObjectId
        {
        }

        /// <summary>
        /// Sampling Heap Profile node. Holds callsite information, allocation statistics and child nodes.
        /// </summary>
        public class SamplingHeapProfileNode
        {
        }

        /// <summary>
        /// A single sample from a sampling profile.
        /// </summary>
        public class SamplingHeapProfileSample
        {
        }

        /// <summary>
        /// Sampling profile.
        /// </summary>
        public class SamplingHeapProfile
        {
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
        }

        /// <summary>
        /// Profile.
        /// </summary>
        public class Profile
        {
        }

        /// <summary>
        /// Specifies a number of samples attributed to a certain source position.
        /// </summary>
        public class PositionTickInfo
        {
        }

        /// <summary>
        /// Coverage data for a source range.
        /// </summary>
        public class CoverageRange
        {
        }

        /// <summary>
        /// Coverage data for a JavaScript function.
        /// </summary>
        public class FunctionCoverage
        {
        }

        /// <summary>
        /// Coverage data for a JavaScript script.
        /// </summary>
        public class ScriptCoverage
        {
        }

        /// <summary>
        /// Describes a type collected during runtime.
        /// </summary>
        public class TypeObject
        {
        }

        /// <summary>
        /// Source offset and types for a parameter or return value.
        /// </summary>
        public class TypeProfileEntry
        {
        }

        /// <summary>
        /// Type profile data collected during runtime for a JavaScript script.
        /// </summary>
        public class ScriptTypeProfile
        {
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
        public class ScriptId
        {
        }

        /// <summary>
        /// Unique object identifier.
        /// </summary>
        public class RemoteObjectId
        {
        }

        /// <summary>
        /// Primitive value which cannot be JSON-stringified. Includes values `-0`, `NaN`, `Infinity`,
        /// `-Infinity`, and bigint literals.
        /// </summary>
        public class UnserializableValue
        {
        }

        /// <summary>
        /// Mirror object referencing original JavaScript object.
        /// </summary>
        public class RemoteObject
        {
        }

        public class CustomPreview
        {
        }

        /// <summary>
        /// Object containing abbreviated remote object value.
        /// </summary>
        public class ObjectPreview
        {
        }

        public class PropertyPreview
        {
        }

        public class EntryPreview
        {
        }

        /// <summary>
        /// Object property descriptor.
        /// </summary>
        public class PropertyDescriptor
        {
        }

        /// <summary>
        /// Object internal property descriptor. This property isn't normally visible in JavaScript code.
        /// </summary>
        public class InternalPropertyDescriptor
        {
        }

        /// <summary>
        /// Represents function call argument. Either remote object id `objectId`, primitive `value`,
        /// unserializable primitive value or neither of (for undefined) them should be specified.
        /// </summary>
        public class CallArgument
        {
        }

        /// <summary>
        /// Id of an execution context.
        /// </summary>
        public class ExecutionContextId
        {
        }

        /// <summary>
        /// Description of an isolated world.
        /// </summary>
        public class ExecutionContextDescription
        {
        }

        /// <summary>
        /// Detailed information about exception (or error) that was thrown during script compilation or
        /// execution.
        /// </summary>
        public class ExceptionDetails
        {
        }

        /// <summary>
        /// Number of milliseconds since epoch.
        /// </summary>
        public class Timestamp
        {
        }

        /// <summary>
        /// Number of milliseconds.
        /// </summary>
        public class TimeDelta
        {
        }

        /// <summary>
        /// Stack entry for runtime errors and assertions.
        /// </summary>
        public class CallFrame
        {
        }

        /// <summary>
        /// Call frames for assertions or error messages.
        /// </summary>
        public class StackTrace
        {
        }

        /// <summary>
        /// Unique identifier of current debugger.
        /// </summary>
        public class UniqueDebuggerId
        {
        }

        /// <summary>
        /// If `debuggerId` is set stack trace comes from another debugger and can be resolved there. This
        /// allows to track cross-debugger calls. See `Runtime.StackTrace` and `Debugger.paused` for usages.
        /// </summary>
        public class StackTraceId
        {
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
