using System;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    partial class InspectionClient
    {

        /// <summary>
        /// This domain is deprecated - use Runtime or Log instead.
        /// </summary>
        public ConsoleInspectionClient Console => __Console__ ?? (__Console__ = new ConsoleInspectionClient(this));
        private ConsoleInspectionClient __Console__;

        /// <summary>
        /// Debugger domain exposes JavaScript debugging capabilities. It allows setting and removing
        /// breakpoints, stepping through execution, exploring stack traces, etc.
        /// </summary>
        public DebuggerInspectionClient Debugger => __Debugger__ ?? (__Debugger__ = new DebuggerInspectionClient(this));
        private DebuggerInspectionClient __Debugger__;

        public HeapProfilerInspectionClient HeapProfiler => __HeapProfiler__ ?? (__HeapProfiler__ = new HeapProfilerInspectionClient(this));
        private HeapProfilerInspectionClient __HeapProfiler__;

        public ProfilerInspectionClient Profiler => __Profiler__ ?? (__Profiler__ = new ProfilerInspectionClient(this));
        private ProfilerInspectionClient __Profiler__;

        /// <summary>
        /// Runtime domain exposes JavaScript runtime by means of remote evaluation and mirror objects.
        /// Evaluation results are returned as mirror object that expose object type, string representation
        /// and unique identifier that can be used for further object reference. Original objects are
        /// maintained in memory unless they are either explicitly released or are released along with the
        /// other objects in their object group.
        /// </summary>
        public RuntimeInspectionClient Runtime => __Runtime__ ?? (__Runtime__ = new RuntimeInspectionClient(this));
        private RuntimeInspectionClient __Runtime__;

        /// <summary>
        /// This domain is deprecated.
        /// </summary>
        public SchemaInspectionClient Schema => __Schema__ ?? (__Schema__ = new SchemaInspectionClient(this));
        private SchemaInspectionClient __Schema__;

        public class ConsoleInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public ConsoleInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Does nothing.
            /// </summary>
            public Task ClearMessages()
            {
                return InspectionClient.InvokeCommand(new Protocol.Console.ClearMessagesCommand { });
            }

            /// <summary>
            /// Disables console domain, prevents further console messages from being reported to the client.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Console.DisableCommand { });
            }

            /// <summary>
            /// Enables console domain, sends the messages collected so far to the client by means of the
            /// `messageAdded` notification.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Console.EnableCommand { });
            }
        }

        public class DebuggerInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DebuggerInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Continues execution until specific location is reached.
            /// </summary>
            public Task ContinueToLocation()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.ContinueToLocationCommand { });
            }

            /// <summary>
            /// Disables debugger for given page.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.DisableCommand { });
            }

            /// <summary>
            /// Enables debugger for the given page. Clients should not assume that the debugging has been
            /// enabled until the result for this command is received.
            /// </summary>
            public Task<Protocol.Debugger.EnableResponse> Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.EnableCommand { });
            }

            /// <summary>
            /// Evaluates expression on a given call frame.
            /// </summary>
            public Task<Protocol.Debugger.EvaluateOnCallFrameResponse> EvaluateOnCallFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.EvaluateOnCallFrameCommand { });
            }

            /// <summary>
            /// Returns possible locations for breakpoint. scriptId in start and end range locations should be
            /// the same.
            /// </summary>
            public Task<Protocol.Debugger.GetPossibleBreakpointsResponse> GetPossibleBreakpoints()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.GetPossibleBreakpointsCommand { });
            }

            /// <summary>
            /// Returns source for the script with given id.
            /// </summary>
            public Task<Protocol.Debugger.GetScriptSourceResponse> GetScriptSource()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.GetScriptSourceCommand { });
            }

            /// <summary>
            /// Returns stack trace with given `stackTraceId`.
            /// </summary>
            public Task<Protocol.Debugger.GetStackTraceResponse> GetStackTrace()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.GetStackTraceCommand { });
            }

            /// <summary>
            /// Stops on the next JavaScript statement.
            /// </summary>
            public Task Pause()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.PauseCommand { });
            }

            public Task PauseOnAsyncCall()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.PauseOnAsyncCallCommand { });
            }

            /// <summary>
            /// Removes JavaScript breakpoint.
            /// </summary>
            public Task RemoveBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.RemoveBreakpointCommand { });
            }

            /// <summary>
            /// Restarts particular call frame from the beginning.
            /// </summary>
            public Task<Protocol.Debugger.RestartFrameResponse> RestartFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.RestartFrameCommand { });
            }

            /// <summary>
            /// Resumes JavaScript execution.
            /// </summary>
            public Task Resume()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.ResumeCommand { });
            }

            /// <summary>
            /// Searches for given string in script content.
            /// </summary>
            public Task<Protocol.Debugger.SearchInContentResponse> SearchInContent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SearchInContentCommand { });
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            public Task SetAsyncCallStackDepth()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetAsyncCallStackDepthCommand { });
            }

            /// <summary>
            /// Replace previous blackbox patterns with passed ones. Forces backend to skip stepping/pausing in
            /// scripts with url matching one of the patterns. VM will try to leave blackboxed script by
            /// performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// </summary>
            public Task SetBlackboxPatterns()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBlackboxPatternsCommand { });
            }

            /// <summary>
            /// Makes backend skip steps in the script in blackboxed ranges. VM will try leave blacklisted
            /// scripts by performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// Positions array contains positions where blackbox state is changed. First interval isn't
            /// blackboxed. Array should be sorted.
            /// </summary>
            public Task SetBlackboxedRanges()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBlackboxedRangesCommand { });
            }

            /// <summary>
            /// Sets JavaScript breakpoint at a given location.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointResponse> SetBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBreakpointCommand { });
            }

            /// <summary>
            /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
            /// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
            /// `locations` property. Further matching script parsing will result in subsequent
            /// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointByUrlResponse> SetBreakpointByUrl()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBreakpointByUrlCommand { });
            }

            /// <summary>
            /// Sets JavaScript breakpoint before each call to the given function.
            /// If another function was created from the same source as a given one,
            /// calling it will also trigger the breakpoint.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointOnFunctionCallResponse> SetBreakpointOnFunctionCall()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBreakpointOnFunctionCallCommand { });
            }

            /// <summary>
            /// Activates / deactivates all breakpoints on the page.
            /// </summary>
            public Task SetBreakpointsActive()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetBreakpointsActiveCommand { });
            }

            /// <summary>
            /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or
            /// no exceptions. Initial pause on exceptions state is `none`.
            /// </summary>
            public Task SetPauseOnExceptions()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetPauseOnExceptionsCommand { });
            }

            /// <summary>
            /// Changes return value in top frame. Available only at return break position.
            /// </summary>
            public Task SetReturnValue()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetReturnValueCommand { });
            }

            /// <summary>
            /// Edits JavaScript source live.
            /// </summary>
            public Task<Protocol.Debugger.SetScriptSourceResponse> SetScriptSource()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetScriptSourceCommand { });
            }

            /// <summary>
            /// Makes page not interrupt on any pauses (breakpoint, exception, dom exception etc).
            /// </summary>
            public Task SetSkipAllPauses()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetSkipAllPausesCommand { });
            }

            /// <summary>
            /// Changes value of variable in a callframe. Object-based scopes are not supported and must be
            /// mutated manually.
            /// </summary>
            public Task SetVariableValue()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.SetVariableValueCommand { });
            }

            /// <summary>
            /// Steps into the function call.
            /// </summary>
            public Task StepInto()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.StepIntoCommand { });
            }

            /// <summary>
            /// Steps out of the function call.
            /// </summary>
            public Task StepOut()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.StepOutCommand { });
            }

            /// <summary>
            /// Steps over the statement.
            /// </summary>
            public Task StepOver()
            {
                return InspectionClient.InvokeCommand(new Protocol.Debugger.StepOverCommand { });
            }
        }

        public class HeapProfilerInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public HeapProfilerInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Enables console to refer to the node with given id via $x (see Command Line API for more details
            /// $x functions).
            /// </summary>
            public Task AddInspectedHeapObject()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.AddInspectedHeapObjectCommand { });
            }

            public Task CollectGarbage()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.CollectGarbageCommand { });
            }

            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.DisableCommand { });
            }

            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.EnableCommand { });
            }

            public Task<Protocol.HeapProfiler.GetHeapObjectIdResponse> GetHeapObjectId()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.GetHeapObjectIdCommand { });
            }

            public Task<Protocol.HeapProfiler.GetObjectByHeapObjectIdResponse> GetObjectByHeapObjectId()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.GetObjectByHeapObjectIdCommand { });
            }

            public Task<Protocol.HeapProfiler.GetSamplingProfileResponse> GetSamplingProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.GetSamplingProfileCommand { });
            }

            public Task StartSampling()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.StartSamplingCommand { });
            }

            public Task StartTrackingHeapObjects()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.StartTrackingHeapObjectsCommand { });
            }

            public Task<Protocol.HeapProfiler.StopSamplingResponse> StopSampling()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.StopSamplingCommand { });
            }

            public Task StopTrackingHeapObjects()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.StopTrackingHeapObjectsCommand { });
            }

            public Task TakeHeapSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeapProfiler.TakeHeapSnapshotCommand { });
            }
        }

        public class ProfilerInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public ProfilerInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.DisableCommand { });
            }

            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.EnableCommand { });
            }

            /// <summary>
            /// Collect coverage data for the current isolate. The coverage data may be incomplete due to
            /// garbage collection.
            /// </summary>
            public Task<Protocol.Profiler.GetBestEffortCoverageResponse> GetBestEffortCoverage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.GetBestEffortCoverageCommand { });
            }

            /// <summary>
            /// Changes CPU profiler sampling interval. Must be called before CPU profiles recording started.
            /// </summary>
            public Task SetSamplingInterval()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.SetSamplingIntervalCommand { });
            }

            public Task Start()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StartCommand { });
            }

            /// <summary>
            /// Enable precise code coverage. Coverage data for JavaScript executed before enabling precise code
            /// coverage may be incomplete. Enabling prevents running optimized code and resets execution
            /// counters.
            /// </summary>
            public Task StartPreciseCoverage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StartPreciseCoverageCommand { });
            }

            /// <summary>
            /// Enable type profile.
            /// </summary>
            public Task StartTypeProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StartTypeProfileCommand { });
            }

            public Task<Protocol.Profiler.StopResponse> Stop()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StopCommand { });
            }

            /// <summary>
            /// Disable precise code coverage. Disabling releases unnecessary execution count records and allows
            /// executing optimized code.
            /// </summary>
            public Task StopPreciseCoverage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StopPreciseCoverageCommand { });
            }

            /// <summary>
            /// Disable type profile. Disabling releases type profile data collected so far.
            /// </summary>
            public Task StopTypeProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.StopTypeProfileCommand { });
            }

            /// <summary>
            /// Collect coverage data for the current isolate, and resets execution counters. Precise code
            /// coverage needs to have started.
            /// </summary>
            public Task<Protocol.Profiler.TakePreciseCoverageResponse> TakePreciseCoverage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.TakePreciseCoverageCommand { });
            }

            /// <summary>
            /// Collect type profile.
            /// </summary>
            public Task<Protocol.Profiler.TakeTypeProfileResponse> TakeTypeProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Profiler.TakeTypeProfileCommand { });
            }
        }

        public class RuntimeInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public RuntimeInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Add handler to promise with given promise object id.
            /// </summary>
            public Task<Protocol.Runtime.AwaitPromiseResponse> AwaitPromise()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.AwaitPromiseCommand { });
            }

            /// <summary>
            /// Calls function with given declaration on the given object. Object group of the result is
            /// inherited from the target object.
            /// </summary>
            public Task<Protocol.Runtime.CallFunctionOnResponse> CallFunctionOn()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.CallFunctionOnCommand { });
            }

            /// <summary>
            /// Compiles expression.
            /// </summary>
            public Task<Protocol.Runtime.CompileScriptResponse> CompileScript()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.CompileScriptCommand { });
            }

            /// <summary>
            /// Disables reporting of execution contexts creation.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.DisableCommand { });
            }

            /// <summary>
            /// Discards collected exceptions and console API calls.
            /// </summary>
            public Task DiscardConsoleEntries()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.DiscardConsoleEntriesCommand { });
            }

            /// <summary>
            /// Enables reporting of execution contexts creation by means of `executionContextCreated` event.
            /// When the reporting gets enabled the event will be sent immediately for each existing execution
            /// context.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.EnableCommand { });
            }

            /// <summary>
            /// Evaluates expression on global object.
            /// </summary>
            public Task<Protocol.Runtime.EvaluateResponse> Evaluate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.EvaluateCommand { });
            }

            /// <summary>
            /// Returns the isolate id.
            /// </summary>
            public Task<Protocol.Runtime.GetIsolateIdResponse> GetIsolateId()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.GetIsolateIdCommand { });
            }

            /// <summary>
            /// Returns the JavaScript heap usage.
            /// It is the total usage of the corresponding isolate not scoped to a particular Runtime.
            /// </summary>
            public Task<Protocol.Runtime.GetHeapUsageResponse> GetHeapUsage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.GetHeapUsageCommand { });
            }

            /// <summary>
            /// Returns properties of a given object. Object group of the result is inherited from the target
            /// object.
            /// </summary>
            public Task<Protocol.Runtime.GetPropertiesResponse> GetProperties()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.GetPropertiesCommand { });
            }

            /// <summary>
            /// Returns all let, const and class variables from global scope.
            /// </summary>
            public Task<Protocol.Runtime.GlobalLexicalScopeNamesResponse> GlobalLexicalScopeNames()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.GlobalLexicalScopeNamesCommand { });
            }

            public Task<Protocol.Runtime.QueryObjectsResponse> QueryObjects()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.QueryObjectsCommand { });
            }

            /// <summary>
            /// Releases remote object with given id.
            /// </summary>
            public Task ReleaseObject()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.ReleaseObjectCommand { });
            }

            /// <summary>
            /// Releases all remote objects that belong to a given group.
            /// </summary>
            public Task ReleaseObjectGroup()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.ReleaseObjectGroupCommand { });
            }

            /// <summary>
            /// Tells inspected instance to run if it was waiting for debugger to attach.
            /// </summary>
            public Task RunIfWaitingForDebugger()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.RunIfWaitingForDebuggerCommand { });
            }

            /// <summary>
            /// Runs script with given id in a given context.
            /// </summary>
            public Task<Protocol.Runtime.RunScriptResponse> RunScript()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.RunScriptCommand { });
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            public Task SetAsyncCallStackDepth()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.SetAsyncCallStackDepthCommand { });
            }

            public Task SetCustomObjectFormatterEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.SetCustomObjectFormatterEnabledCommand { });
            }

            public Task SetMaxCallStackSizeToCapture()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.SetMaxCallStackSizeToCaptureCommand { });
            }

            /// <summary>
            /// Terminate current or next JavaScript execution.
            /// Will cancel the termination when the outer-most script execution ends.
            /// </summary>
            public Task TerminateExecution()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.TerminateExecutionCommand { });
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
            public Task AddBinding()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.AddBindingCommand { });
            }

            /// <summary>
            /// This method does not remove binding function from global object but
            /// unsubscribes current runtime agent from Runtime.bindingCalled notifications.
            /// </summary>
            public Task RemoveBinding()
            {
                return InspectionClient.InvokeCommand(new Protocol.Runtime.RemoveBindingCommand { });
            }
        }

        public class SchemaInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public SchemaInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Returns supported domains.
            /// </summary>
            public Task<Protocol.Schema.GetDomainsResponse> GetDomains()
            {
                return InspectionClient.InvokeCommand(new Protocol.Schema.GetDomainsCommand { });
            }
        }
    }
}
