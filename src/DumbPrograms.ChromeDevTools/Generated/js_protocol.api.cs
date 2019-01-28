using System;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    partial class InspectionClient
    {

        /// <summary>
        /// This domain is deprecated - use Runtime or Log instead.
        /// </summary>
        public ConsoleInspectionClient Console => __Console ?? (__Console = new ConsoleInspectionClient(this));
        private ConsoleInspectionClient __Console;

        /// <summary>
        /// Debugger domain exposes JavaScript debugging capabilities. It allows setting and removing
        /// breakpoints, stepping through execution, exploring stack traces, etc.
        /// </summary>
        public DebuggerInspectionClient Debugger => __Debugger ?? (__Debugger = new DebuggerInspectionClient(this));
        private DebuggerInspectionClient __Debugger;

        public HeapProfilerInspectionClient HeapProfiler => __HeapProfiler ?? (__HeapProfiler = new HeapProfilerInspectionClient(this));
        private HeapProfilerInspectionClient __HeapProfiler;

        public ProfilerInspectionClient Profiler => __Profiler ?? (__Profiler = new ProfilerInspectionClient(this));
        private ProfilerInspectionClient __Profiler;

        /// <summary>
        /// Runtime domain exposes JavaScript runtime by means of remote evaluation and mirror objects.
        /// Evaluation results are returned as mirror object that expose object type, string representation
        /// and unique identifier that can be used for further object reference. Original objects are
        /// maintained in memory unless they are either explicitly released or are released along with the
        /// other objects in their object group.
        /// </summary>
        public RuntimeInspectionClient Runtime => __Runtime ?? (__Runtime = new RuntimeInspectionClient(this));
        private RuntimeInspectionClient __Runtime;

        /// <summary>
        /// This domain is deprecated.
        /// </summary>
        public SchemaInspectionClient Schema => __Schema ?? (__Schema = new SchemaInspectionClient(this));
        private SchemaInspectionClient __Schema;

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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables console domain, prevents further console messages from being reported to the client.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables console domain, sends the messages collected so far to the client by means of the
            /// `messageAdded` notification.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables debugger for given page.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables debugger for the given page. Clients should not assume that the debugging has been
            /// enabled until the result for this command is received.
            /// </summary>
            public Task<Protocol.Debugger.EnableResponse> Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Evaluates expression on a given call frame.
            /// </summary>
            public Task<Protocol.Debugger.EvaluateOnCallFrameResponse> EvaluateOnCallFrame()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns possible locations for breakpoint. scriptId in start and end range locations should be
            /// the same.
            /// </summary>
            public Task<Protocol.Debugger.GetPossibleBreakpointsResponse> GetPossibleBreakpoints()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns source for the script with given id.
            /// </summary>
            public Task<Protocol.Debugger.GetScriptSourceResponse> GetScriptSource()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns stack trace with given `stackTraceId`.
            /// </summary>
            public Task<Protocol.Debugger.GetStackTraceResponse> GetStackTrace()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stops on the next JavaScript statement.
            /// </summary>
            public Task Pause()
            {
                throw new NotImplementedException();
            }

            public Task PauseOnAsyncCall()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes JavaScript breakpoint.
            /// </summary>
            public Task RemoveBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Restarts particular call frame from the beginning.
            /// </summary>
            public Task<Protocol.Debugger.RestartFrameResponse> RestartFrame()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Resumes JavaScript execution.
            /// </summary>
            public Task Resume()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Searches for given string in script content.
            /// </summary>
            public Task<Protocol.Debugger.SearchInContentResponse> SearchInContent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            public Task SetAsyncCallStackDepth()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Replace previous blackbox patterns with passed ones. Forces backend to skip stepping/pausing in
            /// scripts with url matching one of the patterns. VM will try to leave blackboxed script by
            /// performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// </summary>
            public Task SetBlackboxPatterns()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Makes backend skip steps in the script in blackboxed ranges. VM will try leave blacklisted
            /// scripts by performing 'step in' several times, finally resorting to 'step out' if unsuccessful.
            /// Positions array contains positions where blackbox state is changed. First interval isn't
            /// blackboxed. Array should be sorted.
            /// </summary>
            public Task SetBlackboxedRanges()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets JavaScript breakpoint at a given location.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointResponse> SetBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
            /// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
            /// `locations` property. Further matching script parsing will result in subsequent
            /// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointByUrlResponse> SetBreakpointByUrl()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets JavaScript breakpoint before each call to the given function.
            /// If another function was created from the same source as a given one,
            /// calling it will also trigger the breakpoint.
            /// </summary>
            public Task<Protocol.Debugger.SetBreakpointOnFunctionCallResponse> SetBreakpointOnFunctionCall()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Activates / deactivates all breakpoints on the page.
            /// </summary>
            public Task SetBreakpointsActive()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or
            /// no exceptions. Initial pause on exceptions state is `none`.
            /// </summary>
            public Task SetPauseOnExceptions()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Changes return value in top frame. Available only at return break position.
            /// </summary>
            public Task SetReturnValue()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Edits JavaScript source live.
            /// </summary>
            public Task<Protocol.Debugger.SetScriptSourceResponse> SetScriptSource()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Makes page not interrupt on any pauses (breakpoint, exception, dom exception etc).
            /// </summary>
            public Task SetSkipAllPauses()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Changes value of variable in a callframe. Object-based scopes are not supported and must be
            /// mutated manually.
            /// </summary>
            public Task SetVariableValue()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Steps into the function call.
            /// </summary>
            public Task StepInto()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Steps out of the function call.
            /// </summary>
            public Task StepOut()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Steps over the statement.
            /// </summary>
            public Task StepOver()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public Task CollectGarbage()
            {
                throw new NotImplementedException();
            }

            public Task Disable()
            {
                throw new NotImplementedException();
            }

            public Task Enable()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.HeapProfiler.GetHeapObjectIdResponse> GetHeapObjectId()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.HeapProfiler.GetObjectByHeapObjectIdResponse> GetObjectByHeapObjectId()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.HeapProfiler.GetSamplingProfileResponse> GetSamplingProfile()
            {
                throw new NotImplementedException();
            }

            public Task StartSampling()
            {
                throw new NotImplementedException();
            }

            public Task StartTrackingHeapObjects()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.HeapProfiler.StopSamplingResponse> StopSampling()
            {
                throw new NotImplementedException();
            }

            public Task StopTrackingHeapObjects()
            {
                throw new NotImplementedException();
            }

            public Task TakeHeapSnapshot()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Collect coverage data for the current isolate. The coverage data may be incomplete due to
            /// garbage collection.
            /// </summary>
            public Task<Protocol.Profiler.GetBestEffortCoverageResponse> GetBestEffortCoverage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Changes CPU profiler sampling interval. Must be called before CPU profiles recording started.
            /// </summary>
            public Task SetSamplingInterval()
            {
                throw new NotImplementedException();
            }

            public Task Start()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable precise code coverage. Coverage data for JavaScript executed before enabling precise code
            /// coverage may be incomplete. Enabling prevents running optimized code and resets execution
            /// counters.
            /// </summary>
            public Task StartPreciseCoverage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable type profile.
            /// </summary>
            public Task StartTypeProfile()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.Profiler.StopResponse> Stop()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disable precise code coverage. Disabling releases unnecessary execution count records and allows
            /// executing optimized code.
            /// </summary>
            public Task StopPreciseCoverage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disable type profile. Disabling releases type profile data collected so far.
            /// </summary>
            public Task StopTypeProfile()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Collect coverage data for the current isolate, and resets execution counters. Precise code
            /// coverage needs to have started.
            /// </summary>
            public Task<Protocol.Profiler.TakePreciseCoverageResponse> TakePreciseCoverage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Collect type profile.
            /// </summary>
            public Task<Protocol.Profiler.TakeTypeProfileResponse> TakeTypeProfile()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Calls function with given declaration on the given object. Object group of the result is
            /// inherited from the target object.
            /// </summary>
            public Task<Protocol.Runtime.CallFunctionOnResponse> CallFunctionOn()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Compiles expression.
            /// </summary>
            public Task<Protocol.Runtime.CompileScriptResponse> CompileScript()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables reporting of execution contexts creation.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Discards collected exceptions and console API calls.
            /// </summary>
            public Task DiscardConsoleEntries()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables reporting of execution contexts creation by means of `executionContextCreated` event.
            /// When the reporting gets enabled the event will be sent immediately for each existing execution
            /// context.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Evaluates expression on global object.
            /// </summary>
            public Task<Protocol.Runtime.EvaluateResponse> Evaluate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the isolate id.
            /// </summary>
            public Task<Protocol.Runtime.GetIsolateIdResponse> GetIsolateId()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the JavaScript heap usage.
            /// It is the total usage of the corresponding isolate not scoped to a particular Runtime.
            /// </summary>
            public Task<Protocol.Runtime.GetHeapUsageResponse> GetHeapUsage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns properties of a given object. Object group of the result is inherited from the target
            /// object.
            /// </summary>
            public Task<Protocol.Runtime.GetPropertiesResponse> GetProperties()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all let, const and class variables from global scope.
            /// </summary>
            public Task<Protocol.Runtime.GlobalLexicalScopeNamesResponse> GlobalLexicalScopeNames()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.Runtime.QueryObjectsResponse> QueryObjects()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Releases remote object with given id.
            /// </summary>
            public Task ReleaseObject()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Releases all remote objects that belong to a given group.
            /// </summary>
            public Task ReleaseObjectGroup()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Tells inspected instance to run if it was waiting for debugger to attach.
            /// </summary>
            public Task RunIfWaitingForDebugger()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Runs script with given id in a given context.
            /// </summary>
            public Task<Protocol.Runtime.RunScriptResponse> RunScript()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables or disables async call stacks tracking.
            /// </summary>
            public Task SetAsyncCallStackDepth()
            {
                throw new NotImplementedException();
            }

            public Task SetCustomObjectFormatterEnabled()
            {
                throw new NotImplementedException();
            }

            public Task SetMaxCallStackSizeToCapture()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Terminate current or next JavaScript execution.
            /// Will cancel the termination when the outer-most script execution ends.
            /// </summary>
            public Task TerminateExecution()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method does not remove binding function from global object but
            /// unsubscribes current runtime agent from Runtime.bindingCalled notifications.
            /// </summary>
            public Task RemoveBinding()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}
