using System;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    partial class InspectionClient
    {

        public AccessibilityInspectionClient Accessibility => __Accessibility__ ?? (__Accessibility__ = new AccessibilityInspectionClient(this));
        private AccessibilityInspectionClient __Accessibility__;

        public AnimationInspectionClient Animation => __Animation__ ?? (__Animation__ = new AnimationInspectionClient(this));
        private AnimationInspectionClient __Animation__;

        public ApplicationCacheInspectionClient ApplicationCache => __ApplicationCache__ ?? (__ApplicationCache__ = new ApplicationCacheInspectionClient(this));
        private ApplicationCacheInspectionClient __ApplicationCache__;

        /// <summary>
        /// Audits domain allows investigation of page violations and possible improvements.
        /// </summary>
        public AuditsInspectionClient Audits => __Audits__ ?? (__Audits__ = new AuditsInspectionClient(this));
        private AuditsInspectionClient __Audits__;

        /// <summary>
        /// The Browser domain defines methods and events for browser managing.
        /// </summary>
        public BrowserInspectionClient Browser => __Browser__ ?? (__Browser__ = new BrowserInspectionClient(this));
        private BrowserInspectionClient __Browser__;

        /// <summary>
        /// This domain exposes CSS read/write operations. All CSS objects (stylesheets, rules, and styles)
        /// have an associated `id` used in subsequent operations on the related object. Each object type has
        /// a specific `id` structure, and those are not interchangeable between objects of different kinds.
        /// CSS objects can be loaded using the `get*ForNode()` calls (which accept a DOM node id). A client
        /// can also keep track of stylesheets via the `styleSheetAdded`/`styleSheetRemoved` events and
        /// subsequently load the required stylesheet contents using the `getStyleSheet[Text]()` methods.
        /// </summary>
        public CSSInspectionClient CSS => __CSS__ ?? (__CSS__ = new CSSInspectionClient(this));
        private CSSInspectionClient __CSS__;

        public CacheStorageInspectionClient CacheStorage => __CacheStorage__ ?? (__CacheStorage__ = new CacheStorageInspectionClient(this));
        private CacheStorageInspectionClient __CacheStorage__;

        /// <summary>
        /// A domain for interacting with Cast, Presentation API, and Remote Playback API
        /// functionalities.
        /// </summary>
        public CastInspectionClient Cast => __Cast__ ?? (__Cast__ = new CastInspectionClient(this));
        private CastInspectionClient __Cast__;

        /// <summary>
        /// This domain exposes DOM read/write operations. Each DOM Node is represented with its mirror object
        /// that has an `id`. This `id` can be used to get additional information on the Node, resolve it into
        /// the JavaScript object wrapper, etc. It is important that client receives DOM events only for the
        /// nodes that are known to the client. Backend keeps track of the nodes that were sent to the client
        /// and never sends the same node twice. It is client's responsibility to collect information about
        /// the nodes that were sent to the client.&lt;p&gt;Note that `iframe` owner elements will return
        /// corresponding document elements as their child nodes.&lt;/p&gt;
        /// </summary>
        public DOMInspectionClient DOM => __DOM__ ?? (__DOM__ = new DOMInspectionClient(this));
        private DOMInspectionClient __DOM__;

        /// <summary>
        /// DOM debugging allows setting breakpoints on particular DOM operations and events. JavaScript
        /// execution will stop on these operations as if there was a regular breakpoint set.
        /// </summary>
        public DOMDebuggerInspectionClient DOMDebugger => __DOMDebugger__ ?? (__DOMDebugger__ = new DOMDebuggerInspectionClient(this));
        private DOMDebuggerInspectionClient __DOMDebugger__;

        /// <summary>
        /// This domain facilitates obtaining document snapshots with DOM, layout, and style information.
        /// </summary>
        public DOMSnapshotInspectionClient DOMSnapshot => __DOMSnapshot__ ?? (__DOMSnapshot__ = new DOMSnapshotInspectionClient(this));
        private DOMSnapshotInspectionClient __DOMSnapshot__;

        /// <summary>
        /// Query and modify DOM storage.
        /// </summary>
        public DOMStorageInspectionClient DOMStorage => __DOMStorage__ ?? (__DOMStorage__ = new DOMStorageInspectionClient(this));
        private DOMStorageInspectionClient __DOMStorage__;

        public DatabaseInspectionClient Database => __Database__ ?? (__Database__ = new DatabaseInspectionClient(this));
        private DatabaseInspectionClient __Database__;

        public DeviceOrientationInspectionClient DeviceOrientation => __DeviceOrientation__ ?? (__DeviceOrientation__ = new DeviceOrientationInspectionClient(this));
        private DeviceOrientationInspectionClient __DeviceOrientation__;

        /// <summary>
        /// This domain emulates different environments for the page.
        /// </summary>
        public EmulationInspectionClient Emulation => __Emulation__ ?? (__Emulation__ = new EmulationInspectionClient(this));
        private EmulationInspectionClient __Emulation__;

        /// <summary>
        /// This domain provides experimental commands only supported in headless mode.
        /// </summary>
        public HeadlessExperimentalInspectionClient HeadlessExperimental => __HeadlessExperimental__ ?? (__HeadlessExperimental__ = new HeadlessExperimentalInspectionClient(this));
        private HeadlessExperimentalInspectionClient __HeadlessExperimental__;

        /// <summary>
        /// Input/Output operations for streams produced by DevTools.
        /// </summary>
        public IOInspectionClient IO => __IO__ ?? (__IO__ = new IOInspectionClient(this));
        private IOInspectionClient __IO__;

        public IndexedDBInspectionClient IndexedDB => __IndexedDB__ ?? (__IndexedDB__ = new IndexedDBInspectionClient(this));
        private IndexedDBInspectionClient __IndexedDB__;

        public InputInspectionClient Input => __Input__ ?? (__Input__ = new InputInspectionClient(this));
        private InputInspectionClient __Input__;

        public InspectorInspectionClient Inspector => __Inspector__ ?? (__Inspector__ = new InspectorInspectionClient(this));
        private InspectorInspectionClient __Inspector__;

        public LayerTreeInspectionClient LayerTree => __LayerTree__ ?? (__LayerTree__ = new LayerTreeInspectionClient(this));
        private LayerTreeInspectionClient __LayerTree__;

        /// <summary>
        /// Provides access to log entries.
        /// </summary>
        public LogInspectionClient Log => __Log__ ?? (__Log__ = new LogInspectionClient(this));
        private LogInspectionClient __Log__;

        public MemoryInspectionClient Memory => __Memory__ ?? (__Memory__ = new MemoryInspectionClient(this));
        private MemoryInspectionClient __Memory__;

        /// <summary>
        /// Network domain allows tracking network activities of the page. It exposes information about http,
        /// file, data and other requests and responses, their headers, bodies, timing, etc.
        /// </summary>
        public NetworkInspectionClient Network => __Network__ ?? (__Network__ = new NetworkInspectionClient(this));
        private NetworkInspectionClient __Network__;

        /// <summary>
        /// This domain provides various functionality related to drawing atop the inspected page.
        /// </summary>
        public OverlayInspectionClient Overlay => __Overlay__ ?? (__Overlay__ = new OverlayInspectionClient(this));
        private OverlayInspectionClient __Overlay__;

        /// <summary>
        /// Actions and events related to the inspected page belong to the page domain.
        /// </summary>
        public PageInspectionClient Page => __Page__ ?? (__Page__ = new PageInspectionClient(this));
        private PageInspectionClient __Page__;

        public PerformanceInspectionClient Performance => __Performance__ ?? (__Performance__ = new PerformanceInspectionClient(this));
        private PerformanceInspectionClient __Performance__;

        /// <summary>
        /// Security
        /// </summary>
        public SecurityInspectionClient Security => __Security__ ?? (__Security__ = new SecurityInspectionClient(this));
        private SecurityInspectionClient __Security__;

        public ServiceWorkerInspectionClient ServiceWorker => __ServiceWorker__ ?? (__ServiceWorker__ = new ServiceWorkerInspectionClient(this));
        private ServiceWorkerInspectionClient __ServiceWorker__;

        public StorageInspectionClient Storage => __Storage__ ?? (__Storage__ = new StorageInspectionClient(this));
        private StorageInspectionClient __Storage__;

        /// <summary>
        /// The SystemInfo domain defines methods and events for querying low-level system information.
        /// </summary>
        public SystemInfoInspectionClient SystemInfo => __SystemInfo__ ?? (__SystemInfo__ = new SystemInfoInspectionClient(this));
        private SystemInfoInspectionClient __SystemInfo__;

        /// <summary>
        /// Supports additional targets discovery and allows to attach to them.
        /// </summary>
        public TargetInspectionClient Target => __Target__ ?? (__Target__ = new TargetInspectionClient(this));
        private TargetInspectionClient __Target__;

        /// <summary>
        /// The Tethering domain defines methods and events for browser port binding.
        /// </summary>
        public TetheringInspectionClient Tethering => __Tethering__ ?? (__Tethering__ = new TetheringInspectionClient(this));
        private TetheringInspectionClient __Tethering__;

        public TracingInspectionClient Tracing => __Tracing__ ?? (__Tracing__ = new TracingInspectionClient(this));
        private TracingInspectionClient __Tracing__;

        /// <summary>
        /// Testing domain is a dumping ground for the capabilities requires for browser or app testing that do not fit other
        /// domains.
        /// </summary>
        public TestingInspectionClient Testing => __Testing__ ?? (__Testing__ = new TestingInspectionClient(this));
        private TestingInspectionClient __Testing__;

        /// <summary>
        /// A domain for letting clients substitute browser's network layer with client code.
        /// </summary>
        public FetchInspectionClient Fetch => __Fetch__ ?? (__Fetch__ = new FetchInspectionClient(this));
        private FetchInspectionClient __Fetch__;

        public class AccessibilityInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public AccessibilityInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables the accessibility domain.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Accessibility.DisableCommand { });
            }

            /// <summary>
            /// Enables the accessibility domain which causes `AXNodeId`s to remain consistent between method calls.
            /// This turns on accessibility for the page, which can impact performance until accessibility is disabled.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Accessibility.EnableCommand { });
            }

            /// <summary>
            /// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
            /// </summary>
            public Task<Protocol.Accessibility.GetPartialAXTreeResponse> GetPartialAXTree()
            {
                return InspectionClient.InvokeCommand(new Protocol.Accessibility.GetPartialAXTreeCommand { });
            }

            /// <summary>
            /// Fetches the entire accessibility tree
            /// </summary>
            public Task<Protocol.Accessibility.GetFullAXTreeResponse> GetFullAXTree()
            {
                return InspectionClient.InvokeCommand(new Protocol.Accessibility.GetFullAXTreeCommand { });
            }
        }

        public class AnimationInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public AnimationInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables animation domain notifications.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.DisableCommand { });
            }

            /// <summary>
            /// Enables animation domain notifications.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.EnableCommand { });
            }

            /// <summary>
            /// Returns the current time of the an animation.
            /// </summary>
            public Task<Protocol.Animation.GetCurrentTimeResponse> GetCurrentTime()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.GetCurrentTimeCommand { });
            }

            /// <summary>
            /// Gets the playback rate of the document timeline.
            /// </summary>
            public Task<Protocol.Animation.GetPlaybackRateResponse> GetPlaybackRate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.GetPlaybackRateCommand { });
            }

            /// <summary>
            /// Releases a set of animations to no longer be manipulated.
            /// </summary>
            public Task ReleaseAnimations()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.ReleaseAnimationsCommand { });
            }

            /// <summary>
            /// Gets the remote object of the Animation.
            /// </summary>
            public Task<Protocol.Animation.ResolveAnimationResponse> ResolveAnimation()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.ResolveAnimationCommand { });
            }

            /// <summary>
            /// Seek a set of animations to a particular time within each animation.
            /// </summary>
            public Task SeekAnimations()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.SeekAnimationsCommand { });
            }

            /// <summary>
            /// Sets the paused state of a set of animations.
            /// </summary>
            public Task SetPaused()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.SetPausedCommand { });
            }

            /// <summary>
            /// Sets the playback rate of the document timeline.
            /// </summary>
            public Task SetPlaybackRate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.SetPlaybackRateCommand { });
            }

            /// <summary>
            /// Sets the timing of an animation node.
            /// </summary>
            public Task SetTiming()
            {
                return InspectionClient.InvokeCommand(new Protocol.Animation.SetTimingCommand { });
            }
        }

        public class ApplicationCacheInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public ApplicationCacheInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Enables application cache domain notifications.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.ApplicationCache.EnableCommand { });
            }

            /// <summary>
            /// Returns relevant application cache data for the document in given frame.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetApplicationCacheForFrameResponse> GetApplicationCacheForFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.ApplicationCache.GetApplicationCacheForFrameCommand { });
            }

            /// <summary>
            /// Returns array of frame identifiers with manifest urls for each frame containing a document
            /// associated with some application cache.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetFramesWithManifestsResponse> GetFramesWithManifests()
            {
                return InspectionClient.InvokeCommand(new Protocol.ApplicationCache.GetFramesWithManifestsCommand { });
            }

            /// <summary>
            /// Returns manifest URL for document in the given frame.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetManifestForFrameResponse> GetManifestForFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.ApplicationCache.GetManifestForFrameCommand { });
            }
        }

        public class AuditsInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public AuditsInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Returns the response body and size if it were re-encoded with the specified settings. Only
            /// applies to images.
            /// </summary>
            public Task<Protocol.Audits.GetEncodedResponseResponse> GetEncodedResponse()
            {
                return InspectionClient.InvokeCommand(new Protocol.Audits.GetEncodedResponseCommand { });
            }
        }

        public class BrowserInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public BrowserInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Grant specific permissions to the given origin and reject all others.
            /// </summary>
            public Task GrantPermissions()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GrantPermissionsCommand { });
            }

            /// <summary>
            /// Reset all permission management for all origins.
            /// </summary>
            public Task ResetPermissions()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.ResetPermissionsCommand { });
            }

            /// <summary>
            /// Close browser gracefully.
            /// </summary>
            public Task Close()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.CloseCommand { });
            }

            /// <summary>
            /// Crashes browser on the main thread.
            /// </summary>
            public Task Crash()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.CrashCommand { });
            }

            /// <summary>
            /// Returns version information.
            /// </summary>
            public Task<Protocol.Browser.GetVersionResponse> GetVersion()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetVersionCommand { });
            }

            /// <summary>
            /// Returns the command line switches for the browser process if, and only if
            /// --enable-automation is on the commandline.
            /// </summary>
            public Task<Protocol.Browser.GetBrowserCommandLineResponse> GetBrowserCommandLine()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetBrowserCommandLineCommand { });
            }

            /// <summary>
            /// Get Chrome histograms.
            /// </summary>
            public Task<Protocol.Browser.GetHistogramsResponse> GetHistograms()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetHistogramsCommand { });
            }

            /// <summary>
            /// Get a Chrome histogram by name.
            /// </summary>
            public Task<Protocol.Browser.GetHistogramResponse> GetHistogram()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetHistogramCommand { });
            }

            /// <summary>
            /// Get position and size of the browser window.
            /// </summary>
            public Task<Protocol.Browser.GetWindowBoundsResponse> GetWindowBounds()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetWindowBoundsCommand { });
            }

            /// <summary>
            /// Get the browser window that contains the devtools target.
            /// </summary>
            public Task<Protocol.Browser.GetWindowForTargetResponse> GetWindowForTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.GetWindowForTargetCommand { });
            }

            /// <summary>
            /// Set position and/or size of the browser window.
            /// </summary>
            public Task SetWindowBounds()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.SetWindowBoundsCommand { });
            }

            /// <summary>
            /// Set dock tile details, platform-specific.
            /// </summary>
            public Task SetDockTile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Browser.SetDockTileCommand { });
            }
        }

        public class CSSInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public CSSInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Inserts a new rule with the given `ruleText` in a stylesheet with given `styleSheetId`, at the
            /// position specified by `location`.
            /// </summary>
            public Task<Protocol.CSS.AddRuleResponse> AddRule()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.AddRuleCommand { });
            }

            /// <summary>
            /// Returns all class names from specified stylesheet.
            /// </summary>
            public Task<Protocol.CSS.CollectClassNamesResponse> CollectClassNames()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.CollectClassNamesCommand { });
            }

            /// <summary>
            /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
            /// </summary>
            public Task<Protocol.CSS.CreateStyleSheetResponse> CreateStyleSheet()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.CreateStyleSheetCommand { });
            }

            /// <summary>
            /// Disables the CSS agent for the given page.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.DisableCommand { });
            }

            /// <summary>
            /// Enables the CSS agent for the given page. Clients should not assume that the CSS agent has been
            /// enabled until the result of this command is received.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.EnableCommand { });
            }

            /// <summary>
            /// Ensures that the given node will have specified pseudo-classes whenever its style is computed by
            /// the browser.
            /// </summary>
            public Task ForcePseudoState()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.ForcePseudoStateCommand { });
            }

            public Task<Protocol.CSS.GetBackgroundColorsResponse> GetBackgroundColors()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetBackgroundColorsCommand { });
            }

            /// <summary>
            /// Returns the computed style for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetComputedStyleForNodeResponse> GetComputedStyleForNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetComputedStyleForNodeCommand { });
            }

            /// <summary>
            /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
            /// attributes) for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetInlineStylesForNodeResponse> GetInlineStylesForNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetInlineStylesForNodeCommand { });
            }

            /// <summary>
            /// Returns requested styles for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetMatchedStylesForNodeResponse> GetMatchedStylesForNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetMatchedStylesForNodeCommand { });
            }

            /// <summary>
            /// Returns all media queries parsed by the rendering engine.
            /// </summary>
            public Task<Protocol.CSS.GetMediaQueriesResponse> GetMediaQueries()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetMediaQueriesCommand { });
            }

            /// <summary>
            /// Requests information about platform fonts which we used to render child TextNodes in the given
            /// node.
            /// </summary>
            public Task<Protocol.CSS.GetPlatformFontsForNodeResponse> GetPlatformFontsForNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetPlatformFontsForNodeCommand { });
            }

            /// <summary>
            /// Returns the current textual content for a stylesheet.
            /// </summary>
            public Task<Protocol.CSS.GetStyleSheetTextResponse> GetStyleSheetText()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.GetStyleSheetTextCommand { });
            }

            /// <summary>
            /// Find a rule with the given active property for the given node and set the new value for this
            /// property
            /// </summary>
            public Task SetEffectivePropertyValueForNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetEffectivePropertyValueForNodeCommand { });
            }

            /// <summary>
            /// Modifies the keyframe rule key text.
            /// </summary>
            public Task<Protocol.CSS.SetKeyframeKeyResponse> SetKeyframeKey()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetKeyframeKeyCommand { });
            }

            /// <summary>
            /// Modifies the rule selector.
            /// </summary>
            public Task<Protocol.CSS.SetMediaTextResponse> SetMediaText()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetMediaTextCommand { });
            }

            /// <summary>
            /// Modifies the rule selector.
            /// </summary>
            public Task<Protocol.CSS.SetRuleSelectorResponse> SetRuleSelector()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetRuleSelectorCommand { });
            }

            /// <summary>
            /// Sets the new stylesheet text.
            /// </summary>
            public Task<Protocol.CSS.SetStyleSheetTextResponse> SetStyleSheetText()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetStyleSheetTextCommand { });
            }

            /// <summary>
            /// Applies specified style edits one after another in the given order.
            /// </summary>
            public Task<Protocol.CSS.SetStyleTextsResponse> SetStyleTexts()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.SetStyleTextsCommand { });
            }

            /// <summary>
            /// Enables the selector recording.
            /// </summary>
            public Task StartRuleUsageTracking()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.StartRuleUsageTrackingCommand { });
            }

            /// <summary>
            /// Stop tracking rule usage and return the list of rules that were used since last call to
            /// `takeCoverageDelta` (or since start of coverage instrumentation)
            /// </summary>
            public Task<Protocol.CSS.StopRuleUsageTrackingResponse> StopRuleUsageTracking()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.StopRuleUsageTrackingCommand { });
            }

            /// <summary>
            /// Obtain list of rules that became used since last call to this method (or since start of coverage
            /// instrumentation)
            /// </summary>
            public Task<Protocol.CSS.TakeCoverageDeltaResponse> TakeCoverageDelta()
            {
                return InspectionClient.InvokeCommand(new Protocol.CSS.TakeCoverageDeltaCommand { });
            }
        }

        public class CacheStorageInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public CacheStorageInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Deletes a cache.
            /// </summary>
            public Task DeleteCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.CacheStorage.DeleteCacheCommand { });
            }

            /// <summary>
            /// Deletes a cache entry.
            /// </summary>
            public Task DeleteEntry()
            {
                return InspectionClient.InvokeCommand(new Protocol.CacheStorage.DeleteEntryCommand { });
            }

            /// <summary>
            /// Requests cache names.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestCacheNamesResponse> RequestCacheNames()
            {
                return InspectionClient.InvokeCommand(new Protocol.CacheStorage.RequestCacheNamesCommand { });
            }

            /// <summary>
            /// Fetches cache entry.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestCachedResponseResponse> RequestCachedResponse()
            {
                return InspectionClient.InvokeCommand(new Protocol.CacheStorage.RequestCachedResponseCommand { });
            }

            /// <summary>
            /// Requests data from cache.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestEntriesResponse> RequestEntries()
            {
                return InspectionClient.InvokeCommand(new Protocol.CacheStorage.RequestEntriesCommand { });
            }
        }

        public class CastInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public CastInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Starts observing for sinks that can be used for tab mirroring, and if set,
            /// sinks compatible with |presentationUrl| as well. When sinks are found, a
            /// |sinksUpdated| event is fired.
            /// Also starts observing for issue messages. When an issue is added or removed,
            /// an |issueUpdated| event is fired.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Cast.EnableCommand { });
            }

            /// <summary>
            /// Stops observing for sinks and issues.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Cast.DisableCommand { });
            }

            /// <summary>
            /// Sets a sink to be used when the web page requests the browser to choose a
            /// sink via Presentation API, Remote Playback API, or Cast SDK.
            /// </summary>
            public Task SetSinkToUse()
            {
                return InspectionClient.InvokeCommand(new Protocol.Cast.SetSinkToUseCommand { });
            }

            /// <summary>
            /// Starts mirroring the tab to the sink.
            /// </summary>
            public Task StartTabMirroring()
            {
                return InspectionClient.InvokeCommand(new Protocol.Cast.StartTabMirroringCommand { });
            }

            /// <summary>
            /// Stops the active Cast session on the sink.
            /// </summary>
            public Task StopCasting()
            {
                return InspectionClient.InvokeCommand(new Protocol.Cast.StopCastingCommand { });
            }
        }

        public class DOMInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DOMInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Collects class names for the node with given id and all of it's child nodes.
            /// </summary>
            public Task<Protocol.DOM.CollectClassNamesFromSubtreeResponse> CollectClassNamesFromSubtree()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.CollectClassNamesFromSubtreeCommand { });
            }

            /// <summary>
            /// Creates a deep copy of the specified node and places it into the target container before the
            /// given anchor.
            /// </summary>
            public Task<Protocol.DOM.CopyToResponse> CopyTo()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.CopyToCommand { });
            }

            /// <summary>
            /// Describes node given its id, does not require domain to be enabled. Does not start tracking any
            /// objects, can be used for automation.
            /// </summary>
            public Task<Protocol.DOM.DescribeNodeResponse> DescribeNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.DescribeNodeCommand { });
            }

            /// <summary>
            /// Disables DOM agent for the given page.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.DisableCommand { });
            }

            /// <summary>
            /// Discards search results from the session with the given id. `getSearchResults` should no longer
            /// be called for that search.
            /// </summary>
            public Task DiscardSearchResults()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.DiscardSearchResultsCommand { });
            }

            /// <summary>
            /// Enables DOM agent for the given page.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.EnableCommand { });
            }

            /// <summary>
            /// Focuses the given element.
            /// </summary>
            public Task Focus()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.FocusCommand { });
            }

            /// <summary>
            /// Returns attributes for the specified node.
            /// </summary>
            public Task<Protocol.DOM.GetAttributesResponse> GetAttributes()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetAttributesCommand { });
            }

            /// <summary>
            /// Returns boxes for the given node.
            /// </summary>
            public Task<Protocol.DOM.GetBoxModelResponse> GetBoxModel()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetBoxModelCommand { });
            }

            /// <summary>
            /// Returns quads that describe node position on the page. This method
            /// might return multiple quads for inline nodes.
            /// </summary>
            public Task<Protocol.DOM.GetContentQuadsResponse> GetContentQuads()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetContentQuadsCommand { });
            }

            /// <summary>
            /// Returns the root DOM node (and optionally the subtree) to the caller.
            /// </summary>
            public Task<Protocol.DOM.GetDocumentResponse> GetDocument()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetDocumentCommand { });
            }

            /// <summary>
            /// Returns the root DOM node (and optionally the subtree) to the caller.
            /// </summary>
            public Task<Protocol.DOM.GetFlattenedDocumentResponse> GetFlattenedDocument()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetFlattenedDocumentCommand { });
            }

            /// <summary>
            /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
            /// either returned or not.
            /// </summary>
            public Task<Protocol.DOM.GetNodeForLocationResponse> GetNodeForLocation()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetNodeForLocationCommand { });
            }

            /// <summary>
            /// Returns node's HTML markup.
            /// </summary>
            public Task<Protocol.DOM.GetOuterHTMLResponse> GetOuterHTML()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetOuterHTMLCommand { });
            }

            /// <summary>
            /// Returns the id of the nearest ancestor that is a relayout boundary.
            /// </summary>
            public Task<Protocol.DOM.GetRelayoutBoundaryResponse> GetRelayoutBoundary()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetRelayoutBoundaryCommand { });
            }

            /// <summary>
            /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
            /// identifier.
            /// </summary>
            public Task<Protocol.DOM.GetSearchResultsResponse> GetSearchResults()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetSearchResultsCommand { });
            }

            /// <summary>
            /// Hides any highlight.
            /// </summary>
            public Task HideHighlight()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.HideHighlightCommand { });
            }

            /// <summary>
            /// Highlights DOM node.
            /// </summary>
            public Task HighlightNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.HighlightNodeCommand { });
            }

            /// <summary>
            /// Highlights given rectangle.
            /// </summary>
            public Task HighlightRect()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.HighlightRectCommand { });
            }

            /// <summary>
            /// Marks last undoable state.
            /// </summary>
            public Task MarkUndoableState()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.MarkUndoableStateCommand { });
            }

            /// <summary>
            /// Moves node into the new container, places it before the given anchor.
            /// </summary>
            public Task<Protocol.DOM.MoveToResponse> MoveTo()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.MoveToCommand { });
            }

            /// <summary>
            /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
            /// `cancelSearch` to end this search session.
            /// </summary>
            public Task<Protocol.DOM.PerformSearchResponse> PerformSearch()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.PerformSearchCommand { });
            }

            /// <summary>
            /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
            /// </summary>
            public Task<Protocol.DOM.PushNodeByPathToFrontendResponse> PushNodeByPathToFrontend()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.PushNodeByPathToFrontendCommand { });
            }

            /// <summary>
            /// Requests that a batch of nodes is sent to the caller given their backend node ids.
            /// </summary>
            public Task<Protocol.DOM.PushNodesByBackendIdsToFrontendResponse> PushNodesByBackendIdsToFrontend()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.PushNodesByBackendIdsToFrontendCommand { });
            }

            /// <summary>
            /// Executes `querySelector` on a given node.
            /// </summary>
            public Task<Protocol.DOM.QuerySelectorResponse> QuerySelector()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.QuerySelectorCommand { });
            }

            /// <summary>
            /// Executes `querySelectorAll` on a given node.
            /// </summary>
            public Task<Protocol.DOM.QuerySelectorAllResponse> QuerySelectorAll()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.QuerySelectorAllCommand { });
            }

            /// <summary>
            /// Re-does the last undone action.
            /// </summary>
            public Task Redo()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.RedoCommand { });
            }

            /// <summary>
            /// Removes attribute with given name from an element with given id.
            /// </summary>
            public Task RemoveAttribute()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.RemoveAttributeCommand { });
            }

            /// <summary>
            /// Removes node with given id.
            /// </summary>
            public Task RemoveNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.RemoveNodeCommand { });
            }

            /// <summary>
            /// Requests that children of the node with given id are returned to the caller in form of
            /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
            /// the specified depth.
            /// </summary>
            public Task RequestChildNodes()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.RequestChildNodesCommand { });
            }

            /// <summary>
            /// Requests that the node is sent to the caller given the JavaScript node object reference. All
            /// nodes that form the path from the node to the root are also sent to the client as a series of
            /// `setChildNodes` notifications.
            /// </summary>
            public Task<Protocol.DOM.RequestNodeResponse> RequestNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.RequestNodeCommand { });
            }

            /// <summary>
            /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
            /// </summary>
            public Task<Protocol.DOM.ResolveNodeResponse> ResolveNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.ResolveNodeCommand { });
            }

            /// <summary>
            /// Sets attribute for an element with given id.
            /// </summary>
            public Task SetAttributeValue()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetAttributeValueCommand { });
            }

            /// <summary>
            /// Sets attributes on element with given id. This method is useful when user edits some existing
            /// attribute value and types in several attribute name/value pairs.
            /// </summary>
            public Task SetAttributesAsText()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetAttributesAsTextCommand { });
            }

            /// <summary>
            /// Sets files for the given file input element.
            /// </summary>
            public Task SetFileInputFiles()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetFileInputFilesCommand { });
            }

            /// <summary>
            /// Returns file information for the given
            /// File wrapper.
            /// </summary>
            public Task<Protocol.DOM.GetFileInfoResponse> GetFileInfo()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetFileInfoCommand { });
            }

            /// <summary>
            /// Enables console to refer to the node with given id via $x (see Command Line API for more details
            /// $x functions).
            /// </summary>
            public Task SetInspectedNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetInspectedNodeCommand { });
            }

            /// <summary>
            /// Sets node name for a node with given id.
            /// </summary>
            public Task<Protocol.DOM.SetNodeNameResponse> SetNodeName()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetNodeNameCommand { });
            }

            /// <summary>
            /// Sets node value for a node with given id.
            /// </summary>
            public Task SetNodeValue()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetNodeValueCommand { });
            }

            /// <summary>
            /// Sets node HTML markup, returns new node id.
            /// </summary>
            public Task SetOuterHTML()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.SetOuterHTMLCommand { });
            }

            /// <summary>
            /// Undoes the last performed action.
            /// </summary>
            public Task Undo()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.UndoCommand { });
            }

            /// <summary>
            /// Returns iframe node that owns iframe with the given domain.
            /// </summary>
            public Task<Protocol.DOM.GetFrameOwnerResponse> GetFrameOwner()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOM.GetFrameOwnerCommand { });
            }
        }

        public class DOMDebuggerInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DOMDebuggerInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Returns event listeners of the given object.
            /// </summary>
            public Task<Protocol.DOMDebugger.GetEventListenersResponse> GetEventListeners()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.GetEventListenersCommand { });
            }

            /// <summary>
            /// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
            /// </summary>
            public Task RemoveDOMBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.RemoveDOMBreakpointCommand { });
            }

            /// <summary>
            /// Removes breakpoint on particular DOM event.
            /// </summary>
            public Task RemoveEventListenerBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.RemoveEventListenerBreakpointCommand { });
            }

            /// <summary>
            /// Removes breakpoint on particular native event.
            /// </summary>
            public Task RemoveInstrumentationBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.RemoveInstrumentationBreakpointCommand { });
            }

            /// <summary>
            /// Removes breakpoint from XMLHttpRequest.
            /// </summary>
            public Task RemoveXHRBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.RemoveXHRBreakpointCommand { });
            }

            /// <summary>
            /// Sets breakpoint on particular operation with DOM.
            /// </summary>
            public Task SetDOMBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.SetDOMBreakpointCommand { });
            }

            /// <summary>
            /// Sets breakpoint on particular DOM event.
            /// </summary>
            public Task SetEventListenerBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.SetEventListenerBreakpointCommand { });
            }

            /// <summary>
            /// Sets breakpoint on particular native event.
            /// </summary>
            public Task SetInstrumentationBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.SetInstrumentationBreakpointCommand { });
            }

            /// <summary>
            /// Sets breakpoint on XMLHttpRequest.
            /// </summary>
            public Task SetXHRBreakpoint()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMDebugger.SetXHRBreakpointCommand { });
            }
        }

        public class DOMSnapshotInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DOMSnapshotInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables DOM snapshot agent for the given page.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMSnapshot.DisableCommand { });
            }

            /// <summary>
            /// Enables DOM snapshot agent for the given page.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMSnapshot.EnableCommand { });
            }

            /// <summary>
            /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
            /// template contents, and imported documents) in a flattened array, as well as layout and
            /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
            /// flattened.
            /// </summary>
            [Obsolete]
            public Task<Protocol.DOMSnapshot.GetSnapshotResponse> GetSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMSnapshot.GetSnapshotCommand { });
            }

            /// <summary>
            /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
            /// template contents, and imported documents) in a flattened array, as well as layout and
            /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
            /// flattened.
            /// </summary>
            public Task<Protocol.DOMSnapshot.CaptureSnapshotResponse> CaptureSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMSnapshot.CaptureSnapshotCommand { });
            }
        }

        public class DOMStorageInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DOMStorageInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            public Task Clear()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.ClearCommand { });
            }

            /// <summary>
            /// Disables storage tracking, prevents storage events from being sent to the client.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.DisableCommand { });
            }

            /// <summary>
            /// Enables storage tracking, storage events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.EnableCommand { });
            }

            public Task<Protocol.DOMStorage.GetDOMStorageItemsResponse> GetDOMStorageItems()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.GetDOMStorageItemsCommand { });
            }

            public Task RemoveDOMStorageItem()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.RemoveDOMStorageItemCommand { });
            }

            public Task SetDOMStorageItem()
            {
                return InspectionClient.InvokeCommand(new Protocol.DOMStorage.SetDOMStorageItemCommand { });
            }
        }

        public class DatabaseInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DatabaseInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables database tracking, prevents database events from being sent to the client.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Database.DisableCommand { });
            }

            /// <summary>
            /// Enables database tracking, database events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Database.EnableCommand { });
            }

            public Task<Protocol.Database.ExecuteSQLResponse> ExecuteSQL()
            {
                return InspectionClient.InvokeCommand(new Protocol.Database.ExecuteSQLCommand { });
            }

            public Task<Protocol.Database.GetDatabaseTableNamesResponse> GetDatabaseTableNames()
            {
                return InspectionClient.InvokeCommand(new Protocol.Database.GetDatabaseTableNamesCommand { });
            }
        }

        public class DeviceOrientationInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public DeviceOrientationInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Clears the overridden Device Orientation.
            /// </summary>
            public Task ClearDeviceOrientationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.DeviceOrientation.ClearDeviceOrientationOverrideCommand { });
            }

            /// <summary>
            /// Overrides the Device Orientation.
            /// </summary>
            public Task SetDeviceOrientationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.DeviceOrientation.SetDeviceOrientationOverrideCommand { });
            }
        }

        public class EmulationInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public EmulationInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Tells whether emulation is supported.
            /// </summary>
            public Task<Protocol.Emulation.CanEmulateResponse> CanEmulate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.CanEmulateCommand { });
            }

            /// <summary>
            /// Clears the overriden device metrics.
            /// </summary>
            public Task ClearDeviceMetricsOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.ClearDeviceMetricsOverrideCommand { });
            }

            /// <summary>
            /// Clears the overriden Geolocation Position and Error.
            /// </summary>
            public Task ClearGeolocationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.ClearGeolocationOverrideCommand { });
            }

            /// <summary>
            /// Requests that page scale factor is reset to initial values.
            /// </summary>
            public Task ResetPageScaleFactor()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.ResetPageScaleFactorCommand { });
            }

            /// <summary>
            /// Enables or disables simulating a focused and active page.
            /// </summary>
            public Task SetFocusEmulationEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetFocusEmulationEnabledCommand { });
            }

            /// <summary>
            /// Enables CPU throttling to emulate slow CPUs.
            /// </summary>
            public Task SetCPUThrottlingRate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetCPUThrottlingRateCommand { });
            }

            /// <summary>
            /// Sets or clears an override of the default background color of the frame. This override is used
            /// if the content does not specify one.
            /// </summary>
            public Task SetDefaultBackgroundColorOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetDefaultBackgroundColorOverrideCommand { });
            }

            /// <summary>
            /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
            /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
            /// query results).
            /// </summary>
            public Task SetDeviceMetricsOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetDeviceMetricsOverrideCommand { });
            }

            public Task SetScrollbarsHidden()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetScrollbarsHiddenCommand { });
            }

            public Task SetDocumentCookieDisabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetDocumentCookieDisabledCommand { });
            }

            public Task SetEmitTouchEventsForMouse()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetEmitTouchEventsForMouseCommand { });
            }

            /// <summary>
            /// Emulates the given media for CSS media queries.
            /// </summary>
            public Task SetEmulatedMedia()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetEmulatedMediaCommand { });
            }

            /// <summary>
            /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
            /// unavailable.
            /// </summary>
            public Task SetGeolocationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetGeolocationOverrideCommand { });
            }

            /// <summary>
            /// Overrides value returned by the javascript navigator object.
            /// </summary>
            [Obsolete]
            public Task SetNavigatorOverrides()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetNavigatorOverridesCommand { });
            }

            /// <summary>
            /// Sets a specified page scale factor.
            /// </summary>
            public Task SetPageScaleFactor()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetPageScaleFactorCommand { });
            }

            /// <summary>
            /// Switches script execution in the page.
            /// </summary>
            public Task SetScriptExecutionDisabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetScriptExecutionDisabledCommand { });
            }

            /// <summary>
            /// Enables touch on platforms which do not support them.
            /// </summary>
            public Task SetTouchEmulationEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetTouchEmulationEnabledCommand { });
            }

            /// <summary>
            /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
            /// the current virtual time policy.  Note this supersedes any previous time budget.
            /// </summary>
            public Task<Protocol.Emulation.SetVirtualTimePolicyResponse> SetVirtualTimePolicy()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetVirtualTimePolicyCommand { });
            }

            /// <summary>
            /// Resizes the frame/viewport of the page. Note that this does not affect the frame's container
            /// (e.g. browser window). Can be used to produce screenshots of the specified size. Not supported
            /// on Android.
            /// </summary>
            [Obsolete]
            public Task SetVisibleSize()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetVisibleSizeCommand { });
            }

            /// <summary>
            /// Allows overriding user agent with the given string.
            /// </summary>
            public Task SetUserAgentOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Emulation.SetUserAgentOverrideCommand { });
            }
        }

        public class HeadlessExperimentalInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public HeadlessExperimentalInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Sends a BeginFrame to the target and returns when the frame was completed. Optionally captures a
            /// screenshot from the resulting frame. Requires that the target was created with enabled
            /// BeginFrameControl. Designed for use with --run-all-compositor-stages-before-draw, see also
            /// https://goo.gl/3zHXhB for more background.
            /// </summary>
            public Task<Protocol.HeadlessExperimental.BeginFrameResponse> BeginFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeadlessExperimental.BeginFrameCommand { });
            }

            /// <summary>
            /// Disables headless events for the target.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeadlessExperimental.DisableCommand { });
            }

            /// <summary>
            /// Enables headless events for the target.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.HeadlessExperimental.EnableCommand { });
            }
        }

        public class IOInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public IOInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Close the stream, discard any temporary backing storage.
            /// </summary>
            public Task Close()
            {
                return InspectionClient.InvokeCommand(new Protocol.IO.CloseCommand { });
            }

            /// <summary>
            /// Read a chunk of the stream
            /// </summary>
            public Task<Protocol.IO.ReadResponse> Read()
            {
                return InspectionClient.InvokeCommand(new Protocol.IO.ReadCommand { });
            }

            /// <summary>
            /// Return UUID of Blob object specified by a remote object id.
            /// </summary>
            public Task<Protocol.IO.ResolveBlobResponse> ResolveBlob()
            {
                return InspectionClient.InvokeCommand(new Protocol.IO.ResolveBlobCommand { });
            }
        }

        public class IndexedDBInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public IndexedDBInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Clears all entries from an object store.
            /// </summary>
            public Task ClearObjectStore()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.ClearObjectStoreCommand { });
            }

            /// <summary>
            /// Deletes a database.
            /// </summary>
            public Task DeleteDatabase()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.DeleteDatabaseCommand { });
            }

            /// <summary>
            /// Delete a range of entries from an object store
            /// </summary>
            public Task DeleteObjectStoreEntries()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.DeleteObjectStoreEntriesCommand { });
            }

            /// <summary>
            /// Disables events from backend.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.DisableCommand { });
            }

            /// <summary>
            /// Enables events from backend.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.EnableCommand { });
            }

            /// <summary>
            /// Requests data from object store or index.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDataResponse> RequestData()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.RequestDataCommand { });
            }

            /// <summary>
            /// Requests database with given name in given frame.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDatabaseResponse> RequestDatabase()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.RequestDatabaseCommand { });
            }

            /// <summary>
            /// Requests database names for given security origin.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDatabaseNamesResponse> RequestDatabaseNames()
            {
                return InspectionClient.InvokeCommand(new Protocol.IndexedDB.RequestDatabaseNamesCommand { });
            }
        }

        public class InputInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public InputInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Dispatches a key event to the page.
            /// </summary>
            public Task DispatchKeyEvent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.DispatchKeyEventCommand { });
            }

            /// <summary>
            /// This method emulates inserting text that doesn't come from a key press,
            /// for example an emoji keyboard or an IME.
            /// </summary>
            public Task InsertText()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.InsertTextCommand { });
            }

            /// <summary>
            /// Dispatches a mouse event to the page.
            /// </summary>
            public Task DispatchMouseEvent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.DispatchMouseEventCommand { });
            }

            /// <summary>
            /// Dispatches a touch event to the page.
            /// </summary>
            public Task DispatchTouchEvent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.DispatchTouchEventCommand { });
            }

            /// <summary>
            /// Emulates touch event from the mouse event parameters.
            /// </summary>
            public Task EmulateTouchFromMouseEvent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.EmulateTouchFromMouseEventCommand { });
            }

            /// <summary>
            /// Ignores input events (useful while auditing page).
            /// </summary>
            public Task SetIgnoreInputEvents()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.SetIgnoreInputEventsCommand { });
            }

            /// <summary>
            /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizePinchGesture()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.SynthesizePinchGestureCommand { });
            }

            /// <summary>
            /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizeScrollGesture()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.SynthesizeScrollGestureCommand { });
            }

            /// <summary>
            /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizeTapGesture()
            {
                return InspectionClient.InvokeCommand(new Protocol.Input.SynthesizeTapGestureCommand { });
            }
        }

        public class InspectorInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public InspectorInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables inspector domain notifications.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Inspector.DisableCommand { });
            }

            /// <summary>
            /// Enables inspector domain notifications.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Inspector.EnableCommand { });
            }
        }

        public class LayerTreeInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public LayerTreeInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Provides the reasons why the given layer was composited.
            /// </summary>
            public Task<Protocol.LayerTree.CompositingReasonsResponse> CompositingReasons()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.CompositingReasonsCommand { });
            }

            /// <summary>
            /// Disables compositing tree inspection.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.DisableCommand { });
            }

            /// <summary>
            /// Enables compositing tree inspection.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.EnableCommand { });
            }

            /// <summary>
            /// Returns the snapshot identifier.
            /// </summary>
            public Task<Protocol.LayerTree.LoadSnapshotResponse> LoadSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.LoadSnapshotCommand { });
            }

            /// <summary>
            /// Returns the layer snapshot identifier.
            /// </summary>
            public Task<Protocol.LayerTree.MakeSnapshotResponse> MakeSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.MakeSnapshotCommand { });
            }

            public Task<Protocol.LayerTree.ProfileSnapshotResponse> ProfileSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.ProfileSnapshotCommand { });
            }

            /// <summary>
            /// Releases layer snapshot captured by the back-end.
            /// </summary>
            public Task ReleaseSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.ReleaseSnapshotCommand { });
            }

            /// <summary>
            /// Replays the layer snapshot and returns the resulting bitmap.
            /// </summary>
            public Task<Protocol.LayerTree.ReplaySnapshotResponse> ReplaySnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.ReplaySnapshotCommand { });
            }

            /// <summary>
            /// Replays the layer snapshot and returns canvas log.
            /// </summary>
            public Task<Protocol.LayerTree.SnapshotCommandLogResponse> SnapshotCommandLog()
            {
                return InspectionClient.InvokeCommand(new Protocol.LayerTree.SnapshotCommandLogCommand { });
            }
        }

        public class LogInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public LogInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Clears the log.
            /// </summary>
            public Task Clear()
            {
                return InspectionClient.InvokeCommand(new Protocol.Log.ClearCommand { });
            }

            /// <summary>
            /// Disables log domain, prevents further log entries from being reported to the client.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Log.DisableCommand { });
            }

            /// <summary>
            /// Enables log domain, sends the entries collected so far to the client by means of the
            /// `entryAdded` notification.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Log.EnableCommand { });
            }

            /// <summary>
            /// start violation reporting.
            /// </summary>
            public Task StartViolationsReport()
            {
                return InspectionClient.InvokeCommand(new Protocol.Log.StartViolationsReportCommand { });
            }

            /// <summary>
            /// Stop violation reporting.
            /// </summary>
            public Task StopViolationsReport()
            {
                return InspectionClient.InvokeCommand(new Protocol.Log.StopViolationsReportCommand { });
            }
        }

        public class MemoryInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public MemoryInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            public Task<Protocol.Memory.GetDOMCountersResponse> GetDOMCounters()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.GetDOMCountersCommand { });
            }

            public Task PrepareForLeakDetection()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.PrepareForLeakDetectionCommand { });
            }

            /// <summary>
            /// Enable/disable suppressing memory pressure notifications in all processes.
            /// </summary>
            public Task SetPressureNotificationsSuppressed()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.SetPressureNotificationsSuppressedCommand { });
            }

            /// <summary>
            /// Simulate a memory pressure notification in all processes.
            /// </summary>
            public Task SimulatePressureNotification()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.SimulatePressureNotificationCommand { });
            }

            /// <summary>
            /// Start collecting native memory profile.
            /// </summary>
            public Task StartSampling()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.StartSamplingCommand { });
            }

            /// <summary>
            /// Stop collecting native memory profile.
            /// </summary>
            public Task StopSampling()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.StopSamplingCommand { });
            }

            /// <summary>
            /// Retrieve native memory allocations profile
            /// collected since renderer process startup.
            /// </summary>
            public Task<Protocol.Memory.GetAllTimeSamplingProfileResponse> GetAllTimeSamplingProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.GetAllTimeSamplingProfileCommand { });
            }

            /// <summary>
            /// Retrieve native memory allocations profile
            /// collected since browser process startup.
            /// </summary>
            public Task<Protocol.Memory.GetBrowserSamplingProfileResponse> GetBrowserSamplingProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.GetBrowserSamplingProfileCommand { });
            }

            /// <summary>
            /// Retrieve native memory allocations profile collected since last
            /// `startSampling` call.
            /// </summary>
            public Task<Protocol.Memory.GetSamplingProfileResponse> GetSamplingProfile()
            {
                return InspectionClient.InvokeCommand(new Protocol.Memory.GetSamplingProfileCommand { });
            }
        }

        public class NetworkInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public NetworkInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Tells whether clearing browser cache is supported.
            /// </summary>
            [Obsolete]
            public Task<Protocol.Network.CanClearBrowserCacheResponse> CanClearBrowserCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.CanClearBrowserCacheCommand { });
            }

            /// <summary>
            /// Tells whether clearing browser cookies is supported.
            /// </summary>
            [Obsolete]
            public Task<Protocol.Network.CanClearBrowserCookiesResponse> CanClearBrowserCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.CanClearBrowserCookiesCommand { });
            }

            /// <summary>
            /// Tells whether emulation of network conditions is supported.
            /// </summary>
            [Obsolete]
            public Task<Protocol.Network.CanEmulateNetworkConditionsResponse> CanEmulateNetworkConditions()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.CanEmulateNetworkConditionsCommand { });
            }

            /// <summary>
            /// Clears browser cache.
            /// </summary>
            public Task ClearBrowserCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.ClearBrowserCacheCommand { });
            }

            /// <summary>
            /// Clears browser cookies.
            /// </summary>
            public Task ClearBrowserCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.ClearBrowserCookiesCommand { });
            }

            /// <summary>
            /// Response to Network.requestIntercepted which either modifies the request to continue with any
            /// modifications, or blocks it, or completes it with the provided response bytes. If a network
            /// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
            /// event will be sent with the same InterceptionId.
            /// </summary>
            public Task ContinueInterceptedRequest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.ContinueInterceptedRequestCommand { });
            }

            /// <summary>
            /// Deletes browser cookies with matching name and url or domain/path pair.
            /// </summary>
            public Task DeleteCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.DeleteCookiesCommand { });
            }

            /// <summary>
            /// Disables network tracking, prevents network events from being sent to the client.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.DisableCommand { });
            }

            /// <summary>
            /// Activates emulation of network conditions.
            /// </summary>
            public Task EmulateNetworkConditions()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.EmulateNetworkConditionsCommand { });
            }

            /// <summary>
            /// Enables network tracking, network events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.EnableCommand { });
            }

            /// <summary>
            /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
            /// information in the `cookies` field.
            /// </summary>
            public Task<Protocol.Network.GetAllCookiesResponse> GetAllCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetAllCookiesCommand { });
            }

            /// <summary>
            /// Returns the DER-encoded certificate.
            /// </summary>
            public Task<Protocol.Network.GetCertificateResponse> GetCertificate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetCertificateCommand { });
            }

            /// <summary>
            /// Returns all browser cookies for the current URL. Depending on the backend support, will return
            /// detailed cookie information in the `cookies` field.
            /// </summary>
            public Task<Protocol.Network.GetCookiesResponse> GetCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetCookiesCommand { });
            }

            /// <summary>
            /// Returns content served for the given request.
            /// </summary>
            public Task<Protocol.Network.GetResponseBodyResponse> GetResponseBody()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetResponseBodyCommand { });
            }

            /// <summary>
            /// Returns post data sent with the request. Returns an error when no data was sent with the request.
            /// </summary>
            public Task<Protocol.Network.GetRequestPostDataResponse> GetRequestPostData()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetRequestPostDataCommand { });
            }

            /// <summary>
            /// Returns content served for the given currently intercepted request.
            /// </summary>
            public Task<Protocol.Network.GetResponseBodyForInterceptionResponse> GetResponseBodyForInterception()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.GetResponseBodyForInterceptionCommand { });
            }

            /// <summary>
            /// Returns a handle to the stream representing the response body. Note that after this command,
            /// the intercepted request can't be continued as is -- you either need to cancel it or to provide
            /// the response body. The stream only supports sequential read, IO.read will fail if the position
            /// is specified.
            /// </summary>
            public Task<Protocol.Network.TakeResponseBodyForInterceptionAsStreamResponse> TakeResponseBodyForInterceptionAsStream()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.TakeResponseBodyForInterceptionAsStreamCommand { });
            }

            /// <summary>
            /// This method sends a new XMLHttpRequest which is identical to the original one. The following
            /// parameters should be identical: method, url, async, request body, extra headers, withCredentials
            /// attribute, user, password.
            /// </summary>
            public Task ReplayXHR()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.ReplayXHRCommand { });
            }

            /// <summary>
            /// Searches for given string in response content.
            /// </summary>
            public Task<Protocol.Network.SearchInResponseBodyResponse> SearchInResponseBody()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SearchInResponseBodyCommand { });
            }

            /// <summary>
            /// Blocks URLs from loading.
            /// </summary>
            public Task SetBlockedURLs()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetBlockedURLsCommand { });
            }

            /// <summary>
            /// Toggles ignoring of service worker for each request.
            /// </summary>
            public Task SetBypassServiceWorker()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetBypassServiceWorkerCommand { });
            }

            /// <summary>
            /// Toggles ignoring cache for each request. If `true`, cache will not be used.
            /// </summary>
            public Task SetCacheDisabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetCacheDisabledCommand { });
            }

            /// <summary>
            /// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
            /// </summary>
            public Task<Protocol.Network.SetCookieResponse> SetCookie()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetCookieCommand { });
            }

            /// <summary>
            /// Sets given cookies.
            /// </summary>
            public Task SetCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetCookiesCommand { });
            }

            /// <summary>
            /// For testing.
            /// </summary>
            public Task SetDataSizeLimitsForTest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetDataSizeLimitsForTestCommand { });
            }

            /// <summary>
            /// Specifies whether to always send extra HTTP headers with the requests from this page.
            /// </summary>
            public Task SetExtraHTTPHeaders()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetExtraHTTPHeadersCommand { });
            }

            /// <summary>
            /// Sets the requests to intercept that match a the provided patterns and optionally resource types.
            /// </summary>
            public Task SetRequestInterception()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetRequestInterceptionCommand { });
            }

            /// <summary>
            /// Allows overriding user agent with the given string.
            /// </summary>
            public Task SetUserAgentOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Network.SetUserAgentOverrideCommand { });
            }
        }

        public class OverlayInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public OverlayInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables domain notifications.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.DisableCommand { });
            }

            /// <summary>
            /// Enables domain notifications.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.EnableCommand { });
            }

            /// <summary>
            /// For testing.
            /// </summary>
            public Task<Protocol.Overlay.GetHighlightObjectForTestResponse> GetHighlightObjectForTest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.GetHighlightObjectForTestCommand { });
            }

            /// <summary>
            /// Hides any highlight.
            /// </summary>
            public Task HideHighlight()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.HideHighlightCommand { });
            }

            /// <summary>
            /// Highlights owner element of the frame with given id.
            /// </summary>
            public Task HighlightFrame()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.HighlightFrameCommand { });
            }

            /// <summary>
            /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
            /// objectId must be specified.
            /// </summary>
            public Task HighlightNode()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.HighlightNodeCommand { });
            }

            /// <summary>
            /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
            /// </summary>
            public Task HighlightQuad()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.HighlightQuadCommand { });
            }

            /// <summary>
            /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
            /// </summary>
            public Task HighlightRect()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.HighlightRectCommand { });
            }

            /// <summary>
            /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
            /// Backend then generates 'inspectNodeRequested' event upon element selection.
            /// </summary>
            public Task SetInspectMode()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetInspectModeCommand { });
            }

            public Task SetPausedInDebuggerMessage()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetPausedInDebuggerMessageCommand { });
            }

            /// <summary>
            /// Requests that backend shows debug borders on layers
            /// </summary>
            public Task SetShowDebugBorders()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowDebugBordersCommand { });
            }

            /// <summary>
            /// Requests that backend shows the FPS counter
            /// </summary>
            public Task SetShowFPSCounter()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowFPSCounterCommand { });
            }

            /// <summary>
            /// Requests that backend shows paint rectangles
            /// </summary>
            public Task SetShowPaintRects()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowPaintRectsCommand { });
            }

            /// <summary>
            /// Requests that backend shows scroll bottleneck rects
            /// </summary>
            public Task SetShowScrollBottleneckRects()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowScrollBottleneckRectsCommand { });
            }

            /// <summary>
            /// Requests that backend shows hit-test borders on layers
            /// </summary>
            public Task SetShowHitTestBorders()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowHitTestBordersCommand { });
            }

            /// <summary>
            /// Paints viewport size upon main frame resize.
            /// </summary>
            public Task SetShowViewportSizeOnResize()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetShowViewportSizeOnResizeCommand { });
            }

            public Task SetSuspended()
            {
                return InspectionClient.InvokeCommand(new Protocol.Overlay.SetSuspendedCommand { });
            }
        }

        public class PageInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public PageInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Deprecated, please use addScriptToEvaluateOnNewDocument instead.
            /// </summary>
            [Obsolete]
            public Task<Protocol.Page.AddScriptToEvaluateOnLoadResponse> AddScriptToEvaluateOnLoad()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.AddScriptToEvaluateOnLoadCommand { });
            }

            /// <summary>
            /// Evaluates given script in every frame upon creation (before loading frame's scripts).
            /// </summary>
            public Task<Protocol.Page.AddScriptToEvaluateOnNewDocumentResponse> AddScriptToEvaluateOnNewDocument()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.AddScriptToEvaluateOnNewDocumentCommand { });
            }

            /// <summary>
            /// Brings page to front (activates tab).
            /// </summary>
            public Task BringToFront()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.BringToFrontCommand { });
            }

            /// <summary>
            /// Capture page screenshot.
            /// </summary>
            public Task<Protocol.Page.CaptureScreenshotResponse> CaptureScreenshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.CaptureScreenshotCommand { });
            }

            /// <summary>
            /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
            /// iframes, shadow DOM, external resources, and element-inline styles.
            /// </summary>
            public Task<Protocol.Page.CaptureSnapshotResponse> CaptureSnapshot()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.CaptureSnapshotCommand { });
            }

            /// <summary>
            /// Clears the overriden device metrics.
            /// </summary>
            [Obsolete]
            public Task ClearDeviceMetricsOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ClearDeviceMetricsOverrideCommand { });
            }

            /// <summary>
            /// Clears the overridden Device Orientation.
            /// </summary>
            [Obsolete]
            public Task ClearDeviceOrientationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ClearDeviceOrientationOverrideCommand { });
            }

            /// <summary>
            /// Clears the overriden Geolocation Position and Error.
            /// </summary>
            [Obsolete]
            public Task ClearGeolocationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ClearGeolocationOverrideCommand { });
            }

            /// <summary>
            /// Creates an isolated world for the given frame.
            /// </summary>
            public Task<Protocol.Page.CreateIsolatedWorldResponse> CreateIsolatedWorld()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.CreateIsolatedWorldCommand { });
            }

            /// <summary>
            /// Deletes browser cookie with given name, domain and path.
            /// </summary>
            [Obsolete]
            public Task DeleteCookie()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.DeleteCookieCommand { });
            }

            /// <summary>
            /// Disables page domain notifications.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.DisableCommand { });
            }

            /// <summary>
            /// Enables page domain notifications.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.EnableCommand { });
            }

            public Task<Protocol.Page.GetAppManifestResponse> GetAppManifest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetAppManifestCommand { });
            }

            /// <summary>
            /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
            /// information in the `cookies` field.
            /// </summary>
            [Obsolete]
            public Task<Protocol.Page.GetCookiesResponse> GetCookies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetCookiesCommand { });
            }

            /// <summary>
            /// Returns present frame tree structure.
            /// </summary>
            public Task<Protocol.Page.GetFrameTreeResponse> GetFrameTree()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetFrameTreeCommand { });
            }

            /// <summary>
            /// Returns metrics relating to the layouting of the page, such as viewport bounds/scale.
            /// </summary>
            public Task<Protocol.Page.GetLayoutMetricsResponse> GetLayoutMetrics()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetLayoutMetricsCommand { });
            }

            /// <summary>
            /// Returns navigation history for the current page.
            /// </summary>
            public Task<Protocol.Page.GetNavigationHistoryResponse> GetNavigationHistory()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetNavigationHistoryCommand { });
            }

            /// <summary>
            /// Resets navigation history for the current page.
            /// </summary>
            public Task ResetNavigationHistory()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ResetNavigationHistoryCommand { });
            }

            /// <summary>
            /// Returns content of the given resource.
            /// </summary>
            public Task<Protocol.Page.GetResourceContentResponse> GetResourceContent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetResourceContentCommand { });
            }

            /// <summary>
            /// Returns present frame / resource tree structure.
            /// </summary>
            public Task<Protocol.Page.GetResourceTreeResponse> GetResourceTree()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GetResourceTreeCommand { });
            }

            /// <summary>
            /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
            /// </summary>
            public Task HandleJavaScriptDialog()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.HandleJavaScriptDialogCommand { });
            }

            /// <summary>
            /// Navigates current page to the given URL.
            /// </summary>
            public Task<Protocol.Page.NavigateResponse> Navigate()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.NavigateCommand { });
            }

            /// <summary>
            /// Navigates current page to the given history entry.
            /// </summary>
            public Task NavigateToHistoryEntry()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.NavigateToHistoryEntryCommand { });
            }

            /// <summary>
            /// Print page as PDF.
            /// </summary>
            public Task<Protocol.Page.PrintToPDFResponse> PrintToPDF()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.PrintToPDFCommand { });
            }

            /// <summary>
            /// Reloads given page optionally ignoring the cache.
            /// </summary>
            public Task Reload()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ReloadCommand { });
            }

            /// <summary>
            /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
            /// </summary>
            [Obsolete]
            public Task RemoveScriptToEvaluateOnLoad()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.RemoveScriptToEvaluateOnLoadCommand { });
            }

            /// <summary>
            /// Removes given script from the list.
            /// </summary>
            public Task RemoveScriptToEvaluateOnNewDocument()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.RemoveScriptToEvaluateOnNewDocumentCommand { });
            }

            /// <summary>
            /// Acknowledges that a screencast frame has been received by the frontend.
            /// </summary>
            public Task ScreencastFrameAck()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ScreencastFrameAckCommand { });
            }

            /// <summary>
            /// Searches for given string in resource content.
            /// </summary>
            public Task<Protocol.Page.SearchInResourceResponse> SearchInResource()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SearchInResourceCommand { });
            }

            /// <summary>
            /// Enable Chrome's experimental ad filter on all sites.
            /// </summary>
            public Task SetAdBlockingEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetAdBlockingEnabledCommand { });
            }

            /// <summary>
            /// Enable page Content Security Policy by-passing.
            /// </summary>
            public Task SetBypassCSP()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetBypassCSPCommand { });
            }

            /// <summary>
            /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
            /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
            /// query results).
            /// </summary>
            [Obsolete]
            public Task SetDeviceMetricsOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetDeviceMetricsOverrideCommand { });
            }

            /// <summary>
            /// Overrides the Device Orientation.
            /// </summary>
            [Obsolete]
            public Task SetDeviceOrientationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetDeviceOrientationOverrideCommand { });
            }

            /// <summary>
            /// Set generic font families.
            /// </summary>
            public Task SetFontFamilies()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetFontFamiliesCommand { });
            }

            /// <summary>
            /// Set default font sizes.
            /// </summary>
            public Task SetFontSizes()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetFontSizesCommand { });
            }

            /// <summary>
            /// Sets given markup as the document's HTML.
            /// </summary>
            public Task SetDocumentContent()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetDocumentContentCommand { });
            }

            /// <summary>
            /// Set the behavior when downloading a file.
            /// </summary>
            public Task SetDownloadBehavior()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetDownloadBehaviorCommand { });
            }

            /// <summary>
            /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
            /// unavailable.
            /// </summary>
            [Obsolete]
            public Task SetGeolocationOverride()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetGeolocationOverrideCommand { });
            }

            /// <summary>
            /// Controls whether page will emit lifecycle events.
            /// </summary>
            public Task SetLifecycleEventsEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetLifecycleEventsEnabledCommand { });
            }

            /// <summary>
            /// Toggles mouse event-based touch event emulation.
            /// </summary>
            [Obsolete]
            public Task SetTouchEmulationEnabled()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetTouchEmulationEnabledCommand { });
            }

            /// <summary>
            /// Starts sending each frame using the `screencastFrame` event.
            /// </summary>
            public Task StartScreencast()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.StartScreencastCommand { });
            }

            /// <summary>
            /// Force the page stop all navigations and pending resource fetches.
            /// </summary>
            public Task StopLoading()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.StopLoadingCommand { });
            }

            /// <summary>
            /// Crashes renderer on the IO thread, generates minidumps.
            /// </summary>
            public Task Crash()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.CrashCommand { });
            }

            /// <summary>
            /// Tries to close page, running its beforeunload hooks, if any.
            /// </summary>
            public Task Close()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.CloseCommand { });
            }

            /// <summary>
            /// Tries to update the web lifecycle state of the page.
            /// It will transition the page to the given state according to:
            /// https://github.com/WICG/web-lifecycle/
            /// </summary>
            public Task SetWebLifecycleState()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetWebLifecycleStateCommand { });
            }

            /// <summary>
            /// Stops sending each frame in the `screencastFrame`.
            /// </summary>
            public Task StopScreencast()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.StopScreencastCommand { });
            }

            /// <summary>
            /// Forces compilation cache to be generated for every subresource script.
            /// </summary>
            public Task SetProduceCompilationCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.SetProduceCompilationCacheCommand { });
            }

            /// <summary>
            /// Seeds compilation cache for given url. Compilation cache does not survive
            /// cross-process navigation.
            /// </summary>
            public Task AddCompilationCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.AddCompilationCacheCommand { });
            }

            /// <summary>
            /// Clears seeded compilation cache.
            /// </summary>
            public Task ClearCompilationCache()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.ClearCompilationCacheCommand { });
            }

            /// <summary>
            /// Generates a report for testing.
            /// </summary>
            public Task GenerateTestReport()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.GenerateTestReportCommand { });
            }

            /// <summary>
            /// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
            /// </summary>
            public Task WaitForDebugger()
            {
                return InspectionClient.InvokeCommand(new Protocol.Page.WaitForDebuggerCommand { });
            }
        }

        public class PerformanceInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public PerformanceInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disable collecting and reporting metrics.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Performance.DisableCommand { });
            }

            /// <summary>
            /// Enable collecting and reporting metrics.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Performance.EnableCommand { });
            }

            /// <summary>
            /// Sets time domain to use for collecting and reporting duration metrics.
            /// Note that this must be called before enabling metrics collection. Calling
            /// this method while metrics collection is enabled returns an error.
            /// </summary>
            public Task SetTimeDomain()
            {
                return InspectionClient.InvokeCommand(new Protocol.Performance.SetTimeDomainCommand { });
            }

            /// <summary>
            /// Retrieve current values of run-time metrics.
            /// </summary>
            public Task<Protocol.Performance.GetMetricsResponse> GetMetrics()
            {
                return InspectionClient.InvokeCommand(new Protocol.Performance.GetMetricsCommand { });
            }
        }

        public class SecurityInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public SecurityInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables tracking security state changes.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Security.DisableCommand { });
            }

            /// <summary>
            /// Enables tracking security state changes.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Security.EnableCommand { });
            }

            /// <summary>
            /// Enable/disable whether all certificate errors should be ignored.
            /// </summary>
            public Task SetIgnoreCertificateErrors()
            {
                return InspectionClient.InvokeCommand(new Protocol.Security.SetIgnoreCertificateErrorsCommand { });
            }

            /// <summary>
            /// Handles a certificate error that fired a certificateError event.
            /// </summary>
            [Obsolete]
            public Task HandleCertificateError()
            {
                return InspectionClient.InvokeCommand(new Protocol.Security.HandleCertificateErrorCommand { });
            }

            /// <summary>
            /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
            /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
            /// </summary>
            [Obsolete]
            public Task SetOverrideCertificateErrors()
            {
                return InspectionClient.InvokeCommand(new Protocol.Security.SetOverrideCertificateErrorsCommand { });
            }
        }

        public class ServiceWorkerInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public ServiceWorkerInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            public Task DeliverPushMessage()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.DeliverPushMessageCommand { });
            }

            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.DisableCommand { });
            }

            public Task DispatchSyncEvent()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.DispatchSyncEventCommand { });
            }

            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.EnableCommand { });
            }

            public Task InspectWorker()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.InspectWorkerCommand { });
            }

            public Task SetForceUpdateOnPageLoad()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.SetForceUpdateOnPageLoadCommand { });
            }

            public Task SkipWaiting()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.SkipWaitingCommand { });
            }

            public Task StartWorker()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.StartWorkerCommand { });
            }

            public Task StopAllWorkers()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.StopAllWorkersCommand { });
            }

            public Task StopWorker()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.StopWorkerCommand { });
            }

            public Task Unregister()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.UnregisterCommand { });
            }

            public Task UpdateRegistration()
            {
                return InspectionClient.InvokeCommand(new Protocol.ServiceWorker.UpdateRegistrationCommand { });
            }
        }

        public class StorageInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public StorageInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Clears storage for origin.
            /// </summary>
            public Task ClearDataForOrigin()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.ClearDataForOriginCommand { });
            }

            /// <summary>
            /// Returns usage and quota in bytes.
            /// </summary>
            public Task<Protocol.Storage.GetUsageAndQuotaResponse> GetUsageAndQuota()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.GetUsageAndQuotaCommand { });
            }

            /// <summary>
            /// Registers origin to be notified when an update occurs to its cache storage list.
            /// </summary>
            public Task TrackCacheStorageForOrigin()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.TrackCacheStorageForOriginCommand { });
            }

            /// <summary>
            /// Registers origin to be notified when an update occurs to its IndexedDB.
            /// </summary>
            public Task TrackIndexedDBForOrigin()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.TrackIndexedDBForOriginCommand { });
            }

            /// <summary>
            /// Unregisters origin from receiving notifications for cache storage.
            /// </summary>
            public Task UntrackCacheStorageForOrigin()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.UntrackCacheStorageForOriginCommand { });
            }

            /// <summary>
            /// Unregisters origin from receiving notifications for IndexedDB.
            /// </summary>
            public Task UntrackIndexedDBForOrigin()
            {
                return InspectionClient.InvokeCommand(new Protocol.Storage.UntrackIndexedDBForOriginCommand { });
            }
        }

        public class SystemInfoInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public SystemInfoInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Returns information about the system.
            /// </summary>
            public Task<Protocol.SystemInfo.GetInfoResponse> GetInfo()
            {
                return InspectionClient.InvokeCommand(new Protocol.SystemInfo.GetInfoCommand { });
            }

            /// <summary>
            /// Returns information about all running processes.
            /// </summary>
            public Task<Protocol.SystemInfo.GetProcessInfoResponse> GetProcessInfo()
            {
                return InspectionClient.InvokeCommand(new Protocol.SystemInfo.GetProcessInfoCommand { });
            }
        }

        public class TargetInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public TargetInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Activates (focuses) the target.
            /// </summary>
            public Task ActivateTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.ActivateTargetCommand { });
            }

            /// <summary>
            /// Attaches to the target with given id.
            /// </summary>
            public Task<Protocol.Target.AttachToTargetResponse> AttachToTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.AttachToTargetCommand { });
            }

            /// <summary>
            /// Attaches to the browser target, only uses flat sessionId mode.
            /// </summary>
            public Task<Protocol.Target.AttachToBrowserTargetResponse> AttachToBrowserTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.AttachToBrowserTargetCommand { });
            }

            /// <summary>
            /// Closes the target. If the target is a page that gets closed too.
            /// </summary>
            public Task<Protocol.Target.CloseTargetResponse> CloseTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.CloseTargetCommand { });
            }

            /// <summary>
            /// Inject object to the target's main frame that provides a communication
            /// channel with browser target.
            /// 
            /// Injected object will be available as `window[bindingName]`.
            /// 
            /// The object has the follwing API:
            /// - `binding.send(json)` - a method to send messages over the remote debugging protocol
            /// - `binding.onmessage = json =&gt; handleMessage(json)` - a callback that will be called for the protocol notifications and command responses.
            /// </summary>
            public Task ExposeDevToolsProtocol()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.ExposeDevToolsProtocolCommand { });
            }

            /// <summary>
            /// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
            /// one.
            /// </summary>
            public Task<Protocol.Target.CreateBrowserContextResponse> CreateBrowserContext()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.CreateBrowserContextCommand { });
            }

            /// <summary>
            /// Returns all browser contexts created with `Target.createBrowserContext` method.
            /// </summary>
            public Task<Protocol.Target.GetBrowserContextsResponse> GetBrowserContexts()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.GetBrowserContextsCommand { });
            }

            /// <summary>
            /// Creates a new page.
            /// </summary>
            public Task<Protocol.Target.CreateTargetResponse> CreateTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.CreateTargetCommand { });
            }

            /// <summary>
            /// Detaches session with given id.
            /// </summary>
            public Task DetachFromTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.DetachFromTargetCommand { });
            }

            /// <summary>
            /// Deletes a BrowserContext. All the belonging pages will be closed without calling their
            /// beforeunload hooks.
            /// </summary>
            public Task DisposeBrowserContext()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.DisposeBrowserContextCommand { });
            }

            /// <summary>
            /// Returns information about a target.
            /// </summary>
            public Task<Protocol.Target.GetTargetInfoResponse> GetTargetInfo()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.GetTargetInfoCommand { });
            }

            /// <summary>
            /// Retrieves a list of available targets.
            /// </summary>
            public Task<Protocol.Target.GetTargetsResponse> GetTargets()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.GetTargetsCommand { });
            }

            /// <summary>
            /// Sends protocol message over session with given id.
            /// </summary>
            public Task SendMessageToTarget()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.SendMessageToTargetCommand { });
            }

            /// <summary>
            /// Controls whether to automatically attach to new targets which are considered to be related to
            /// this one. When turned on, attaches to all existing related targets as well. When turned off,
            /// automatically detaches from all currently attached targets.
            /// </summary>
            public Task SetAutoAttach()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.SetAutoAttachCommand { });
            }

            /// <summary>
            /// Controls whether to discover available targets and notify via
            /// `targetCreated/targetInfoChanged/targetDestroyed` events.
            /// </summary>
            public Task SetDiscoverTargets()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.SetDiscoverTargetsCommand { });
            }

            /// <summary>
            /// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
            /// `true`.
            /// </summary>
            public Task SetRemoteLocations()
            {
                return InspectionClient.InvokeCommand(new Protocol.Target.SetRemoteLocationsCommand { });
            }
        }

        public class TetheringInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public TetheringInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Request browser port binding.
            /// </summary>
            public Task Bind()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tethering.BindCommand { });
            }

            /// <summary>
            /// Request browser port unbinding.
            /// </summary>
            public Task Unbind()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tethering.UnbindCommand { });
            }
        }

        public class TracingInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public TracingInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Stop trace events collection.
            /// </summary>
            public Task End()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tracing.EndCommand { });
            }

            /// <summary>
            /// Gets supported tracing categories.
            /// </summary>
            public Task<Protocol.Tracing.GetCategoriesResponse> GetCategories()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tracing.GetCategoriesCommand { });
            }

            /// <summary>
            /// Record a clock sync marker in the trace.
            /// </summary>
            public Task RecordClockSyncMarker()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tracing.RecordClockSyncMarkerCommand { });
            }

            /// <summary>
            /// Request a global memory dump.
            /// </summary>
            public Task<Protocol.Tracing.RequestMemoryDumpResponse> RequestMemoryDump()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tracing.RequestMemoryDumpCommand { });
            }

            /// <summary>
            /// Start trace events collection.
            /// </summary>
            public Task Start()
            {
                return InspectionClient.InvokeCommand(new Protocol.Tracing.StartCommand { });
            }
        }

        public class TestingInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public TestingInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Generates a report for testing.
            /// </summary>
            public Task GenerateTestReport()
            {
                return InspectionClient.InvokeCommand(new Protocol.Testing.GenerateTestReportCommand { });
            }
        }

        public class FetchInspectionClient
        {
            private readonly InspectionClient InspectionClient;

            public FetchInspectionClient(InspectionClient inspectionClient)
            {
                InspectionClient = inspectionClient;
            }

            /// <summary>
            /// Disables the fetch domain.
            /// </summary>
            public Task Disable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.DisableCommand { });
            }

            /// <summary>
            /// Enables issuing of requestPaused events. A request will be paused until client
            /// calls one of failRequest, fulfillRequest or continueRequest/continueWithAuth.
            /// </summary>
            public Task Enable()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.EnableCommand { });
            }

            /// <summary>
            /// Causes the request to fail with specified reason.
            /// </summary>
            public Task FailRequest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.FailRequestCommand { });
            }

            /// <summary>
            /// Provides response to the request.
            /// </summary>
            public Task FulfillRequest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.FulfillRequestCommand { });
            }

            /// <summary>
            /// Continues the request, optionally modifying some of its parameters.
            /// </summary>
            public Task ContinueRequest()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.ContinueRequestCommand { });
            }

            /// <summary>
            /// Continues a request supplying authChallengeResponse following authRequired event.
            /// </summary>
            public Task ContinueWithAuth()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.ContinueWithAuthCommand { });
            }

            /// <summary>
            /// Causes the body of the response to be received from the server and
            /// returned as a single string. May only be issued for a request that
            /// is paused in the Response stage and is mutually exclusive with
            /// takeResponseBodyForInterceptionAsStream. Calling other methods that
            /// affect the request or disabling fetch domain before body is received
            /// results in an undefined behavior.
            /// </summary>
            public Task<Protocol.Fetch.GetResponseBodyResponse> GetResponseBody()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.GetResponseBodyCommand { });
            }

            /// <summary>
            /// Returns a handle to the stream representing the response body.
            /// The request must be paused in the HeadersReceived stage.
            /// Note that after this command the request can't be continued
            /// as is -- client either needs to cancel it or to provide the
            /// response body.
            /// The stream only supports sequential read, IO.read will fail if the position
            /// is specified.
            /// This method is mutually exclusive with getResponseBody.
            /// Calling other methods that affect the request or disabling fetch
            /// domain before body is received results in an undefined behavior.
            /// </summary>
            public Task<Protocol.Fetch.TakeResponseBodyAsStreamResponse> TakeResponseBodyAsStream()
            {
                return InspectionClient.InvokeCommand(new Protocol.Fetch.TakeResponseBodyAsStreamCommand { });
            }
        }
    }
}
