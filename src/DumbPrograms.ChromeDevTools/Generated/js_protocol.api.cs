using System;
using System.Threading;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    partial class InspectorClient
    {

        /// <summary>
        /// This domain is deprecated - use Runtime or Log instead.
        /// </summary>
        [Obsolete]
        public ConsoleInspectorClient Console => __Console__ ?? (__Console__ = new ConsoleInspectorClient(this));
        [Obsolete]
        private ConsoleInspectorClient __Console__;

        /// <summary>
        /// Debugger domain exposes JavaScript debugging capabilities. It allows setting and removing
        /// breakpoints, stepping through execution, exploring stack traces, etc.
        /// </summary>
        public DebuggerInspectorClient Debugger => __Debugger__ ?? (__Debugger__ = new DebuggerInspectorClient(this));
        private DebuggerInspectorClient __Debugger__;

        public HeapProfilerInspectorClient HeapProfiler => __HeapProfiler__ ?? (__HeapProfiler__ = new HeapProfilerInspectorClient(this));
        private HeapProfilerInspectorClient __HeapProfiler__;

        public ProfilerInspectorClient Profiler => __Profiler__ ?? (__Profiler__ = new ProfilerInspectorClient(this));
        private ProfilerInspectorClient __Profiler__;

        /// <summary>
        /// Runtime domain exposes JavaScript runtime by means of remote evaluation and mirror objects.
        /// Evaluation results are returned as mirror object that expose object type, string representation
        /// and unique identifier that can be used for further object reference. Original objects are
        /// maintained in memory unless they are either explicitly released or are released along with the
        /// other objects in their object group.
        /// </summary>
        public RuntimeInspectorClient Runtime => __Runtime__ ?? (__Runtime__ = new RuntimeInspectorClient(this));
        private RuntimeInspectorClient __Runtime__;

        /// <summary>
        /// This domain is deprecated.
        /// </summary>
        [Obsolete]
        public SchemaInspectorClient Schema => __Schema__ ?? (__Schema__ = new SchemaInspectorClient(this));
        [Obsolete]
        private SchemaInspectorClient __Schema__;

        [Obsolete]
        public class ConsoleInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public ConsoleInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            /// <summary>
            /// Does nothing.
            /// </summary>
            public Task ClearMessages
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Console.ClearMessagesCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Disables console domain, prevents further console messages from being reported to the client.
            /// </summary>
            public Task Disable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Console.DisableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enables console domain, sends the messages collected so far to the client by means of the
            /// `messageAdded` notification.
            /// </summary>
            public Task Enable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Console.EnableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Issued when new console message is added.
            /// </summary>
            public event Func<Protocol.Console.MessageAddedEvent, Task> MessageAdded
            {
                add => InspectorClient.AddEventHandler("Console.messageAdded", value);
                remove => InspectorClient.RemoveEventHandler("Console.messageAdded", value);
            }
        }

        public class DebuggerInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public DebuggerInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            /// <summary>
            /// Continues execution until specific location is reached.
            /// </summary>
            /// <param name="location">
            /// Location to continue to.
            /// </param>
            /// <param name="targetCallFrames" />
            public Task ContinueToLocation
            (
                Protocol.Debugger.Location @location, 
                string @targetCallFrames = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.ContinueToLocationCommand
                    {
                        Location = @location,
                        TargetCallFrames = @targetCallFrames,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Disables debugger for given page.
            /// </summary>
            public Task Disable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.DisableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enables debugger for the given page. Clients should not assume that the debugging has been
            /// enabled until the result for this command is received.
            /// </summary>
            public Task<Protocol.Debugger.EnableResponse> Enable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.EnableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Evaluates expression on a given call frame.
            /// </summary>
            /// <param name="callFrameId">
            /// Call frame identifier to evaluate on.
            /// </param>
            /// <param name="expression">
            /// Expression to evaluate.
            /// </param>
            /// <param name="objectGroup">
            /// String object group name to put result into (allows rapid releasing resulting object handles
            /// using `releaseObjectGroup`).
            /// </param>
            /// <param name="includeCommandLineAPI">
            /// Specifies whether command line API should be available to the evaluated expression, defaults
            /// to false.
            /// </param>
            /// <param name="silent">
            /// In silent mode exceptions thrown during evaluation are not reported and do not pause
            /// execution. Overrides `setPauseOnException` state.
            /// </param>
            /// <param name="returnByValue">
            /// Whether the result is expected to be a JSON object that should be sent by value.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the result.
            /// </param>
            /// <param name="throwOnSideEffect">
            /// Whether to throw an exception if side effect cannot be ruled out during evaluation.
            /// </param>
            /// <param name="timeout">
            /// Terminate execution after timing out (number of milliseconds).
            /// </param>
            public Task<Protocol.Debugger.EvaluateOnCallFrameResponse> EvaluateOnCallFrame
            (
                Protocol.Debugger.CallFrameId @callFrameId, 
                string @expression, 
                string @objectGroup = default, 
                bool? @includeCommandLineAPI = default, 
                bool? @silent = default, 
                bool? @returnByValue = default, 
                bool? @generatePreview = default, 
                bool? @throwOnSideEffect = default, 
                Protocol.Runtime.TimeDelta @timeout = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.EvaluateOnCallFrameCommand
                    {
                        CallFrameId = @callFrameId,
                        Expression = @expression,
                        ObjectGroup = @objectGroup,
                        IncludeCommandLineAPI = @includeCommandLineAPI,
                        Silent = @silent,
                        ReturnByValue = @returnByValue,
                        GeneratePreview = @generatePreview,
                        ThrowOnSideEffect = @throwOnSideEffect,
                        Timeout = @timeout,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns possible locations for breakpoint. scriptId in start and end range locations should be
            /// the same.
            /// </summary>
            /// <param name="start">
            /// Start of range to search possible breakpoint locations in.
            /// </param>
            /// <param name="end">
            /// End of range to search possible breakpoint locations in (excluding). When not specified, end
            /// of scripts is used as end of range.
            /// </param>
            /// <param name="restrictToFunction">
            /// Only consider locations which are in the same (non-nested) function as start.
            /// </param>
            public Task<Protocol.Debugger.GetPossibleBreakpointsResponse> GetPossibleBreakpoints
            (
                Protocol.Debugger.Location @start, 
                Protocol.Debugger.Location @end = default, 
                bool? @restrictToFunction = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.GetPossibleBreakpointsCommand
                    {
                        Start = @start,
                        End = @end,
                        RestrictToFunction = @restrictToFunction,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns source for the script with given id.
            /// </summary>
            /// <param name="scriptId">
            /// Id of the script to get source for.
            /// </param>
            public Task<Protocol.Debugger.GetScriptSourceResponse> GetScriptSource
            (
                Protocol.Runtime.ScriptId @scriptId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.GetScriptSourceCommand
                    {
                        ScriptId = @scriptId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns stack trace with given `stackTraceId`.
            /// </summary>
            /// <param name="stackTraceId" />
            public Task<Protocol.Debugger.GetStackTraceResponse> GetStackTrace
            (
                Protocol.Runtime.StackTraceId @stackTraceId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.GetStackTraceCommand
                    {
                        StackTraceId = @stackTraceId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Stops on the next JavaScript statement.
            /// </summary>
            public Task Pause
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.PauseCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="parentStackTraceId">
            /// Debugger will pause when async call with given stack trace is started.
            /// </param>
            public Task PauseOnAsyncCall
            (
                Protocol.Runtime.StackTraceId @parentStackTraceId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.PauseOnAsyncCallCommand
                    {
                        ParentStackTraceId = @parentStackTraceId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Removes JavaScript breakpoint.
            /// </summary>
            /// <param name="breakpointId" />
            public Task RemoveBreakpoint
            (
                Protocol.Debugger.BreakpointId @breakpointId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.RemoveBreakpointCommand
                    {
                        BreakpointId = @breakpointId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Restarts particular call frame from the beginning.
            /// </summary>
            /// <param name="callFrameId">
            /// Call frame identifier to evaluate on.
            /// </param>
            public Task<Protocol.Debugger.RestartFrameResponse> RestartFrame
            (
                Protocol.Debugger.CallFrameId @callFrameId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.RestartFrameCommand
                    {
                        CallFrameId = @callFrameId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Resumes JavaScript execution.
            /// </summary>
            public Task Resume
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.ResumeCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Searches for given string in script content.
            /// </summary>
            /// <param name="scriptId">
            /// Id of the script to search in.
            /// </param>
            /// <param name="query">
            /// String to search for.
            /// </param>
            /// <param name="caseSensitive">
            /// If true, search is case sensitive.
            /// </param>
            /// <param name="isRegex">
            /// If true, treats string parameter as regex.
            /// </param>
            public Task<Protocol.Debugger.SearchInContentResponse> SearchInContent
            (
                Protocol.Runtime.ScriptId @scriptId, 
                string @query, 
                bool? @caseSensitive = default, 
                bool? @isRegex = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SearchInContentCommand
                    {
                        ScriptId = @scriptId,
                        Query = @query,
                        CaseSensitive = @caseSensitive,
                        IsRegex = @isRegex,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            /// <param name="maxDepth">
            /// Maximum depth of async call stacks. Setting to `0` will effectively disable collecting async
            /// call stacks (default).
            /// </param>
            public Task SetAsyncCallStackDepth
            (
                int @maxDepth, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetAsyncCallStackDepthCommand
                    {
                        MaxDepth = @maxDepth,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Replace previous blackbox patterns with passed ones. Forces backend to skip stepping/pausing in
            /// scripts with url matching one of the patterns. VM will try to leave blackboxed script by
            /// performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// </summary>
            /// <param name="patterns">
            /// Array of regexps that will be used to check script url for blackbox state.
            /// </param>
            public Task SetBlackboxPatterns
            (
                string[] @patterns, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBlackboxPatternsCommand
                    {
                        Patterns = @patterns,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Makes backend skip steps in the script in blackboxed ranges. VM will try leave blacklisted
            /// scripts by performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// Positions array contains positions where blackbox state is changed. First interval isn't
            /// blackboxed. Array should be sorted.
            /// </summary>
            /// <param name="scriptId">
            /// Id of the script.
            /// </param>
            /// <param name="positions" />
            public Task SetBlackboxedRanges
            (
                Protocol.Runtime.ScriptId @scriptId, 
                Protocol.Debugger.ScriptPosition[] @positions, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBlackboxedRangesCommand
                    {
                        ScriptId = @scriptId,
                        Positions = @positions,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Sets JavaScript breakpoint at a given location.
            /// </summary>
            /// <param name="location">
            /// Location to set breakpoint in.
            /// </param>
            /// <param name="condition">
            /// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
            /// breakpoint if this expression evaluates to true.
            /// </param>
            public Task<Protocol.Debugger.SetBreakpointResponse> SetBreakpoint
            (
                Protocol.Debugger.Location @location, 
                string @condition = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBreakpointCommand
                    {
                        Location = @location,
                        Condition = @condition,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
            /// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
            /// `locations` property. Further matching script parsing will result in subsequent
            /// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
            /// </summary>
            /// <param name="lineNumber">
            /// Line number to set breakpoint at.
            /// </param>
            /// <param name="url">
            /// URL of the resources to set breakpoint on.
            /// </param>
            /// <param name="urlRegex">
            /// Regex pattern for the URLs of the resources to set breakpoints on. Either `url` or
            /// `urlRegex` must be specified.
            /// </param>
            /// <param name="scriptHash">
            /// Script hash of the resources to set breakpoint on.
            /// </param>
            /// <param name="columnNumber">
            /// Offset in the line to set breakpoint at.
            /// </param>
            /// <param name="condition">
            /// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
            /// breakpoint if this expression evaluates to true.
            /// </param>
            public Task<Protocol.Debugger.SetBreakpointByUrlResponse> SetBreakpointByUrl
            (
                int @lineNumber, 
                string @url = default, 
                string @urlRegex = default, 
                string @scriptHash = default, 
                int? @columnNumber = default, 
                string @condition = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBreakpointByUrlCommand
                    {
                        LineNumber = @lineNumber,
                        Url = @url,
                        UrlRegex = @urlRegex,
                        ScriptHash = @scriptHash,
                        ColumnNumber = @columnNumber,
                        Condition = @condition,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Sets JavaScript breakpoint before each call to the given function.
            /// If another function was created from the same source as a given one,
            /// calling it will also trigger the breakpoint.
            /// </summary>
            /// <param name="objectId">
            /// Function object id.
            /// </param>
            /// <param name="condition">
            /// Expression to use as a breakpoint condition. When specified, debugger will
            /// stop on the breakpoint if this expression evaluates to true.
            /// </param>
            public Task<Protocol.Debugger.SetBreakpointOnFunctionCallResponse> SetBreakpointOnFunctionCall
            (
                Protocol.Runtime.RemoteObjectId @objectId, 
                string @condition = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBreakpointOnFunctionCallCommand
                    {
                        ObjectId = @objectId,
                        Condition = @condition,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Activates / deactivates all breakpoints on the page.
            /// </summary>
            /// <param name="active">
            /// New value for breakpoints active state.
            /// </param>
            public Task SetBreakpointsActive
            (
                bool @active, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetBreakpointsActiveCommand
                    {
                        Active = @active,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or
            /// no exceptions. Initial pause on exceptions state is `none`.
            /// </summary>
            /// <param name="state">
            /// Pause on exceptions mode.
            /// </param>
            public Task SetPauseOnExceptions
            (
                string @state, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetPauseOnExceptionsCommand
                    {
                        State = @state,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Changes return value in top frame. Available only at return break position.
            /// </summary>
            /// <param name="newValue">
            /// New return value.
            /// </param>
            public Task SetReturnValue
            (
                Protocol.Runtime.CallArgument @newValue, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetReturnValueCommand
                    {
                        NewValue = @newValue,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Edits JavaScript source live.
            /// </summary>
            /// <param name="scriptId">
            /// Id of the script to edit.
            /// </param>
            /// <param name="scriptSource">
            /// New content of the script.
            /// </param>
            /// <param name="dryRun">
            /// If true the change will not actually be applied. Dry run may be used to get result
            /// description without actually modifying the code.
            /// </param>
            public Task<Protocol.Debugger.SetScriptSourceResponse> SetScriptSource
            (
                Protocol.Runtime.ScriptId @scriptId, 
                string @scriptSource, 
                bool? @dryRun = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetScriptSourceCommand
                    {
                        ScriptId = @scriptId,
                        ScriptSource = @scriptSource,
                        DryRun = @dryRun,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Makes page not interrupt on any pauses (breakpoint, exception, dom exception etc).
            /// </summary>
            /// <param name="skip">
            /// New value for skip pauses state.
            /// </param>
            public Task SetSkipAllPauses
            (
                bool @skip, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetSkipAllPausesCommand
                    {
                        Skip = @skip,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Changes value of variable in a callframe. Object-based scopes are not supported and must be
            /// mutated manually.
            /// </summary>
            /// <param name="scopeNumber">
            /// 0-based number of scope as was listed in scope chain. Only 'local', 'closure' and 'catch'
            /// scope types are allowed. Other scopes could be manipulated manually.
            /// </param>
            /// <param name="variableName">
            /// Variable name.
            /// </param>
            /// <param name="newValue">
            /// New variable value.
            /// </param>
            /// <param name="callFrameId">
            /// Id of callframe that holds variable.
            /// </param>
            public Task SetVariableValue
            (
                int @scopeNumber, 
                string @variableName, 
                Protocol.Runtime.CallArgument @newValue, 
                Protocol.Debugger.CallFrameId @callFrameId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.SetVariableValueCommand
                    {
                        ScopeNumber = @scopeNumber,
                        VariableName = @variableName,
                        NewValue = @newValue,
                        CallFrameId = @callFrameId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Steps into the function call.
            /// </summary>
            /// <param name="breakOnAsyncCall">
            /// Debugger will issue additional Debugger.paused notification if any async task is scheduled
            /// before next pause.
            /// </param>
            public Task StepInto
            (
                bool? @breakOnAsyncCall = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.StepIntoCommand
                    {
                        BreakOnAsyncCall = @breakOnAsyncCall,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Steps out of the function call.
            /// </summary>
            public Task StepOut
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.StepOutCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Steps over the statement.
            /// </summary>
            public Task StepOver
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Debugger.StepOverCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Fired when breakpoint is resolved to an actual script and location.
            /// </summary>
            public event Func<Protocol.Debugger.BreakpointResolvedEvent, Task> BreakpointResolved
            {
                add => InspectorClient.AddEventHandler("Debugger.breakpointResolved", value);
                remove => InspectorClient.RemoveEventHandler("Debugger.breakpointResolved", value);
            }

            /// <summary>
            /// Fired when the virtual machine stopped on breakpoint or exception or any other stop criteria.
            /// </summary>
            public event Func<Protocol.Debugger.PausedEvent, Task> Paused
            {
                add => InspectorClient.AddEventHandler("Debugger.paused", value);
                remove => InspectorClient.RemoveEventHandler("Debugger.paused", value);
            }

            /// <summary>
            /// Fired when the virtual machine resumed execution.
            /// </summary>
            public event Func<Protocol.Debugger.ResumedEvent, Task> Resumed
            {
                add => InspectorClient.AddEventHandler("Debugger.resumed", value);
                remove => InspectorClient.RemoveEventHandler("Debugger.resumed", value);
            }

            /// <summary>
            /// Fired when virtual machine fails to parse the script.
            /// </summary>
            public event Func<Protocol.Debugger.ScriptFailedToParseEvent, Task> ScriptFailedToParse
            {
                add => InspectorClient.AddEventHandler("Debugger.scriptFailedToParse", value);
                remove => InspectorClient.RemoveEventHandler("Debugger.scriptFailedToParse", value);
            }

            /// <summary>
            /// Fired when virtual machine parses script. This event is also fired for all known and uncollected
            /// scripts upon enabling debugger.
            /// </summary>
            public event Func<Protocol.Debugger.ScriptParsedEvent, Task> ScriptParsed
            {
                add => InspectorClient.AddEventHandler("Debugger.scriptParsed", value);
                remove => InspectorClient.RemoveEventHandler("Debugger.scriptParsed", value);
            }
        }

        public class HeapProfilerInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public HeapProfilerInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            /// <summary>
            /// Enables console to refer to the node with given id via $x (see Command Line API for more details
            /// $x functions).
            /// </summary>
            /// <param name="heapObjectId">
            /// Heap snapshot object id to be accessible by means of $x command line API.
            /// </param>
            public Task AddInspectedHeapObject
            (
                Protocol.HeapProfiler.HeapSnapshotObjectId @heapObjectId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.AddInspectedHeapObjectCommand
                    {
                        HeapObjectId = @heapObjectId,
                    }
                    , cancellation
                )
                ;
            }

            public Task CollectGarbage
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.CollectGarbageCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            public Task Disable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.DisableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            public Task Enable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.EnableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="objectId">
            /// Identifier of the object to get heap object id for.
            /// </param>
            public Task<Protocol.HeapProfiler.GetHeapObjectIdResponse> GetHeapObjectId
            (
                Protocol.Runtime.RemoteObjectId @objectId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.GetHeapObjectIdCommand
                    {
                        ObjectId = @objectId,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="objectId" />
            /// <param name="objectGroup">
            /// Symbolic group name that can be used to release multiple objects.
            /// </param>
            public Task<Protocol.HeapProfiler.GetObjectByHeapObjectIdResponse> GetObjectByHeapObjectId
            (
                Protocol.HeapProfiler.HeapSnapshotObjectId @objectId, 
                string @objectGroup = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.GetObjectByHeapObjectIdCommand
                    {
                        ObjectId = @objectId,
                        ObjectGroup = @objectGroup,
                    }
                    , cancellation
                )
                ;
            }

            public Task<Protocol.HeapProfiler.GetSamplingProfileResponse> GetSamplingProfile
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.GetSamplingProfileCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="samplingInterval">
            /// Average sample interval in bytes. Poisson distribution is used for the intervals. The
            /// default value is 32768 bytes.
            /// </param>
            public Task StartSampling
            (
                double? @samplingInterval = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.StartSamplingCommand
                    {
                        SamplingInterval = @samplingInterval,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="trackAllocations" />
            public Task StartTrackingHeapObjects
            (
                bool? @trackAllocations = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.StartTrackingHeapObjectsCommand
                    {
                        TrackAllocations = @trackAllocations,
                    }
                    , cancellation
                )
                ;
            }

            public Task<Protocol.HeapProfiler.StopSamplingResponse> StopSampling
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.StopSamplingCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="reportProgress">
            /// If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken
            /// when the tracking is stopped.
            /// </param>
            public Task StopTrackingHeapObjects
            (
                bool? @reportProgress = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.StopTrackingHeapObjectsCommand
                    {
                        ReportProgress = @reportProgress,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="reportProgress">
            /// If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken.
            /// </param>
            public Task TakeHeapSnapshot
            (
                bool? @reportProgress = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.HeapProfiler.TakeHeapSnapshotCommand
                    {
                        ReportProgress = @reportProgress,
                    }
                    , cancellation
                )
                ;
            }

            public event Func<Protocol.HeapProfiler.AddHeapSnapshotChunkEvent, Task> AddHeapSnapshotChunk
            {
                add => InspectorClient.AddEventHandler("HeapProfiler.addHeapSnapshotChunk", value);
                remove => InspectorClient.RemoveEventHandler("HeapProfiler.addHeapSnapshotChunk", value);
            }

            /// <summary>
            /// If heap objects tracking has been started then backend may send update for one or more fragments
            /// </summary>
            public event Func<Protocol.HeapProfiler.HeapStatsUpdateEvent, Task> HeapStatsUpdate
            {
                add => InspectorClient.AddEventHandler("HeapProfiler.heapStatsUpdate", value);
                remove => InspectorClient.RemoveEventHandler("HeapProfiler.heapStatsUpdate", value);
            }

            /// <summary>
            /// If heap objects tracking has been started then backend regularly sends a current value for last
            /// seen object id and corresponding timestamp. If the were changes in the heap since last event
            /// then one or more heapStatsUpdate events will be sent before a new lastSeenObjectId event.
            /// </summary>
            public event Func<Protocol.HeapProfiler.LastSeenObjectIdEvent, Task> LastSeenObjectId
            {
                add => InspectorClient.AddEventHandler("HeapProfiler.lastSeenObjectId", value);
                remove => InspectorClient.RemoveEventHandler("HeapProfiler.lastSeenObjectId", value);
            }

            public event Func<Protocol.HeapProfiler.ReportHeapSnapshotProgressEvent, Task> ReportHeapSnapshotProgress
            {
                add => InspectorClient.AddEventHandler("HeapProfiler.reportHeapSnapshotProgress", value);
                remove => InspectorClient.RemoveEventHandler("HeapProfiler.reportHeapSnapshotProgress", value);
            }

            public event Func<Protocol.HeapProfiler.ResetProfilesEvent, Task> ResetProfiles
            {
                add => InspectorClient.AddEventHandler("HeapProfiler.resetProfiles", value);
                remove => InspectorClient.RemoveEventHandler("HeapProfiler.resetProfiles", value);
            }
        }

        public class ProfilerInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public ProfilerInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            public Task Disable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.DisableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            public Task Enable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.EnableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Collect coverage data for the current isolate. The coverage data may be incomplete due to
            /// garbage collection.
            /// </summary>
            public Task<Protocol.Profiler.GetBestEffortCoverageResponse> GetBestEffortCoverage
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.GetBestEffortCoverageCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Changes CPU profiler sampling interval. Must be called before CPU profiles recording started.
            /// </summary>
            /// <param name="interval">
            /// New sampling interval in microseconds.
            /// </param>
            public Task SetSamplingInterval
            (
                int @interval, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.SetSamplingIntervalCommand
                    {
                        Interval = @interval,
                    }
                    , cancellation
                )
                ;
            }

            public Task Start
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StartCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enable precise code coverage. Coverage data for JavaScript executed before enabling precise code
            /// coverage may be incomplete. Enabling prevents running optimized code and resets execution
            /// counters.
            /// </summary>
            /// <param name="callCount">
            /// Collect accurate call counts beyond simple 'covered' or 'not covered'.
            /// </param>
            /// <param name="detailed">
            /// Collect block-based coverage.
            /// </param>
            public Task StartPreciseCoverage
            (
                bool? @callCount = default, 
                bool? @detailed = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StartPreciseCoverageCommand
                    {
                        CallCount = @callCount,
                        Detailed = @detailed,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enable type profile.
            /// </summary>
            public Task StartTypeProfile
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StartTypeProfileCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            public Task<Protocol.Profiler.StopResponse> Stop
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StopCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Disable precise code coverage. Disabling releases unnecessary execution count records and allows
            /// executing optimized code.
            /// </summary>
            public Task StopPreciseCoverage
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StopPreciseCoverageCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Disable type profile. Disabling releases type profile data collected so far.
            /// </summary>
            public Task StopTypeProfile
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.StopTypeProfileCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Collect coverage data for the current isolate, and resets execution counters. Precise code
            /// coverage needs to have started.
            /// </summary>
            public Task<Protocol.Profiler.TakePreciseCoverageResponse> TakePreciseCoverage
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.TakePreciseCoverageCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Collect type profile.
            /// </summary>
            public Task<Protocol.Profiler.TakeTypeProfileResponse> TakeTypeProfile
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Profiler.TakeTypeProfileCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            public event Func<Protocol.Profiler.ConsoleProfileFinishedEvent, Task> ConsoleProfileFinished
            {
                add => InspectorClient.AddEventHandler("Profiler.consoleProfileFinished", value);
                remove => InspectorClient.RemoveEventHandler("Profiler.consoleProfileFinished", value);
            }

            /// <summary>
            /// Sent when new profile recording is started using console.profile() call.
            /// </summary>
            public event Func<Protocol.Profiler.ConsoleProfileStartedEvent, Task> ConsoleProfileStarted
            {
                add => InspectorClient.AddEventHandler("Profiler.consoleProfileStarted", value);
                remove => InspectorClient.RemoveEventHandler("Profiler.consoleProfileStarted", value);
            }
        }

        public class RuntimeInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public RuntimeInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            /// <summary>
            /// Add handler to promise with given promise object id.
            /// </summary>
            /// <param name="promiseObjectId">
            /// Identifier of the promise.
            /// </param>
            /// <param name="returnByValue">
            /// Whether the result is expected to be a JSON object that should be sent by value.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the result.
            /// </param>
            public Task<Protocol.Runtime.AwaitPromiseResponse> AwaitPromise
            (
                Protocol.Runtime.RemoteObjectId @promiseObjectId, 
                bool? @returnByValue = default, 
                bool? @generatePreview = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.AwaitPromiseCommand
                    {
                        PromiseObjectId = @promiseObjectId,
                        ReturnByValue = @returnByValue,
                        GeneratePreview = @generatePreview,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Calls function with given declaration on the given object. Object group of the result is
            /// inherited from the target object.
            /// </summary>
            /// <param name="functionDeclaration">
            /// Declaration of the function to call.
            /// </param>
            /// <param name="objectId">
            /// Identifier of the object to call function on. Either objectId or executionContextId should
            /// be specified.
            /// </param>
            /// <param name="arguments">
            /// Call arguments. All call arguments must belong to the same JavaScript world as the target
            /// object.
            /// </param>
            /// <param name="silent">
            /// In silent mode exceptions thrown during evaluation are not reported and do not pause
            /// execution. Overrides `setPauseOnException` state.
            /// </param>
            /// <param name="returnByValue">
            /// Whether the result is expected to be a JSON object which should be sent by value.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the result.
            /// </param>
            /// <param name="userGesture">
            /// Whether execution should be treated as initiated by user in the UI.
            /// </param>
            /// <param name="awaitPromise">
            /// Whether execution should `await` for resulting value and return once awaited promise is
            /// resolved.
            /// </param>
            /// <param name="executionContextId">
            /// Specifies execution context which global object will be used to call function on. Either
            /// executionContextId or objectId should be specified.
            /// </param>
            /// <param name="objectGroup">
            /// Symbolic group name that can be used to release multiple objects. If objectGroup is not
            /// specified and objectId is, objectGroup will be inherited from object.
            /// </param>
            public Task<Protocol.Runtime.CallFunctionOnResponse> CallFunctionOn
            (
                string @functionDeclaration, 
                Protocol.Runtime.RemoteObjectId @objectId = default, 
                Protocol.Runtime.CallArgument[] @arguments = default, 
                bool? @silent = default, 
                bool? @returnByValue = default, 
                bool? @generatePreview = default, 
                bool? @userGesture = default, 
                bool? @awaitPromise = default, 
                Protocol.Runtime.ExecutionContextId @executionContextId = default, 
                string @objectGroup = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.CallFunctionOnCommand
                    {
                        FunctionDeclaration = @functionDeclaration,
                        ObjectId = @objectId,
                        Arguments = @arguments,
                        Silent = @silent,
                        ReturnByValue = @returnByValue,
                        GeneratePreview = @generatePreview,
                        UserGesture = @userGesture,
                        AwaitPromise = @awaitPromise,
                        ExecutionContextId = @executionContextId,
                        ObjectGroup = @objectGroup,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Compiles expression.
            /// </summary>
            /// <param name="expression">
            /// Expression to compile.
            /// </param>
            /// <param name="sourceURL">
            /// Source url to be set for the script.
            /// </param>
            /// <param name="persistScript">
            /// Specifies whether the compiled script should be persisted.
            /// </param>
            /// <param name="executionContextId">
            /// Specifies in which execution context to perform script run. If the parameter is omitted the
            /// evaluation will be performed in the context of the inspected page.
            /// </param>
            public Task<Protocol.Runtime.CompileScriptResponse> CompileScript
            (
                string @expression, 
                string @sourceURL, 
                bool @persistScript, 
                Protocol.Runtime.ExecutionContextId @executionContextId = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.CompileScriptCommand
                    {
                        Expression = @expression,
                        SourceURL = @sourceURL,
                        PersistScript = @persistScript,
                        ExecutionContextId = @executionContextId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Disables reporting of execution contexts creation.
            /// </summary>
            public Task Disable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.DisableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Discards collected exceptions and console API calls.
            /// </summary>
            public Task DiscardConsoleEntries
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.DiscardConsoleEntriesCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enables reporting of execution contexts creation by means of `executionContextCreated` event.
            /// When the reporting gets enabled the event will be sent immediately for each existing execution
            /// context.
            /// </summary>
            public Task Enable
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.EnableCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Evaluates expression on global object.
            /// </summary>
            /// <param name="expression">
            /// Expression to evaluate.
            /// </param>
            /// <param name="objectGroup">
            /// Symbolic group name that can be used to release multiple objects.
            /// </param>
            /// <param name="includeCommandLineAPI">
            /// Determines whether Command Line API should be available during the evaluation.
            /// </param>
            /// <param name="silent">
            /// In silent mode exceptions thrown during evaluation are not reported and do not pause
            /// execution. Overrides `setPauseOnException` state.
            /// </param>
            /// <param name="contextId">
            /// Specifies in which execution context to perform evaluation. If the parameter is omitted the
            /// evaluation will be performed in the context of the inspected page.
            /// </param>
            /// <param name="returnByValue">
            /// Whether the result is expected to be a JSON object that should be sent by value.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the result.
            /// </param>
            /// <param name="userGesture">
            /// Whether execution should be treated as initiated by user in the UI.
            /// </param>
            /// <param name="awaitPromise">
            /// Whether execution should `await` for resulting value and return once awaited promise is
            /// resolved.
            /// </param>
            /// <param name="throwOnSideEffect">
            /// Whether to throw an exception if side effect cannot be ruled out during evaluation.
            /// </param>
            /// <param name="timeout">
            /// Terminate execution after timing out (number of milliseconds).
            /// </param>
            public Task<Protocol.Runtime.EvaluateResponse> Evaluate
            (
                string @expression, 
                string @objectGroup = default, 
                bool? @includeCommandLineAPI = default, 
                bool? @silent = default, 
                Protocol.Runtime.ExecutionContextId @contextId = default, 
                bool? @returnByValue = default, 
                bool? @generatePreview = default, 
                bool? @userGesture = default, 
                bool? @awaitPromise = default, 
                bool? @throwOnSideEffect = default, 
                Protocol.Runtime.TimeDelta @timeout = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.EvaluateCommand
                    {
                        Expression = @expression,
                        ObjectGroup = @objectGroup,
                        IncludeCommandLineAPI = @includeCommandLineAPI,
                        Silent = @silent,
                        ContextId = @contextId,
                        ReturnByValue = @returnByValue,
                        GeneratePreview = @generatePreview,
                        UserGesture = @userGesture,
                        AwaitPromise = @awaitPromise,
                        ThrowOnSideEffect = @throwOnSideEffect,
                        Timeout = @timeout,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns the isolate id.
            /// </summary>
            public Task<Protocol.Runtime.GetIsolateIdResponse> GetIsolateId
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.GetIsolateIdCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns the JavaScript heap usage.
            /// It is the total usage of the corresponding isolate not scoped to a particular Runtime.
            /// </summary>
            public Task<Protocol.Runtime.GetHeapUsageResponse> GetHeapUsage
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.GetHeapUsageCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns properties of a given object. Object group of the result is inherited from the target
            /// object.
            /// </summary>
            /// <param name="objectId">
            /// Identifier of the object to return properties for.
            /// </param>
            /// <param name="ownProperties">
            /// If true, returns properties belonging only to the element itself, not to its prototype
            /// chain.
            /// </param>
            /// <param name="accessorPropertiesOnly">
            /// If true, returns accessor properties (with getter/setter) only; internal properties are not
            /// returned either.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the results.
            /// </param>
            public Task<Protocol.Runtime.GetPropertiesResponse> GetProperties
            (
                Protocol.Runtime.RemoteObjectId @objectId, 
                bool? @ownProperties = default, 
                bool? @accessorPropertiesOnly = default, 
                bool? @generatePreview = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.GetPropertiesCommand
                    {
                        ObjectId = @objectId,
                        OwnProperties = @ownProperties,
                        AccessorPropertiesOnly = @accessorPropertiesOnly,
                        GeneratePreview = @generatePreview,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Returns all let, const and class variables from global scope.
            /// </summary>
            /// <param name="executionContextId">
            /// Specifies in which execution context to lookup global scope variables.
            /// </param>
            public Task<Protocol.Runtime.GlobalLexicalScopeNamesResponse> GlobalLexicalScopeNames
            (
                Protocol.Runtime.ExecutionContextId @executionContextId = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.GlobalLexicalScopeNamesCommand
                    {
                        ExecutionContextId = @executionContextId,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="prototypeObjectId">
            /// Identifier of the prototype to return objects for.
            /// </param>
            /// <param name="objectGroup">
            /// Symbolic group name that can be used to release the results.
            /// </param>
            public Task<Protocol.Runtime.QueryObjectsResponse> QueryObjects
            (
                Protocol.Runtime.RemoteObjectId @prototypeObjectId, 
                string @objectGroup = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.QueryObjectsCommand
                    {
                        PrototypeObjectId = @prototypeObjectId,
                        ObjectGroup = @objectGroup,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Releases remote object with given id.
            /// </summary>
            /// <param name="objectId">
            /// Identifier of the object to release.
            /// </param>
            public Task ReleaseObject
            (
                Protocol.Runtime.RemoteObjectId @objectId, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.ReleaseObjectCommand
                    {
                        ObjectId = @objectId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Releases all remote objects that belong to a given group.
            /// </summary>
            /// <param name="objectGroup">
            /// Symbolic object group name.
            /// </param>
            public Task ReleaseObjectGroup
            (
                string @objectGroup, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.ReleaseObjectGroupCommand
                    {
                        ObjectGroup = @objectGroup,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Tells inspected instance to run if it was waiting for debugger to attach.
            /// </summary>
            public Task RunIfWaitingForDebugger
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.RunIfWaitingForDebuggerCommand
                    {
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Runs script with given id in a given context.
            /// </summary>
            /// <param name="scriptId">
            /// Id of the script to run.
            /// </param>
            /// <param name="executionContextId">
            /// Specifies in which execution context to perform script run. If the parameter is omitted the
            /// evaluation will be performed in the context of the inspected page.
            /// </param>
            /// <param name="objectGroup">
            /// Symbolic group name that can be used to release multiple objects.
            /// </param>
            /// <param name="silent">
            /// In silent mode exceptions thrown during evaluation are not reported and do not pause
            /// execution. Overrides `setPauseOnException` state.
            /// </param>
            /// <param name="includeCommandLineAPI">
            /// Determines whether Command Line API should be available during the evaluation.
            /// </param>
            /// <param name="returnByValue">
            /// Whether the result is expected to be a JSON object which should be sent by value.
            /// </param>
            /// <param name="generatePreview">
            /// Whether preview should be generated for the result.
            /// </param>
            /// <param name="awaitPromise">
            /// Whether execution should `await` for resulting value and return once awaited promise is
            /// resolved.
            /// </param>
            public Task<Protocol.Runtime.RunScriptResponse> RunScript
            (
                Protocol.Runtime.ScriptId @scriptId, 
                Protocol.Runtime.ExecutionContextId @executionContextId = default, 
                string @objectGroup = default, 
                bool? @silent = default, 
                bool? @includeCommandLineAPI = default, 
                bool? @returnByValue = default, 
                bool? @generatePreview = default, 
                bool? @awaitPromise = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.RunScriptCommand
                    {
                        ScriptId = @scriptId,
                        ExecutionContextId = @executionContextId,
                        ObjectGroup = @objectGroup,
                        Silent = @silent,
                        IncludeCommandLineAPI = @includeCommandLineAPI,
                        ReturnByValue = @returnByValue,
                        GeneratePreview = @generatePreview,
                        AwaitPromise = @awaitPromise,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            /// <param name="maxDepth">
            /// Maximum depth of async call stacks. Setting to `0` will effectively disable collecting async
            /// call stacks (default).
            /// </param>
            public Task SetAsyncCallStackDepth
            (
                int @maxDepth, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.SetAsyncCallStackDepthCommand
                    {
                        MaxDepth = @maxDepth,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="enabled" />
            public Task SetCustomObjectFormatterEnabled
            (
                bool @enabled, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.SetCustomObjectFormatterEnabledCommand
                    {
                        Enabled = @enabled,
                    }
                    , cancellation
                )
                ;
            }

            /// <param name="size" />
            public Task SetMaxCallStackSizeToCapture
            (
                int @size, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.SetMaxCallStackSizeToCaptureCommand
                    {
                        Size = @size,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Terminate current or next JavaScript execution.
            /// Will cancel the termination when the outer-most script execution ends.
            /// </summary>
            public Task TerminateExecution
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.TerminateExecutionCommand
                    {
                    }
                    , cancellation
                )
                ;
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
            /// <param name="name" />
            /// <param name="executionContextId" />
            public Task AddBinding
            (
                string @name, 
                Protocol.Runtime.ExecutionContextId @executionContextId = default, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.AddBindingCommand
                    {
                        Name = @name,
                        ExecutionContextId = @executionContextId,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// This method does not remove binding function from global object but
            /// unsubscribes current runtime agent from Runtime.bindingCalled notifications.
            /// </summary>
            /// <param name="name" />
            public Task RemoveBinding
            (
                string @name, 
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Runtime.RemoveBindingCommand
                    {
                        Name = @name,
                    }
                    , cancellation
                )
                ;
            }

            /// <summary>
            /// Notification is issued every time when binding is called.
            /// </summary>
            public event Func<Protocol.Runtime.BindingCalledEvent, Task> BindingCalled
            {
                add => InspectorClient.AddEventHandler("Runtime.bindingCalled", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.bindingCalled", value);
            }

            /// <summary>
            /// Issued when console API was called.
            /// </summary>
            public event Func<Protocol.Runtime.ConsoleAPICalledEvent, Task> ConsoleAPICalled
            {
                add => InspectorClient.AddEventHandler("Runtime.consoleAPICalled", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.consoleAPICalled", value);
            }

            /// <summary>
            /// Issued when unhandled exception was revoked.
            /// </summary>
            public event Func<Protocol.Runtime.ExceptionRevokedEvent, Task> ExceptionRevoked
            {
                add => InspectorClient.AddEventHandler("Runtime.exceptionRevoked", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.exceptionRevoked", value);
            }

            /// <summary>
            /// Issued when exception was thrown and unhandled.
            /// </summary>
            public event Func<Protocol.Runtime.ExceptionThrownEvent, Task> ExceptionThrown
            {
                add => InspectorClient.AddEventHandler("Runtime.exceptionThrown", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.exceptionThrown", value);
            }

            /// <summary>
            /// Issued when new execution context is created.
            /// </summary>
            public event Func<Protocol.Runtime.ExecutionContextCreatedEvent, Task> ExecutionContextCreated
            {
                add => InspectorClient.AddEventHandler("Runtime.executionContextCreated", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.executionContextCreated", value);
            }

            /// <summary>
            /// Issued when execution context is destroyed.
            /// </summary>
            public event Func<Protocol.Runtime.ExecutionContextDestroyedEvent, Task> ExecutionContextDestroyed
            {
                add => InspectorClient.AddEventHandler("Runtime.executionContextDestroyed", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.executionContextDestroyed", value);
            }

            /// <summary>
            /// Issued when all executionContexts were cleared in browser
            /// </summary>
            public event Func<Protocol.Runtime.ExecutionContextsClearedEvent, Task> ExecutionContextsCleared
            {
                add => InspectorClient.AddEventHandler("Runtime.executionContextsCleared", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.executionContextsCleared", value);
            }

            /// <summary>
            /// Issued when object should be inspected (for example, as a result of inspect() command line API
            /// call).
            /// </summary>
            public event Func<Protocol.Runtime.InspectRequestedEvent, Task> InspectRequested
            {
                add => InspectorClient.AddEventHandler("Runtime.inspectRequested", value);
                remove => InspectorClient.RemoveEventHandler("Runtime.inspectRequested", value);
            }
        }

        [Obsolete]
        public class SchemaInspectorClient
        {
            private readonly InspectorClient InspectorClient;

            public SchemaInspectorClient(InspectorClient inspectionClient)
            {
                InspectorClient = inspectionClient;
            }

            /// <summary>
            /// Returns supported domains.
            /// </summary>
            public Task<Protocol.Schema.GetDomainsResponse> GetDomains
            (
                CancellationToken cancellation = default
            )
            {
                return InspectorClient.InvokeCommand
                (
                    new Protocol.Schema.GetDomainsCommand
                    {
                    }
                    , cancellation
                )
                ;
            }
        }
    }
}
