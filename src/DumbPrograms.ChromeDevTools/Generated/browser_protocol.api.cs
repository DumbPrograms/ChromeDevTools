using System;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools
{
    partial class InspectionClient
    {

        public AccessibilityInspectionClient Accessibility => __Accessibility ?? (__Accessibility = new AccessibilityInspectionClient(this));
        private AccessibilityInspectionClient __Accessibility;

        public AnimationInspectionClient Animation => __Animation ?? (__Animation = new AnimationInspectionClient(this));
        private AnimationInspectionClient __Animation;

        public ApplicationCacheInspectionClient ApplicationCache => __ApplicationCache ?? (__ApplicationCache = new ApplicationCacheInspectionClient(this));
        private ApplicationCacheInspectionClient __ApplicationCache;

        /// <summary>
        /// Audits domain allows investigation of page violations and possible improvements.
        /// </summary>
        public AuditsInspectionClient Audits => __Audits ?? (__Audits = new AuditsInspectionClient(this));
        private AuditsInspectionClient __Audits;

        /// <summary>
        /// The Browser domain defines methods and events for browser managing.
        /// </summary>
        public BrowserInspectionClient Browser => __Browser ?? (__Browser = new BrowserInspectionClient(this));
        private BrowserInspectionClient __Browser;

        /// <summary>
        /// This domain exposes CSS read/write operations. All CSS objects (stylesheets, rules, and styles)
        /// have an associated `id` used in subsequent operations on the related object. Each object type has
        /// a specific `id` structure, and those are not interchangeable between objects of different kinds.
        /// CSS objects can be loaded using the `get*ForNode()` calls (which accept a DOM node id). A client
        /// can also keep track of stylesheets via the `styleSheetAdded`/`styleSheetRemoved` events and
        /// subsequently load the required stylesheet contents using the `getStyleSheet[Text]()` methods.
        /// </summary>
        public CSSInspectionClient CSS => __CSS ?? (__CSS = new CSSInspectionClient(this));
        private CSSInspectionClient __CSS;

        public CacheStorageInspectionClient CacheStorage => __CacheStorage ?? (__CacheStorage = new CacheStorageInspectionClient(this));
        private CacheStorageInspectionClient __CacheStorage;

        /// <summary>
        /// A domain for interacting with Cast, Presentation API, and Remote Playback API
        /// functionalities.
        /// </summary>
        public CastInspectionClient Cast => __Cast ?? (__Cast = new CastInspectionClient(this));
        private CastInspectionClient __Cast;

        /// <summary>
        /// This domain exposes DOM read/write operations. Each DOM Node is represented with its mirror object
        /// that has an `id`. This `id` can be used to get additional information on the Node, resolve it into
        /// the JavaScript object wrapper, etc. It is important that client receives DOM events only for the
        /// nodes that are known to the client. Backend keeps track of the nodes that were sent to the client
        /// and never sends the same node twice. It is client's responsibility to collect information about
        /// the nodes that were sent to the client.&lt;p&gt;Note that `iframe` owner elements will return
        /// corresponding document elements as their child nodes.&lt;/p&gt;
        /// </summary>
        public DOMInspectionClient DOM => __DOM ?? (__DOM = new DOMInspectionClient(this));
        private DOMInspectionClient __DOM;

        /// <summary>
        /// DOM debugging allows setting breakpoints on particular DOM operations and events. JavaScript
        /// execution will stop on these operations as if there was a regular breakpoint set.
        /// </summary>
        public DOMDebuggerInspectionClient DOMDebugger => __DOMDebugger ?? (__DOMDebugger = new DOMDebuggerInspectionClient(this));
        private DOMDebuggerInspectionClient __DOMDebugger;

        /// <summary>
        /// This domain facilitates obtaining document snapshots with DOM, layout, and style information.
        /// </summary>
        public DOMSnapshotInspectionClient DOMSnapshot => __DOMSnapshot ?? (__DOMSnapshot = new DOMSnapshotInspectionClient(this));
        private DOMSnapshotInspectionClient __DOMSnapshot;

        /// <summary>
        /// Query and modify DOM storage.
        /// </summary>
        public DOMStorageInspectionClient DOMStorage => __DOMStorage ?? (__DOMStorage = new DOMStorageInspectionClient(this));
        private DOMStorageInspectionClient __DOMStorage;

        public DatabaseInspectionClient Database => __Database ?? (__Database = new DatabaseInspectionClient(this));
        private DatabaseInspectionClient __Database;

        public DeviceOrientationInspectionClient DeviceOrientation => __DeviceOrientation ?? (__DeviceOrientation = new DeviceOrientationInspectionClient(this));
        private DeviceOrientationInspectionClient __DeviceOrientation;

        /// <summary>
        /// This domain emulates different environments for the page.
        /// </summary>
        public EmulationInspectionClient Emulation => __Emulation ?? (__Emulation = new EmulationInspectionClient(this));
        private EmulationInspectionClient __Emulation;

        /// <summary>
        /// This domain provides experimental commands only supported in headless mode.
        /// </summary>
        public HeadlessExperimentalInspectionClient HeadlessExperimental => __HeadlessExperimental ?? (__HeadlessExperimental = new HeadlessExperimentalInspectionClient(this));
        private HeadlessExperimentalInspectionClient __HeadlessExperimental;

        /// <summary>
        /// Input/Output operations for streams produced by DevTools.
        /// </summary>
        public IOInspectionClient IO => __IO ?? (__IO = new IOInspectionClient(this));
        private IOInspectionClient __IO;

        public IndexedDBInspectionClient IndexedDB => __IndexedDB ?? (__IndexedDB = new IndexedDBInspectionClient(this));
        private IndexedDBInspectionClient __IndexedDB;

        public InputInspectionClient Input => __Input ?? (__Input = new InputInspectionClient(this));
        private InputInspectionClient __Input;

        public InspectorInspectionClient Inspector => __Inspector ?? (__Inspector = new InspectorInspectionClient(this));
        private InspectorInspectionClient __Inspector;

        public LayerTreeInspectionClient LayerTree => __LayerTree ?? (__LayerTree = new LayerTreeInspectionClient(this));
        private LayerTreeInspectionClient __LayerTree;

        /// <summary>
        /// Provides access to log entries.
        /// </summary>
        public LogInspectionClient Log => __Log ?? (__Log = new LogInspectionClient(this));
        private LogInspectionClient __Log;

        public MemoryInspectionClient Memory => __Memory ?? (__Memory = new MemoryInspectionClient(this));
        private MemoryInspectionClient __Memory;

        /// <summary>
        /// Network domain allows tracking network activities of the page. It exposes information about http,
        /// file, data and other requests and responses, their headers, bodies, timing, etc.
        /// </summary>
        public NetworkInspectionClient Network => __Network ?? (__Network = new NetworkInspectionClient(this));
        private NetworkInspectionClient __Network;

        /// <summary>
        /// This domain provides various functionality related to drawing atop the inspected page.
        /// </summary>
        public OverlayInspectionClient Overlay => __Overlay ?? (__Overlay = new OverlayInspectionClient(this));
        private OverlayInspectionClient __Overlay;

        /// <summary>
        /// Actions and events related to the inspected page belong to the page domain.
        /// </summary>
        public PageInspectionClient Page => __Page ?? (__Page = new PageInspectionClient(this));
        private PageInspectionClient __Page;

        public PerformanceInspectionClient Performance => __Performance ?? (__Performance = new PerformanceInspectionClient(this));
        private PerformanceInspectionClient __Performance;

        /// <summary>
        /// Security
        /// </summary>
        public SecurityInspectionClient Security => __Security ?? (__Security = new SecurityInspectionClient(this));
        private SecurityInspectionClient __Security;

        public ServiceWorkerInspectionClient ServiceWorker => __ServiceWorker ?? (__ServiceWorker = new ServiceWorkerInspectionClient(this));
        private ServiceWorkerInspectionClient __ServiceWorker;

        public StorageInspectionClient Storage => __Storage ?? (__Storage = new StorageInspectionClient(this));
        private StorageInspectionClient __Storage;

        /// <summary>
        /// The SystemInfo domain defines methods and events for querying low-level system information.
        /// </summary>
        public SystemInfoInspectionClient SystemInfo => __SystemInfo ?? (__SystemInfo = new SystemInfoInspectionClient(this));
        private SystemInfoInspectionClient __SystemInfo;

        /// <summary>
        /// Supports additional targets discovery and allows to attach to them.
        /// </summary>
        public TargetInspectionClient Target => __Target ?? (__Target = new TargetInspectionClient(this));
        private TargetInspectionClient __Target;

        /// <summary>
        /// The Tethering domain defines methods and events for browser port binding.
        /// </summary>
        public TetheringInspectionClient Tethering => __Tethering ?? (__Tethering = new TetheringInspectionClient(this));
        private TetheringInspectionClient __Tethering;

        public TracingInspectionClient Tracing => __Tracing ?? (__Tracing = new TracingInspectionClient(this));
        private TracingInspectionClient __Tracing;

        /// <summary>
        /// Testing domain is a dumping ground for the capabilities requires for browser or app testing that do not fit other
        /// domains.
        /// </summary>
        public TestingInspectionClient Testing => __Testing ?? (__Testing = new TestingInspectionClient(this));
        private TestingInspectionClient __Testing;

        /// <summary>
        /// A domain for letting clients substitute browser's network layer with client code.
        /// </summary>
        public FetchInspectionClient Fetch => __Fetch ?? (__Fetch = new FetchInspectionClient(this));
        private FetchInspectionClient __Fetch;

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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables the accessibility domain which causes `AXNodeId`s to remain consistent between method calls.
            /// This turns on accessibility for the page, which can impact performance until accessibility is disabled.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
            /// </summary>
            public Task<Protocol.Accessibility.GetPartialAXTreeResponse> GetPartialAXTree()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Fetches the entire accessibility tree
            /// </summary>
            public Task<Protocol.Accessibility.GetFullAXTreeResponse> GetFullAXTree()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables animation domain notifications.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the current time of the an animation.
            /// </summary>
            public Task<Protocol.Animation.GetCurrentTimeResponse> GetCurrentTime()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets the playback rate of the document timeline.
            /// </summary>
            public Task<Protocol.Animation.GetPlaybackRateResponse> GetPlaybackRate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Releases a set of animations to no longer be manipulated.
            /// </summary>
            public Task ReleaseAnimations()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets the remote object of the Animation.
            /// </summary>
            public Task<Protocol.Animation.ResolveAnimationResponse> ResolveAnimation()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Seek a set of animations to a particular time within each animation.
            /// </summary>
            public Task SeekAnimations()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the paused state of a set of animations.
            /// </summary>
            public Task SetPaused()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the playback rate of the document timeline.
            /// </summary>
            public Task SetPlaybackRate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the timing of an animation node.
            /// </summary>
            public Task SetTiming()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns relevant application cache data for the document in given frame.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetApplicationCacheForFrameResponse> GetApplicationCacheForFrame()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns array of frame identifiers with manifest urls for each frame containing a document
            /// associated with some application cache.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetFramesWithManifestsResponse> GetFramesWithManifests()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns manifest URL for document in the given frame.
            /// </summary>
            public Task<Protocol.ApplicationCache.GetManifestForFrameResponse> GetManifestForFrame()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reset all permission management for all origins.
            /// </summary>
            public Task ResetPermissions()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Close browser gracefully.
            /// </summary>
            public Task Close()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Crashes browser on the main thread.
            /// </summary>
            public Task Crash()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns version information.
            /// </summary>
            public Task<Protocol.Browser.GetVersionResponse> GetVersion()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the command line switches for the browser process if, and only if
            /// --enable-automation is on the commandline.
            /// </summary>
            public Task<Protocol.Browser.GetBrowserCommandLineResponse> GetBrowserCommandLine()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Get Chrome histograms.
            /// </summary>
            public Task<Protocol.Browser.GetHistogramsResponse> GetHistograms()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Get a Chrome histogram by name.
            /// </summary>
            public Task<Protocol.Browser.GetHistogramResponse> GetHistogram()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Get position and size of the browser window.
            /// </summary>
            public Task<Protocol.Browser.GetWindowBoundsResponse> GetWindowBounds()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Get the browser window that contains the devtools target.
            /// </summary>
            public Task<Protocol.Browser.GetWindowForTargetResponse> GetWindowForTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Set position and/or size of the browser window.
            /// </summary>
            public Task SetWindowBounds()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Set dock tile details, platform-specific.
            /// </summary>
            public Task SetDockTile()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all class names from specified stylesheet.
            /// </summary>
            public Task<Protocol.CSS.CollectClassNamesResponse> CollectClassNames()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
            /// </summary>
            public Task<Protocol.CSS.CreateStyleSheetResponse> CreateStyleSheet()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables the CSS agent for the given page.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables the CSS agent for the given page. Clients should not assume that the CSS agent has been
            /// enabled until the result of this command is received.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Ensures that the given node will have specified pseudo-classes whenever its style is computed by
            /// the browser.
            /// </summary>
            public Task ForcePseudoState()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.CSS.GetBackgroundColorsResponse> GetBackgroundColors()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the computed style for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetComputedStyleForNodeResponse> GetComputedStyleForNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
            /// attributes) for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetInlineStylesForNodeResponse> GetInlineStylesForNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns requested styles for a DOM node identified by `nodeId`.
            /// </summary>
            public Task<Protocol.CSS.GetMatchedStylesForNodeResponse> GetMatchedStylesForNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all media queries parsed by the rendering engine.
            /// </summary>
            public Task<Protocol.CSS.GetMediaQueriesResponse> GetMediaQueries()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests information about platform fonts which we used to render child TextNodes in the given
            /// node.
            /// </summary>
            public Task<Protocol.CSS.GetPlatformFontsForNodeResponse> GetPlatformFontsForNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the current textual content for a stylesheet.
            /// </summary>
            public Task<Protocol.CSS.GetStyleSheetTextResponse> GetStyleSheetText()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Find a rule with the given active property for the given node and set the new value for this
            /// property
            /// </summary>
            public Task SetEffectivePropertyValueForNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Modifies the keyframe rule key text.
            /// </summary>
            public Task<Protocol.CSS.SetKeyframeKeyResponse> SetKeyframeKey()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Modifies the rule selector.
            /// </summary>
            public Task<Protocol.CSS.SetMediaTextResponse> SetMediaText()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Modifies the rule selector.
            /// </summary>
            public Task<Protocol.CSS.SetRuleSelectorResponse> SetRuleSelector()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the new stylesheet text.
            /// </summary>
            public Task<Protocol.CSS.SetStyleSheetTextResponse> SetStyleSheetText()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Applies specified style edits one after another in the given order.
            /// </summary>
            public Task<Protocol.CSS.SetStyleTextsResponse> SetStyleTexts()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables the selector recording.
            /// </summary>
            public Task StartRuleUsageTracking()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stop tracking rule usage and return the list of rules that were used since last call to
            /// `takeCoverageDelta` (or since start of coverage instrumentation)
            /// </summary>
            public Task<Protocol.CSS.StopRuleUsageTrackingResponse> StopRuleUsageTracking()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Obtain list of rules that became used since last call to this method (or since start of coverage
            /// instrumentation)
            /// </summary>
            public Task<Protocol.CSS.TakeCoverageDeltaResponse> TakeCoverageDelta()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deletes a cache entry.
            /// </summary>
            public Task DeleteEntry()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests cache names.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestCacheNamesResponse> RequestCacheNames()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Fetches cache entry.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestCachedResponseResponse> RequestCachedResponse()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests data from cache.
            /// </summary>
            public Task<Protocol.CacheStorage.RequestEntriesResponse> RequestEntries()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stops observing for sinks and issues.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets a sink to be used when the web page requests the browser to choose a
            /// sink via Presentation API, Remote Playback API, or Cast SDK.
            /// </summary>
            public Task SetSinkToUse()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Starts mirroring the tab to the sink.
            /// </summary>
            public Task StartTabMirroring()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stops the active Cast session on the sink.
            /// </summary>
            public Task StopCasting()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Creates a deep copy of the specified node and places it into the target container before the
            /// given anchor.
            /// </summary>
            public Task<Protocol.DOM.CopyToResponse> CopyTo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Describes node given its id, does not require domain to be enabled. Does not start tracking any
            /// objects, can be used for automation.
            /// </summary>
            public Task<Protocol.DOM.DescribeNodeResponse> DescribeNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables DOM agent for the given page.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Discards search results from the session with the given id. `getSearchResults` should no longer
            /// be called for that search.
            /// </summary>
            public Task DiscardSearchResults()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables DOM agent for the given page.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Focuses the given element.
            /// </summary>
            public Task Focus()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns attributes for the specified node.
            /// </summary>
            public Task<Protocol.DOM.GetAttributesResponse> GetAttributes()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns boxes for the given node.
            /// </summary>
            public Task<Protocol.DOM.GetBoxModelResponse> GetBoxModel()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns quads that describe node position on the page. This method
            /// might return multiple quads for inline nodes.
            /// </summary>
            public Task<Protocol.DOM.GetContentQuadsResponse> GetContentQuads()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the root DOM node (and optionally the subtree) to the caller.
            /// </summary>
            public Task<Protocol.DOM.GetDocumentResponse> GetDocument()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the root DOM node (and optionally the subtree) to the caller.
            /// </summary>
            public Task<Protocol.DOM.GetFlattenedDocumentResponse> GetFlattenedDocument()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
            /// either returned or not.
            /// </summary>
            public Task<Protocol.DOM.GetNodeForLocationResponse> GetNodeForLocation()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns node's HTML markup.
            /// </summary>
            public Task<Protocol.DOM.GetOuterHTMLResponse> GetOuterHTML()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the id of the nearest ancestor that is a relayout boundary.
            /// </summary>
            public Task<Protocol.DOM.GetRelayoutBoundaryResponse> GetRelayoutBoundary()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
            /// identifier.
            /// </summary>
            public Task<Protocol.DOM.GetSearchResultsResponse> GetSearchResults()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Hides any highlight.
            /// </summary>
            public Task HideHighlight()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights DOM node.
            /// </summary>
            public Task HighlightNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights given rectangle.
            /// </summary>
            public Task HighlightRect()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Marks last undoable state.
            /// </summary>
            public Task MarkUndoableState()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Moves node into the new container, places it before the given anchor.
            /// </summary>
            public Task<Protocol.DOM.MoveToResponse> MoveTo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
            /// `cancelSearch` to end this search session.
            /// </summary>
            public Task<Protocol.DOM.PerformSearchResponse> PerformSearch()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
            /// </summary>
            public Task<Protocol.DOM.PushNodeByPathToFrontendResponse> PushNodeByPathToFrontend()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that a batch of nodes is sent to the caller given their backend node ids.
            /// </summary>
            public Task<Protocol.DOM.PushNodesByBackendIdsToFrontendResponse> PushNodesByBackendIdsToFrontend()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Executes `querySelector` on a given node.
            /// </summary>
            public Task<Protocol.DOM.QuerySelectorResponse> QuerySelector()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Executes `querySelectorAll` on a given node.
            /// </summary>
            public Task<Protocol.DOM.QuerySelectorAllResponse> QuerySelectorAll()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Re-does the last undone action.
            /// </summary>
            public Task Redo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes attribute with given name from an element with given id.
            /// </summary>
            public Task RemoveAttribute()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes node with given id.
            /// </summary>
            public Task RemoveNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that children of the node with given id are returned to the caller in form of
            /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
            /// the specified depth.
            /// </summary>
            public Task RequestChildNodes()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that the node is sent to the caller given the JavaScript node object reference. All
            /// nodes that form the path from the node to the root are also sent to the client as a series of
            /// `setChildNodes` notifications.
            /// </summary>
            public Task<Protocol.DOM.RequestNodeResponse> RequestNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
            /// </summary>
            public Task<Protocol.DOM.ResolveNodeResponse> ResolveNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets attribute for an element with given id.
            /// </summary>
            public Task SetAttributeValue()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets attributes on element with given id. This method is useful when user edits some existing
            /// attribute value and types in several attribute name/value pairs.
            /// </summary>
            public Task SetAttributesAsText()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets files for the given file input element.
            /// </summary>
            public Task SetFileInputFiles()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns file information for the given
            /// File wrapper.
            /// </summary>
            public Task<Protocol.DOM.GetFileInfoResponse> GetFileInfo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables console to refer to the node with given id via $x (see Command Line API for more details
            /// $x functions).
            /// </summary>
            public Task SetInspectedNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets node name for a node with given id.
            /// </summary>
            public Task<Protocol.DOM.SetNodeNameResponse> SetNodeName()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets node value for a node with given id.
            /// </summary>
            public Task SetNodeValue()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets node HTML markup, returns new node id.
            /// </summary>
            public Task SetOuterHTML()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Undoes the last performed action.
            /// </summary>
            public Task Undo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns iframe node that owns iframe with the given domain.
            /// </summary>
            public Task<Protocol.DOM.GetFrameOwnerResponse> GetFrameOwner()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
            /// </summary>
            public Task RemoveDOMBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes breakpoint on particular DOM event.
            /// </summary>
            public Task RemoveEventListenerBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes breakpoint on particular native event.
            /// </summary>
            public Task RemoveInstrumentationBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes breakpoint from XMLHttpRequest.
            /// </summary>
            public Task RemoveXHRBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets breakpoint on particular operation with DOM.
            /// </summary>
            public Task SetDOMBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets breakpoint on particular DOM event.
            /// </summary>
            public Task SetEventListenerBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets breakpoint on particular native event.
            /// </summary>
            public Task SetInstrumentationBreakpoint()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets breakpoint on XMLHttpRequest.
            /// </summary>
            public Task SetXHRBreakpoint()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables DOM snapshot agent for the given page.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
            /// template contents, and imported documents) in a flattened array, as well as layout and
            /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
            /// flattened.
            /// </summary>
            public Task<Protocol.DOMSnapshot.GetSnapshotResponse> GetSnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
            /// template contents, and imported documents) in a flattened array, as well as layout and
            /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
            /// flattened.
            /// </summary>
            public Task<Protocol.DOMSnapshot.CaptureSnapshotResponse> CaptureSnapshot()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables storage tracking, prevents storage events from being sent to the client.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables storage tracking, storage events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.DOMStorage.GetDOMStorageItemsResponse> GetDOMStorageItems()
            {
                throw new NotImplementedException();
            }

            public Task RemoveDOMStorageItem()
            {
                throw new NotImplementedException();
            }

            public Task SetDOMStorageItem()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables database tracking, database events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.Database.ExecuteSQLResponse> ExecuteSQL()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.Database.GetDatabaseTableNamesResponse> GetDatabaseTableNames()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the Device Orientation.
            /// </summary>
            public Task SetDeviceOrientationOverride()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears the overriden device metrics.
            /// </summary>
            public Task ClearDeviceMetricsOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears the overriden Geolocation Position and Error.
            /// </summary>
            public Task ClearGeolocationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that page scale factor is reset to initial values.
            /// </summary>
            public Task ResetPageScaleFactor()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables or disables simulating a focused and active page.
            /// </summary>
            public Task SetFocusEmulationEnabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables CPU throttling to emulate slow CPUs.
            /// </summary>
            public Task SetCPUThrottlingRate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets or clears an override of the default background color of the frame. This override is used
            /// if the content does not specify one.
            /// </summary>
            public Task SetDefaultBackgroundColorOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
            /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
            /// query results).
            /// </summary>
            public Task SetDeviceMetricsOverride()
            {
                throw new NotImplementedException();
            }

            public Task SetScrollbarsHidden()
            {
                throw new NotImplementedException();
            }

            public Task SetDocumentCookieDisabled()
            {
                throw new NotImplementedException();
            }

            public Task SetEmitTouchEventsForMouse()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Emulates the given media for CSS media queries.
            /// </summary>
            public Task SetEmulatedMedia()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
            /// unavailable.
            /// </summary>
            public Task SetGeolocationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides value returned by the javascript navigator object.
            /// </summary>
            public Task SetNavigatorOverrides()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets a specified page scale factor.
            /// </summary>
            public Task SetPageScaleFactor()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Switches script execution in the page.
            /// </summary>
            public Task SetScriptExecutionDisabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables touch on platforms which do not support them.
            /// </summary>
            public Task SetTouchEmulationEnabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
            /// the current virtual time policy.  Note this supersedes any previous time budget.
            /// </summary>
            public Task<Protocol.Emulation.SetVirtualTimePolicyResponse> SetVirtualTimePolicy()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Resizes the frame/viewport of the page. Note that this does not affect the frame's container
            /// (e.g. browser window). Can be used to produce screenshots of the specified size. Not supported
            /// on Android.
            /// </summary>
            public Task SetVisibleSize()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Allows overriding user agent with the given string.
            /// </summary>
            public Task SetUserAgentOverride()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables headless events for the target.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables headless events for the target.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Read a chunk of the stream
            /// </summary>
            public Task<Protocol.IO.ReadResponse> Read()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Return UUID of Blob object specified by a remote object id.
            /// </summary>
            public Task<Protocol.IO.ResolveBlobResponse> ResolveBlob()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deletes a database.
            /// </summary>
            public Task DeleteDatabase()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Delete a range of entries from an object store
            /// </summary>
            public Task DeleteObjectStoreEntries()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables events from backend.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables events from backend.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests data from object store or index.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDataResponse> RequestData()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests database with given name in given frame.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDatabaseResponse> RequestDatabase()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests database names for given security origin.
            /// </summary>
            public Task<Protocol.IndexedDB.RequestDatabaseNamesResponse> RequestDatabaseNames()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method emulates inserting text that doesn't come from a key press,
            /// for example an emoji keyboard or an IME.
            /// </summary>
            public Task InsertText()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Dispatches a mouse event to the page.
            /// </summary>
            public Task DispatchMouseEvent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Dispatches a touch event to the page.
            /// </summary>
            public Task DispatchTouchEvent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Emulates touch event from the mouse event parameters.
            /// </summary>
            public Task EmulateTouchFromMouseEvent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Ignores input events (useful while auditing page).
            /// </summary>
            public Task SetIgnoreInputEvents()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizePinchGesture()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizeScrollGesture()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
            /// </summary>
            public Task SynthesizeTapGesture()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables inspector domain notifications.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables compositing tree inspection.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables compositing tree inspection.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the snapshot identifier.
            /// </summary>
            public Task<Protocol.LayerTree.LoadSnapshotResponse> LoadSnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the layer snapshot identifier.
            /// </summary>
            public Task<Protocol.LayerTree.MakeSnapshotResponse> MakeSnapshot()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.LayerTree.ProfileSnapshotResponse> ProfileSnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Releases layer snapshot captured by the back-end.
            /// </summary>
            public Task ReleaseSnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Replays the layer snapshot and returns the resulting bitmap.
            /// </summary>
            public Task<Protocol.LayerTree.ReplaySnapshotResponse> ReplaySnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Replays the layer snapshot and returns canvas log.
            /// </summary>
            public Task<Protocol.LayerTree.SnapshotCommandLogResponse> SnapshotCommandLog()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables log domain, prevents further log entries from being reported to the client.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables log domain, sends the entries collected so far to the client by means of the
            /// `entryAdded` notification.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// start violation reporting.
            /// </summary>
            public Task StartViolationsReport()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stop violation reporting.
            /// </summary>
            public Task StopViolationsReport()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public Task PrepareForLeakDetection()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable/disable suppressing memory pressure notifications in all processes.
            /// </summary>
            public Task SetPressureNotificationsSuppressed()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Simulate a memory pressure notification in all processes.
            /// </summary>
            public Task SimulatePressureNotification()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Start collecting native memory profile.
            /// </summary>
            public Task StartSampling()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stop collecting native memory profile.
            /// </summary>
            public Task StopSampling()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieve native memory allocations profile
            /// collected since renderer process startup.
            /// </summary>
            public Task<Protocol.Memory.GetAllTimeSamplingProfileResponse> GetAllTimeSamplingProfile()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieve native memory allocations profile
            /// collected since browser process startup.
            /// </summary>
            public Task<Protocol.Memory.GetBrowserSamplingProfileResponse> GetBrowserSamplingProfile()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieve native memory allocations profile collected since last
            /// `startSampling` call.
            /// </summary>
            public Task<Protocol.Memory.GetSamplingProfileResponse> GetSamplingProfile()
            {
                throw new NotImplementedException();
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
            public Task<Protocol.Network.CanClearBrowserCacheResponse> CanClearBrowserCache()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Tells whether clearing browser cookies is supported.
            /// </summary>
            public Task<Protocol.Network.CanClearBrowserCookiesResponse> CanClearBrowserCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Tells whether emulation of network conditions is supported.
            /// </summary>
            public Task<Protocol.Network.CanEmulateNetworkConditionsResponse> CanEmulateNetworkConditions()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears browser cache.
            /// </summary>
            public Task ClearBrowserCache()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears browser cookies.
            /// </summary>
            public Task ClearBrowserCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Response to Network.requestIntercepted which either modifies the request to continue with any
            /// modifications, or blocks it, or completes it with the provided response bytes. If a network
            /// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
            /// event will be sent with the same InterceptionId.
            /// </summary>
            public Task ContinueInterceptedRequest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deletes browser cookies with matching name and url or domain/path pair.
            /// </summary>
            public Task DeleteCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables network tracking, prevents network events from being sent to the client.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Activates emulation of network conditions.
            /// </summary>
            public Task EmulateNetworkConditions()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables network tracking, network events will now be delivered to the client.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
            /// information in the `cookies` field.
            /// </summary>
            public Task<Protocol.Network.GetAllCookiesResponse> GetAllCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns the DER-encoded certificate.
            /// </summary>
            public Task<Protocol.Network.GetCertificateResponse> GetCertificate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all browser cookies for the current URL. Depending on the backend support, will return
            /// detailed cookie information in the `cookies` field.
            /// </summary>
            public Task<Protocol.Network.GetCookiesResponse> GetCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns content served for the given request.
            /// </summary>
            public Task<Protocol.Network.GetResponseBodyResponse> GetResponseBody()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns post data sent with the request. Returns an error when no data was sent with the request.
            /// </summary>
            public Task<Protocol.Network.GetRequestPostDataResponse> GetRequestPostData()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns content served for the given currently intercepted request.
            /// </summary>
            public Task<Protocol.Network.GetResponseBodyForInterceptionResponse> GetResponseBodyForInterception()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns a handle to the stream representing the response body. Note that after this command,
            /// the intercepted request can't be continued as is -- you either need to cancel it or to provide
            /// the response body. The stream only supports sequential read, IO.read will fail if the position
            /// is specified.
            /// </summary>
            public Task<Protocol.Network.TakeResponseBodyForInterceptionAsStreamResponse> TakeResponseBodyForInterceptionAsStream()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// This method sends a new XMLHttpRequest which is identical to the original one. The following
            /// parameters should be identical: method, url, async, request body, extra headers, withCredentials
            /// attribute, user, password.
            /// </summary>
            public Task ReplayXHR()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Searches for given string in response content.
            /// </summary>
            public Task<Protocol.Network.SearchInResponseBodyResponse> SearchInResponseBody()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Blocks URLs from loading.
            /// </summary>
            public Task SetBlockedURLs()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Toggles ignoring of service worker for each request.
            /// </summary>
            public Task SetBypassServiceWorker()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Toggles ignoring cache for each request. If `true`, cache will not be used.
            /// </summary>
            public Task SetCacheDisabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
            /// </summary>
            public Task<Protocol.Network.SetCookieResponse> SetCookie()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets given cookies.
            /// </summary>
            public Task SetCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// For testing.
            /// </summary>
            public Task SetDataSizeLimitsForTest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Specifies whether to always send extra HTTP headers with the requests from this page.
            /// </summary>
            public Task SetExtraHTTPHeaders()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the requests to intercept that match a the provided patterns and optionally resource types.
            /// </summary>
            public Task SetRequestInterception()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Allows overriding user agent with the given string.
            /// </summary>
            public Task SetUserAgentOverride()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables domain notifications.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// For testing.
            /// </summary>
            public Task<Protocol.Overlay.GetHighlightObjectForTestResponse> GetHighlightObjectForTest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Hides any highlight.
            /// </summary>
            public Task HideHighlight()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights owner element of the frame with given id.
            /// </summary>
            public Task HighlightFrame()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
            /// objectId must be specified.
            /// </summary>
            public Task HighlightNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
            /// </summary>
            public Task HighlightQuad()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
            /// </summary>
            public Task HighlightRect()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
            /// Backend then generates 'inspectNodeRequested' event upon element selection.
            /// </summary>
            public Task SetInspectMode()
            {
                throw new NotImplementedException();
            }

            public Task SetPausedInDebuggerMessage()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that backend shows debug borders on layers
            /// </summary>
            public Task SetShowDebugBorders()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that backend shows the FPS counter
            /// </summary>
            public Task SetShowFPSCounter()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that backend shows paint rectangles
            /// </summary>
            public Task SetShowPaintRects()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that backend shows scroll bottleneck rects
            /// </summary>
            public Task SetShowScrollBottleneckRects()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Requests that backend shows hit-test borders on layers
            /// </summary>
            public Task SetShowHitTestBorders()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Paints viewport size upon main frame resize.
            /// </summary>
            public Task SetShowViewportSizeOnResize()
            {
                throw new NotImplementedException();
            }

            public Task SetSuspended()
            {
                throw new NotImplementedException();
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
            public Task<Protocol.Page.AddScriptToEvaluateOnLoadResponse> AddScriptToEvaluateOnLoad()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Evaluates given script in every frame upon creation (before loading frame's scripts).
            /// </summary>
            public Task<Protocol.Page.AddScriptToEvaluateOnNewDocumentResponse> AddScriptToEvaluateOnNewDocument()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Brings page to front (activates tab).
            /// </summary>
            public Task BringToFront()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Capture page screenshot.
            /// </summary>
            public Task<Protocol.Page.CaptureScreenshotResponse> CaptureScreenshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
            /// iframes, shadow DOM, external resources, and element-inline styles.
            /// </summary>
            public Task<Protocol.Page.CaptureSnapshotResponse> CaptureSnapshot()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears the overriden device metrics.
            /// </summary>
            public Task ClearDeviceMetricsOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears the overridden Device Orientation.
            /// </summary>
            public Task ClearDeviceOrientationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears the overriden Geolocation Position and Error.
            /// </summary>
            public Task ClearGeolocationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Creates an isolated world for the given frame.
            /// </summary>
            public Task<Protocol.Page.CreateIsolatedWorldResponse> CreateIsolatedWorld()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deletes browser cookie with given name, domain and path.
            /// </summary>
            public Task DeleteCookie()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Disables page domain notifications.
            /// </summary>
            public Task Disable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables page domain notifications.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            public Task<Protocol.Page.GetAppManifestResponse> GetAppManifest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
            /// information in the `cookies` field.
            /// </summary>
            public Task<Protocol.Page.GetCookiesResponse> GetCookies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns present frame tree structure.
            /// </summary>
            public Task<Protocol.Page.GetFrameTreeResponse> GetFrameTree()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns metrics relating to the layouting of the page, such as viewport bounds/scale.
            /// </summary>
            public Task<Protocol.Page.GetLayoutMetricsResponse> GetLayoutMetrics()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns navigation history for the current page.
            /// </summary>
            public Task<Protocol.Page.GetNavigationHistoryResponse> GetNavigationHistory()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Resets navigation history for the current page.
            /// </summary>
            public Task ResetNavigationHistory()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns content of the given resource.
            /// </summary>
            public Task<Protocol.Page.GetResourceContentResponse> GetResourceContent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns present frame / resource tree structure.
            /// </summary>
            public Task<Protocol.Page.GetResourceTreeResponse> GetResourceTree()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
            /// </summary>
            public Task HandleJavaScriptDialog()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Navigates current page to the given URL.
            /// </summary>
            public Task<Protocol.Page.NavigateResponse> Navigate()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Navigates current page to the given history entry.
            /// </summary>
            public Task NavigateToHistoryEntry()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Print page as PDF.
            /// </summary>
            public Task<Protocol.Page.PrintToPDFResponse> PrintToPDF()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reloads given page optionally ignoring the cache.
            /// </summary>
            public Task Reload()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
            /// </summary>
            public Task RemoveScriptToEvaluateOnLoad()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes given script from the list.
            /// </summary>
            public Task RemoveScriptToEvaluateOnNewDocument()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Acknowledges that a screencast frame has been received by the frontend.
            /// </summary>
            public Task ScreencastFrameAck()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Searches for given string in resource content.
            /// </summary>
            public Task<Protocol.Page.SearchInResourceResponse> SearchInResource()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable Chrome's experimental ad filter on all sites.
            /// </summary>
            public Task SetAdBlockingEnabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable page Content Security Policy by-passing.
            /// </summary>
            public Task SetBypassCSP()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
            /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
            /// query results).
            /// </summary>
            public Task SetDeviceMetricsOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the Device Orientation.
            /// </summary>
            public Task SetDeviceOrientationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Set generic font families.
            /// </summary>
            public Task SetFontFamilies()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Set default font sizes.
            /// </summary>
            public Task SetFontSizes()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets given markup as the document's HTML.
            /// </summary>
            public Task SetDocumentContent()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Set the behavior when downloading a file.
            /// </summary>
            public Task SetDownloadBehavior()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
            /// unavailable.
            /// </summary>
            public Task SetGeolocationOverride()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Controls whether page will emit lifecycle events.
            /// </summary>
            public Task SetLifecycleEventsEnabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Toggles mouse event-based touch event emulation.
            /// </summary>
            public Task SetTouchEmulationEnabled()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Starts sending each frame using the `screencastFrame` event.
            /// </summary>
            public Task StartScreencast()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Force the page stop all navigations and pending resource fetches.
            /// </summary>
            public Task StopLoading()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Crashes renderer on the IO thread, generates minidumps.
            /// </summary>
            public Task Crash()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Tries to close page, running its beforeunload hooks, if any.
            /// </summary>
            public Task Close()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Tries to update the web lifecycle state of the page.
            /// It will transition the page to the given state according to:
            /// https://github.com/WICG/web-lifecycle/
            /// </summary>
            public Task SetWebLifecycleState()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Stops sending each frame in the `screencastFrame`.
            /// </summary>
            public Task StopScreencast()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Forces compilation cache to be generated for every subresource script.
            /// </summary>
            public Task SetProduceCompilationCache()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Seeds compilation cache for given url. Compilation cache does not survive
            /// cross-process navigation.
            /// </summary>
            public Task AddCompilationCache()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Clears seeded compilation cache.
            /// </summary>
            public Task ClearCompilationCache()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Generates a report for testing.
            /// </summary>
            public Task GenerateTestReport()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
            /// </summary>
            public Task WaitForDebugger()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable collecting and reporting metrics.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets time domain to use for collecting and reporting duration metrics.
            /// Note that this must be called before enabling metrics collection. Calling
            /// this method while metrics collection is enabled returns an error.
            /// </summary>
            public Task SetTimeDomain()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieve current values of run-time metrics.
            /// </summary>
            public Task<Protocol.Performance.GetMetricsResponse> GetMetrics()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables tracking security state changes.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable/disable whether all certificate errors should be ignored.
            /// </summary>
            public Task SetIgnoreCertificateErrors()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Handles a certificate error that fired a certificateError event.
            /// </summary>
            public Task HandleCertificateError()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
            /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
            /// </summary>
            public Task SetOverrideCertificateErrors()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public Task Disable()
            {
                throw new NotImplementedException();
            }

            public Task DispatchSyncEvent()
            {
                throw new NotImplementedException();
            }

            public Task Enable()
            {
                throw new NotImplementedException();
            }

            public Task InspectWorker()
            {
                throw new NotImplementedException();
            }

            public Task SetForceUpdateOnPageLoad()
            {
                throw new NotImplementedException();
            }

            public Task SkipWaiting()
            {
                throw new NotImplementedException();
            }

            public Task StartWorker()
            {
                throw new NotImplementedException();
            }

            public Task StopAllWorkers()
            {
                throw new NotImplementedException();
            }

            public Task StopWorker()
            {
                throw new NotImplementedException();
            }

            public Task Unregister()
            {
                throw new NotImplementedException();
            }

            public Task UpdateRegistration()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns usage and quota in bytes.
            /// </summary>
            public Task<Protocol.Storage.GetUsageAndQuotaResponse> GetUsageAndQuota()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Registers origin to be notified when an update occurs to its cache storage list.
            /// </summary>
            public Task TrackCacheStorageForOrigin()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Registers origin to be notified when an update occurs to its IndexedDB.
            /// </summary>
            public Task TrackIndexedDBForOrigin()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Unregisters origin from receiving notifications for cache storage.
            /// </summary>
            public Task UntrackCacheStorageForOrigin()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Unregisters origin from receiving notifications for IndexedDB.
            /// </summary>
            public Task UntrackIndexedDBForOrigin()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns information about all running processes.
            /// </summary>
            public Task<Protocol.SystemInfo.GetProcessInfoResponse> GetProcessInfo()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Attaches to the target with given id.
            /// </summary>
            public Task<Protocol.Target.AttachToTargetResponse> AttachToTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Attaches to the browser target, only uses flat sessionId mode.
            /// </summary>
            public Task<Protocol.Target.AttachToBrowserTargetResponse> AttachToBrowserTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Closes the target. If the target is a page that gets closed too.
            /// </summary>
            public Task<Protocol.Target.CloseTargetResponse> CloseTarget()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
            /// one.
            /// </summary>
            public Task<Protocol.Target.CreateBrowserContextResponse> CreateBrowserContext()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns all browser contexts created with `Target.createBrowserContext` method.
            /// </summary>
            public Task<Protocol.Target.GetBrowserContextsResponse> GetBrowserContexts()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Creates a new page.
            /// </summary>
            public Task<Protocol.Target.CreateTargetResponse> CreateTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Detaches session with given id.
            /// </summary>
            public Task DetachFromTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Deletes a BrowserContext. All the belonging pages will be closed without calling their
            /// beforeunload hooks.
            /// </summary>
            public Task DisposeBrowserContext()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Returns information about a target.
            /// </summary>
            public Task<Protocol.Target.GetTargetInfoResponse> GetTargetInfo()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieves a list of available targets.
            /// </summary>
            public Task<Protocol.Target.GetTargetsResponse> GetTargets()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sends protocol message over session with given id.
            /// </summary>
            public Task SendMessageToTarget()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Controls whether to automatically attach to new targets which are considered to be related to
            /// this one. When turned on, attaches to all existing related targets as well. When turned off,
            /// automatically detaches from all currently attached targets.
            /// </summary>
            public Task SetAutoAttach()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Controls whether to discover available targets and notify via
            /// `targetCreated/targetInfoChanged/targetDestroyed` events.
            /// </summary>
            public Task SetDiscoverTargets()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
            /// `true`.
            /// </summary>
            public Task SetRemoteLocations()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Request browser port unbinding.
            /// </summary>
            public Task Unbind()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets supported tracing categories.
            /// </summary>
            public Task<Protocol.Tracing.GetCategoriesResponse> GetCategories()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Record a clock sync marker in the trace.
            /// </summary>
            public Task RecordClockSyncMarker()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Request a global memory dump.
            /// </summary>
            public Task<Protocol.Tracing.RequestMemoryDumpResponse> RequestMemoryDump()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Start trace events collection.
            /// </summary>
            public Task Start()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            /// <summary>
            /// Enables issuing of requestPaused events. A request will be paused until client
            /// calls one of failRequest, fulfillRequest or continueRequest/continueWithAuth.
            /// </summary>
            public Task Enable()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Causes the request to fail with specified reason.
            /// </summary>
            public Task FailRequest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Provides response to the request.
            /// </summary>
            public Task FulfillRequest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Continues the request, optionally modifying some of its parameters.
            /// </summary>
            public Task ContinueRequest()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Continues a request supplying authChallengeResponse following authRequired event.
            /// </summary>
            public Task ContinueWithAuth()
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}
