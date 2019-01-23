using System;

namespace DumbPrograms.ChromeDevTools.Protocol
{

    namespace Accessibility
    {

        /// <summary>
        /// Unique accessibility node identifier.
        /// </summary>
        public class AXNodeId
        {
        }

        /// <summary>
        /// Enum of possible property types.
        /// </summary>
        public class AXValueType
        {
        }

        /// <summary>
        /// Enum of possible property sources.
        /// </summary>
        public class AXValueSourceType
        {
        }

        /// <summary>
        /// Enum of possible native property sources (as a subtype of a particular AXValueSourceType).
        /// </summary>
        public class AXValueNativeSourceType
        {
        }

        /// <summary>
        /// A single source for a computed AX property.
        /// </summary>
        public class AXValueSource
        {
        }

        public class AXRelatedNode
        {
        }

        public class AXProperty
        {
        }

        /// <summary>
        /// A single computed AX property.
        /// </summary>
        public class AXValue
        {
        }

        /// <summary>
        /// Values of AXProperty name:
        /// - from 'busy' to 'roledescription': states which apply to every AX node
        /// - from 'live' to 'root': attributes which apply to nodes in live regions
        /// - from 'autocomplete' to 'valuetext': attributes which apply to widgets
        /// - from 'checked' to 'selected': states which apply to widgets
        /// - from 'activedescendant' to 'owns' - relationships between elements other than parent/child/sibling.
        /// </summary>
        public class AXPropertyName
        {
        }

        /// <summary>
        /// A node in the accessibility tree.
        /// </summary>
        public class AXNode
        {
        }

        /// <summary>
        /// Disables the accessibility domain.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Accessibility.disable";
        }

        /// <summary>
        /// Enables the accessibility domain which causes `AXNodeId`s to remain consistent between method calls.
        /// This turns on accessibility for the page, which can impact performance until accessibility is disabled.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Accessibility.enable";
        }

        /// <summary>
        /// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
        /// </summary>
        public class GetPartialAXTreeCommand : ICommand<GetPartialAXTreeResponse>
        {
            string ICommand.Name { get; } = "Accessibility.getPartialAXTree";
        }

        public class GetPartialAXTreeResponse
        {
        }

        /// <summary>
        /// Fetches the entire accessibility tree
        /// </summary>
        public class GetFullAXTreeCommand : ICommand<GetFullAXTreeResponse>
        {
            string ICommand.Name { get; } = "Accessibility.getFullAXTree";
        }

        public class GetFullAXTreeResponse
        {
        }
    }

    namespace Animation
    {

        /// <summary>
        /// Animation instance.
        /// </summary>
        public class Animation
        {
        }

        /// <summary>
        /// AnimationEffect instance
        /// </summary>
        public class AnimationEffect
        {
        }

        /// <summary>
        /// Keyframes Rule
        /// </summary>
        public class KeyframesRule
        {
        }

        /// <summary>
        /// Keyframe Style
        /// </summary>
        public class KeyframeStyle
        {
        }

        /// <summary>
        /// Disables animation domain notifications.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.disable";
        }

        /// <summary>
        /// Enables animation domain notifications.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.enable";
        }

        /// <summary>
        /// Returns the current time of the an animation.
        /// </summary>
        public class GetCurrentTimeCommand : ICommand<GetCurrentTimeResponse>
        {
            string ICommand.Name { get; } = "Animation.getCurrentTime";
        }

        public class GetCurrentTimeResponse
        {
        }

        /// <summary>
        /// Gets the playback rate of the document timeline.
        /// </summary>
        public class GetPlaybackRateCommand : ICommand<GetPlaybackRateResponse>
        {
            string ICommand.Name { get; } = "Animation.getPlaybackRate";
        }

        public class GetPlaybackRateResponse
        {
        }

        /// <summary>
        /// Releases a set of animations to no longer be manipulated.
        /// </summary>
        public class ReleaseAnimationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.releaseAnimations";
        }

        /// <summary>
        /// Gets the remote object of the Animation.
        /// </summary>
        public class ResolveAnimationCommand : ICommand<ResolveAnimationResponse>
        {
            string ICommand.Name { get; } = "Animation.resolveAnimation";
        }

        public class ResolveAnimationResponse
        {
        }

        /// <summary>
        /// Seek a set of animations to a particular time within each animation.
        /// </summary>
        public class SeekAnimationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.seekAnimations";
        }

        /// <summary>
        /// Sets the paused state of a set of animations.
        /// </summary>
        public class SetPausedCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setPaused";
        }

        /// <summary>
        /// Sets the playback rate of the document timeline.
        /// </summary>
        public class SetPlaybackRateCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setPlaybackRate";
        }

        /// <summary>
        /// Sets the timing of an animation node.
        /// </summary>
        public class SetTimingCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setTiming";
        }
    }

    namespace ApplicationCache
    {

        /// <summary>
        /// Detailed application cache resource information.
        /// </summary>
        public class ApplicationCacheResource
        {
        }

        /// <summary>
        /// Detailed application cache information.
        /// </summary>
        public class ApplicationCache
        {
        }

        /// <summary>
        /// Frame identifier - manifest URL pair.
        /// </summary>
        public class FrameWithManifest
        {
        }

        /// <summary>
        /// Enables application cache domain notifications.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "ApplicationCache.enable";
        }

        /// <summary>
        /// Returns relevant application cache data for the document in given frame.
        /// </summary>
        public class GetApplicationCacheForFrameCommand : ICommand<GetApplicationCacheForFrameResponse>
        {
            string ICommand.Name { get; } = "ApplicationCache.getApplicationCacheForFrame";
        }

        public class GetApplicationCacheForFrameResponse
        {
        }

        /// <summary>
        /// Returns array of frame identifiers with manifest urls for each frame containing a document
        /// associated with some application cache.
        /// </summary>
        public class GetFramesWithManifestsCommand : ICommand<GetFramesWithManifestsResponse>
        {
            string ICommand.Name { get; } = "ApplicationCache.getFramesWithManifests";
        }

        public class GetFramesWithManifestsResponse
        {
        }

        /// <summary>
        /// Returns manifest URL for document in the given frame.
        /// </summary>
        public class GetManifestForFrameCommand : ICommand<GetManifestForFrameResponse>
        {
            string ICommand.Name { get; } = "ApplicationCache.getManifestForFrame";
        }

        public class GetManifestForFrameResponse
        {
        }
    }

    /// <summary>
    /// Audits domain allows investigation of page violations and possible improvements.
    /// </summary>
    namespace Audits
    {

        /// <summary>
        /// Returns the response body and size if it were re-encoded with the specified settings. Only
        /// applies to images.
        /// </summary>
        public class GetEncodedResponseCommand : ICommand<GetEncodedResponseResponse>
        {
            string ICommand.Name { get; } = "Audits.getEncodedResponse";
        }

        public class GetEncodedResponseResponse
        {
        }
    }

    /// <summary>
    /// The Browser domain defines methods and events for browser managing.
    /// </summary>
    namespace Browser
    {

        public class WindowID
        {
        }

        /// <summary>
        /// The state of the browser window.
        /// </summary>
        public class WindowState
        {
        }

        /// <summary>
        /// Browser window bounds information
        /// </summary>
        public class Bounds
        {
        }

        public class PermissionType
        {
        }

        /// <summary>
        /// Chrome histogram bucket.
        /// </summary>
        public class Bucket
        {
        }

        /// <summary>
        /// Chrome histogram.
        /// </summary>
        public class Histogram
        {
        }

        /// <summary>
        /// Grant specific permissions to the given origin and reject all others.
        /// </summary>
        public class GrantPermissionsCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.grantPermissions";
        }

        /// <summary>
        /// Reset all permission management for all origins.
        /// </summary>
        public class ResetPermissionsCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.resetPermissions";
        }

        /// <summary>
        /// Close browser gracefully.
        /// </summary>
        public class CloseCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.close";
        }

        /// <summary>
        /// Crashes browser on the main thread.
        /// </summary>
        public class CrashCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.crash";
        }

        /// <summary>
        /// Returns version information.
        /// </summary>
        public class GetVersionCommand : ICommand<GetVersionResponse>
        {
            string ICommand.Name { get; } = "Browser.getVersion";
        }

        public class GetVersionResponse
        {
        }

        /// <summary>
        /// Returns the command line switches for the browser process if, and only if
        /// --enable-automation is on the commandline.
        /// </summary>
        public class GetBrowserCommandLineCommand : ICommand<GetBrowserCommandLineResponse>
        {
            string ICommand.Name { get; } = "Browser.getBrowserCommandLine";
        }

        public class GetBrowserCommandLineResponse
        {
        }

        /// <summary>
        /// Get Chrome histograms.
        /// </summary>
        public class GetHistogramsCommand : ICommand<GetHistogramsResponse>
        {
            string ICommand.Name { get; } = "Browser.getHistograms";
        }

        public class GetHistogramsResponse
        {
        }

        /// <summary>
        /// Get a Chrome histogram by name.
        /// </summary>
        public class GetHistogramCommand : ICommand<GetHistogramResponse>
        {
            string ICommand.Name { get; } = "Browser.getHistogram";
        }

        public class GetHistogramResponse
        {
        }

        /// <summary>
        /// Get position and size of the browser window.
        /// </summary>
        public class GetWindowBoundsCommand : ICommand<GetWindowBoundsResponse>
        {
            string ICommand.Name { get; } = "Browser.getWindowBounds";
        }

        public class GetWindowBoundsResponse
        {
        }

        /// <summary>
        /// Get the browser window that contains the devtools target.
        /// </summary>
        public class GetWindowForTargetCommand : ICommand<GetWindowForTargetResponse>
        {
            string ICommand.Name { get; } = "Browser.getWindowForTarget";
        }

        public class GetWindowForTargetResponse
        {
        }

        /// <summary>
        /// Set position and/or size of the browser window.
        /// </summary>
        public class SetWindowBoundsCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.setWindowBounds";
        }

        /// <summary>
        /// Set dock tile details, platform-specific.
        /// </summary>
        public class SetDockTileCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.setDockTile";
        }
    }

    /// <summary>
    /// This domain exposes CSS read/write operations. All CSS objects (stylesheets, rules, and styles)
    /// have an associated `id` used in subsequent operations on the related object. Each object type has
    /// a specific `id` structure, and those are not interchangeable between objects of different kinds.
    /// CSS objects can be loaded using the `get*ForNode()` calls (which accept a DOM node id). A client
    /// can also keep track of stylesheets via the `styleSheetAdded`/`styleSheetRemoved` events and
    /// subsequently load the required stylesheet contents using the `getStyleSheet[Text]()` methods.
    /// </summary>
    namespace CSS
    {

        public class StyleSheetId
        {
        }

        /// <summary>
        /// Stylesheet type: "injected" for stylesheets injected via extension, "user-agent" for user-agent
        /// stylesheets, "inspector" for stylesheets created by the inspector (i.e. those holding the "via
        /// inspector" rules), "regular" for regular stylesheets.
        /// </summary>
        public class StyleSheetOrigin
        {
        }

        /// <summary>
        /// CSS rule collection for a single pseudo style.
        /// </summary>
        public class PseudoElementMatches
        {
        }

        /// <summary>
        /// Inherited CSS rule collection from ancestor node.
        /// </summary>
        public class InheritedStyleEntry
        {
        }

        /// <summary>
        /// Match data for a CSS rule.
        /// </summary>
        public class RuleMatch
        {
        }

        /// <summary>
        /// Data for a simple selector (these are delimited by commas in a selector list).
        /// </summary>
        public class Value
        {
        }

        /// <summary>
        /// Selector list data.
        /// </summary>
        public class SelectorList
        {
        }

        /// <summary>
        /// CSS stylesheet metainformation.
        /// </summary>
        public class CSSStyleSheetHeader
        {
        }

        /// <summary>
        /// CSS rule representation.
        /// </summary>
        public class CSSRule
        {
        }

        /// <summary>
        /// CSS coverage information.
        /// </summary>
        public class RuleUsage
        {
        }

        /// <summary>
        /// Text range within a resource. All numbers are zero-based.
        /// </summary>
        public class SourceRange
        {
        }

        public class ShorthandEntry
        {
        }

        public class CSSComputedStyleProperty
        {
        }

        /// <summary>
        /// CSS style representation.
        /// </summary>
        public class CSSStyle
        {
        }

        /// <summary>
        /// CSS property declaration data.
        /// </summary>
        public class CSSProperty
        {
        }

        /// <summary>
        /// CSS media rule descriptor.
        /// </summary>
        public class CSSMedia
        {
        }

        /// <summary>
        /// Media query descriptor.
        /// </summary>
        public class MediaQuery
        {
        }

        /// <summary>
        /// Media query expression descriptor.
        /// </summary>
        public class MediaQueryExpression
        {
        }

        /// <summary>
        /// Information about amount of glyphs that were rendered with given font.
        /// </summary>
        public class PlatformFontUsage
        {
        }

        /// <summary>
        /// Properties of a web font: https://www.w3.org/TR/2008/REC-CSS2-20080411/fonts.html#font-descriptions
        /// </summary>
        public class FontFace
        {
        }

        /// <summary>
        /// CSS keyframes rule representation.
        /// </summary>
        public class CSSKeyframesRule
        {
        }

        /// <summary>
        /// CSS keyframe rule representation.
        /// </summary>
        public class CSSKeyframeRule
        {
        }

        /// <summary>
        /// A descriptor of operation to mutate style declaration text.
        /// </summary>
        public class StyleDeclarationEdit
        {
        }

        /// <summary>
        /// Inserts a new rule with the given `ruleText` in a stylesheet with given `styleSheetId`, at the
        /// position specified by `location`.
        /// </summary>
        public class AddRuleCommand : ICommand<AddRuleResponse>
        {
            string ICommand.Name { get; } = "CSS.addRule";
        }

        public class AddRuleResponse
        {
        }

        /// <summary>
        /// Returns all class names from specified stylesheet.
        /// </summary>
        public class CollectClassNamesCommand : ICommand<CollectClassNamesResponse>
        {
            string ICommand.Name { get; } = "CSS.collectClassNames";
        }

        public class CollectClassNamesResponse
        {
        }

        /// <summary>
        /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
        /// </summary>
        public class CreateStyleSheetCommand : ICommand<CreateStyleSheetResponse>
        {
            string ICommand.Name { get; } = "CSS.createStyleSheet";
        }

        public class CreateStyleSheetResponse
        {
        }

        /// <summary>
        /// Disables the CSS agent for the given page.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.disable";
        }

        /// <summary>
        /// Enables the CSS agent for the given page. Clients should not assume that the CSS agent has been
        /// enabled until the result of this command is received.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.enable";
        }

        /// <summary>
        /// Ensures that the given node will have specified pseudo-classes whenever its style is computed by
        /// the browser.
        /// </summary>
        public class ForcePseudoStateCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.forcePseudoState";
        }

        public class GetBackgroundColorsCommand : ICommand<GetBackgroundColorsResponse>
        {
            string ICommand.Name { get; } = "CSS.getBackgroundColors";
        }

        public class GetBackgroundColorsResponse
        {
        }

        /// <summary>
        /// Returns the computed style for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetComputedStyleForNodeCommand : ICommand<GetComputedStyleForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getComputedStyleForNode";
        }

        public class GetComputedStyleForNodeResponse
        {
        }

        /// <summary>
        /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
        /// attributes) for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetInlineStylesForNodeCommand : ICommand<GetInlineStylesForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getInlineStylesForNode";
        }

        public class GetInlineStylesForNodeResponse
        {
        }

        /// <summary>
        /// Returns requested styles for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetMatchedStylesForNodeCommand : ICommand<GetMatchedStylesForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getMatchedStylesForNode";
        }

        public class GetMatchedStylesForNodeResponse
        {
        }

        /// <summary>
        /// Returns all media queries parsed by the rendering engine.
        /// </summary>
        public class GetMediaQueriesCommand : ICommand<GetMediaQueriesResponse>
        {
            string ICommand.Name { get; } = "CSS.getMediaQueries";
        }

        public class GetMediaQueriesResponse
        {
        }

        /// <summary>
        /// Requests information about platform fonts which we used to render child TextNodes in the given
        /// node.
        /// </summary>
        public class GetPlatformFontsForNodeCommand : ICommand<GetPlatformFontsForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getPlatformFontsForNode";
        }

        public class GetPlatformFontsForNodeResponse
        {
        }

        /// <summary>
        /// Returns the current textual content for a stylesheet.
        /// </summary>
        public class GetStyleSheetTextCommand : ICommand<GetStyleSheetTextResponse>
        {
            string ICommand.Name { get; } = "CSS.getStyleSheetText";
        }

        public class GetStyleSheetTextResponse
        {
        }

        /// <summary>
        /// Find a rule with the given active property for the given node and set the new value for this
        /// property
        /// </summary>
        public class SetEffectivePropertyValueForNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.setEffectivePropertyValueForNode";
        }

        /// <summary>
        /// Modifies the keyframe rule key text.
        /// </summary>
        public class SetKeyframeKeyCommand : ICommand<SetKeyframeKeyResponse>
        {
            string ICommand.Name { get; } = "CSS.setKeyframeKey";
        }

        public class SetKeyframeKeyResponse
        {
        }

        /// <summary>
        /// Modifies the rule selector.
        /// </summary>
        public class SetMediaTextCommand : ICommand<SetMediaTextResponse>
        {
            string ICommand.Name { get; } = "CSS.setMediaText";
        }

        public class SetMediaTextResponse
        {
        }

        /// <summary>
        /// Modifies the rule selector.
        /// </summary>
        public class SetRuleSelectorCommand : ICommand<SetRuleSelectorResponse>
        {
            string ICommand.Name { get; } = "CSS.setRuleSelector";
        }

        public class SetRuleSelectorResponse
        {
        }

        /// <summary>
        /// Sets the new stylesheet text.
        /// </summary>
        public class SetStyleSheetTextCommand : ICommand<SetStyleSheetTextResponse>
        {
            string ICommand.Name { get; } = "CSS.setStyleSheetText";
        }

        public class SetStyleSheetTextResponse
        {
        }

        /// <summary>
        /// Applies specified style edits one after another in the given order.
        /// </summary>
        public class SetStyleTextsCommand : ICommand<SetStyleTextsResponse>
        {
            string ICommand.Name { get; } = "CSS.setStyleTexts";
        }

        public class SetStyleTextsResponse
        {
        }

        /// <summary>
        /// Enables the selector recording.
        /// </summary>
        public class StartRuleUsageTrackingCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.startRuleUsageTracking";
        }

        /// <summary>
        /// Stop tracking rule usage and return the list of rules that were used since last call to
        /// `takeCoverageDelta` (or since start of coverage instrumentation)
        /// </summary>
        public class StopRuleUsageTrackingCommand : ICommand<StopRuleUsageTrackingResponse>
        {
            string ICommand.Name { get; } = "CSS.stopRuleUsageTracking";
        }

        public class StopRuleUsageTrackingResponse
        {
        }

        /// <summary>
        /// Obtain list of rules that became used since last call to this method (or since start of coverage
        /// instrumentation)
        /// </summary>
        public class TakeCoverageDeltaCommand : ICommand<TakeCoverageDeltaResponse>
        {
            string ICommand.Name { get; } = "CSS.takeCoverageDelta";
        }

        public class TakeCoverageDeltaResponse
        {
        }
    }

    namespace CacheStorage
    {

        /// <summary>
        /// Unique identifier of the Cache object.
        /// </summary>
        public class CacheId
        {
        }

        /// <summary>
        /// type of HTTP response cached
        /// </summary>
        public class CachedResponseType
        {
        }

        /// <summary>
        /// Data entry.
        /// </summary>
        public class DataEntry
        {
        }

        /// <summary>
        /// Cache identifier.
        /// </summary>
        public class Cache
        {
        }

        public class Header
        {
        }

        /// <summary>
        /// Cached response
        /// </summary>
        public class CachedResponse
        {
        }

        /// <summary>
        /// Deletes a cache.
        /// </summary>
        public class DeleteCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "CacheStorage.deleteCache";
        }

        /// <summary>
        /// Deletes a cache entry.
        /// </summary>
        public class DeleteEntryCommand : ICommand
        {
            string ICommand.Name { get; } = "CacheStorage.deleteEntry";
        }

        /// <summary>
        /// Requests cache names.
        /// </summary>
        public class RequestCacheNamesCommand : ICommand<RequestCacheNamesResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestCacheNames";
        }

        public class RequestCacheNamesResponse
        {
        }

        /// <summary>
        /// Fetches cache entry.
        /// </summary>
        public class RequestCachedResponseCommand : ICommand<RequestCachedResponseResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestCachedResponse";
        }

        public class RequestCachedResponseResponse
        {
        }

        /// <summary>
        /// Requests data from cache.
        /// </summary>
        public class RequestEntriesCommand : ICommand<RequestEntriesResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestEntries";
        }

        public class RequestEntriesResponse
        {
        }
    }

    /// <summary>
    /// A domain for interacting with Cast, Presentation API, and Remote Playback API
    /// functionalities.
    /// </summary>
    namespace Cast
    {

        /// <summary>
        /// Starts observing for sinks that can be used for tab mirroring, and if set,
        /// sinks compatible with |presentationUrl| as well. When sinks are found, a
        /// |sinksUpdated| event is fired.
        /// Also starts observing for issue messages. When an issue is added or removed,
        /// an |issueUpdated| event is fired.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.enable";
        }

        /// <summary>
        /// Stops observing for sinks and issues.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.disable";
        }

        /// <summary>
        /// Sets a sink to be used when the web page requests the browser to choose a
        /// sink via Presentation API, Remote Playback API, or Cast SDK.
        /// </summary>
        public class SetSinkToUseCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.setSinkToUse";
        }

        /// <summary>
        /// Starts mirroring the tab to the sink.
        /// </summary>
        public class StartTabMirroringCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.startTabMirroring";
        }

        /// <summary>
        /// Stops the active Cast session on the sink.
        /// </summary>
        public class StopCastingCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.stopCasting";
        }
    }

    /// <summary>
    /// This domain exposes DOM read/write operations. Each DOM Node is represented with its mirror object
    /// that has an `id`. This `id` can be used to get additional information on the Node, resolve it into
    /// the JavaScript object wrapper, etc. It is important that client receives DOM events only for the
    /// nodes that are known to the client. Backend keeps track of the nodes that were sent to the client
    /// and never sends the same node twice. It is client's responsibility to collect information about
    /// the nodes that were sent to the client.&lt;p&gt;Note that `iframe` owner elements will return
    /// corresponding document elements as their child nodes.&lt;/p&gt;
    /// </summary>
    namespace DOM
    {

        /// <summary>
        /// Unique DOM node identifier.
        /// </summary>
        public class NodeId
        {
        }

        /// <summary>
        /// Unique DOM node identifier used to reference a node that may not have been pushed to the
        /// front-end.
        /// </summary>
        public class BackendNodeId
        {
        }

        /// <summary>
        /// Backend node with a friendly name.
        /// </summary>
        public class BackendNode
        {
        }

        /// <summary>
        /// Pseudo element type.
        /// </summary>
        public class PseudoType
        {
        }

        /// <summary>
        /// Shadow root type.
        /// </summary>
        public class ShadowRootType
        {
        }

        /// <summary>
        /// DOM interaction is implemented in terms of mirror objects that represent the actual DOM nodes.
        /// DOMNode is a base node mirror type.
        /// </summary>
        public class Node
        {
        }

        /// <summary>
        /// A structure holding an RGBA color.
        /// </summary>
        public class RGBA
        {
        }

        /// <summary>
        /// An array of quad vertices, x immediately followed by y for each point, points clock-wise.
        /// </summary>
        public class Quad
        {
        }

        /// <summary>
        /// Box model.
        /// </summary>
        public class BoxModel
        {
        }

        /// <summary>
        /// CSS Shape Outside details.
        /// </summary>
        public class ShapeOutsideInfo
        {
        }

        /// <summary>
        /// Rectangle.
        /// </summary>
        public class Rect
        {
        }

        /// <summary>
        /// Collects class names for the node with given id and all of it's child nodes.
        /// </summary>
        public class CollectClassNamesFromSubtreeCommand : ICommand<CollectClassNamesFromSubtreeResponse>
        {
            string ICommand.Name { get; } = "DOM.collectClassNamesFromSubtree";
        }

        public class CollectClassNamesFromSubtreeResponse
        {
        }

        /// <summary>
        /// Creates a deep copy of the specified node and places it into the target container before the
        /// given anchor.
        /// </summary>
        public class CopyToCommand : ICommand<CopyToResponse>
        {
            string ICommand.Name { get; } = "DOM.copyTo";
        }

        public class CopyToResponse
        {
        }

        /// <summary>
        /// Describes node given its id, does not require domain to be enabled. Does not start tracking any
        /// objects, can be used for automation.
        /// </summary>
        public class DescribeNodeCommand : ICommand<DescribeNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.describeNode";
        }

        public class DescribeNodeResponse
        {
        }

        /// <summary>
        /// Disables DOM agent for the given page.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.disable";
        }

        /// <summary>
        /// Discards search results from the session with the given id. `getSearchResults` should no longer
        /// be called for that search.
        /// </summary>
        public class DiscardSearchResultsCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.discardSearchResults";
        }

        /// <summary>
        /// Enables DOM agent for the given page.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.enable";
        }

        /// <summary>
        /// Focuses the given element.
        /// </summary>
        public class FocusCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.focus";
        }

        /// <summary>
        /// Returns attributes for the specified node.
        /// </summary>
        public class GetAttributesCommand : ICommand<GetAttributesResponse>
        {
            string ICommand.Name { get; } = "DOM.getAttributes";
        }

        public class GetAttributesResponse
        {
        }

        /// <summary>
        /// Returns boxes for the given node.
        /// </summary>
        public class GetBoxModelCommand : ICommand<GetBoxModelResponse>
        {
            string ICommand.Name { get; } = "DOM.getBoxModel";
        }

        public class GetBoxModelResponse
        {
        }

        /// <summary>
        /// Returns quads that describe node position on the page. This method
        /// might return multiple quads for inline nodes.
        /// </summary>
        public class GetContentQuadsCommand : ICommand<GetContentQuadsResponse>
        {
            string ICommand.Name { get; } = "DOM.getContentQuads";
        }

        public class GetContentQuadsResponse
        {
        }

        /// <summary>
        /// Returns the root DOM node (and optionally the subtree) to the caller.
        /// </summary>
        public class GetDocumentCommand : ICommand<GetDocumentResponse>
        {
            string ICommand.Name { get; } = "DOM.getDocument";
        }

        public class GetDocumentResponse
        {
        }

        /// <summary>
        /// Returns the root DOM node (and optionally the subtree) to the caller.
        /// </summary>
        public class GetFlattenedDocumentCommand : ICommand<GetFlattenedDocumentResponse>
        {
            string ICommand.Name { get; } = "DOM.getFlattenedDocument";
        }

        public class GetFlattenedDocumentResponse
        {
        }

        /// <summary>
        /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
        /// either returned or not.
        /// </summary>
        public class GetNodeForLocationCommand : ICommand<GetNodeForLocationResponse>
        {
            string ICommand.Name { get; } = "DOM.getNodeForLocation";
        }

        public class GetNodeForLocationResponse
        {
        }

        /// <summary>
        /// Returns node's HTML markup.
        /// </summary>
        public class GetOuterHTMLCommand : ICommand<GetOuterHTMLResponse>
        {
            string ICommand.Name { get; } = "DOM.getOuterHTML";
        }

        public class GetOuterHTMLResponse
        {
        }

        /// <summary>
        /// Returns the id of the nearest ancestor that is a relayout boundary.
        /// </summary>
        public class GetRelayoutBoundaryCommand : ICommand<GetRelayoutBoundaryResponse>
        {
            string ICommand.Name { get; } = "DOM.getRelayoutBoundary";
        }

        public class GetRelayoutBoundaryResponse
        {
        }

        /// <summary>
        /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
        /// identifier.
        /// </summary>
        public class GetSearchResultsCommand : ICommand<GetSearchResultsResponse>
        {
            string ICommand.Name { get; } = "DOM.getSearchResults";
        }

        public class GetSearchResultsResponse
        {
        }

        /// <summary>
        /// Hides any highlight.
        /// </summary>
        public class HideHighlightCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.hideHighlight";
        }

        /// <summary>
        /// Highlights DOM node.
        /// </summary>
        public class HighlightNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.highlightNode";
        }

        /// <summary>
        /// Highlights given rectangle.
        /// </summary>
        public class HighlightRectCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.highlightRect";
        }

        /// <summary>
        /// Marks last undoable state.
        /// </summary>
        public class MarkUndoableStateCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.markUndoableState";
        }

        /// <summary>
        /// Moves node into the new container, places it before the given anchor.
        /// </summary>
        public class MoveToCommand : ICommand<MoveToResponse>
        {
            string ICommand.Name { get; } = "DOM.moveTo";
        }

        public class MoveToResponse
        {
        }

        /// <summary>
        /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
        /// `cancelSearch` to end this search session.
        /// </summary>
        public class PerformSearchCommand : ICommand<PerformSearchResponse>
        {
            string ICommand.Name { get; } = "DOM.performSearch";
        }

        public class PerformSearchResponse
        {
        }

        /// <summary>
        /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
        /// </summary>
        public class PushNodeByPathToFrontendCommand : ICommand<PushNodeByPathToFrontendResponse>
        {
            string ICommand.Name { get; } = "DOM.pushNodeByPathToFrontend";
        }

        public class PushNodeByPathToFrontendResponse
        {
        }

        /// <summary>
        /// Requests that a batch of nodes is sent to the caller given their backend node ids.
        /// </summary>
        public class PushNodesByBackendIdsToFrontendCommand : ICommand<PushNodesByBackendIdsToFrontendResponse>
        {
            string ICommand.Name { get; } = "DOM.pushNodesByBackendIdsToFrontend";
        }

        public class PushNodesByBackendIdsToFrontendResponse
        {
        }

        /// <summary>
        /// Executes `querySelector` on a given node.
        /// </summary>
        public class QuerySelectorCommand : ICommand<QuerySelectorResponse>
        {
            string ICommand.Name { get; } = "DOM.querySelector";
        }

        public class QuerySelectorResponse
        {
        }

        /// <summary>
        /// Executes `querySelectorAll` on a given node.
        /// </summary>
        public class QuerySelectorAllCommand : ICommand<QuerySelectorAllResponse>
        {
            string ICommand.Name { get; } = "DOM.querySelectorAll";
        }

        public class QuerySelectorAllResponse
        {
        }

        /// <summary>
        /// Re-does the last undone action.
        /// </summary>
        public class RedoCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.redo";
        }

        /// <summary>
        /// Removes attribute with given name from an element with given id.
        /// </summary>
        public class RemoveAttributeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.removeAttribute";
        }

        /// <summary>
        /// Removes node with given id.
        /// </summary>
        public class RemoveNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.removeNode";
        }

        /// <summary>
        /// Requests that children of the node with given id are returned to the caller in form of
        /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
        /// the specified depth.
        /// </summary>
        public class RequestChildNodesCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.requestChildNodes";
        }

        /// <summary>
        /// Requests that the node is sent to the caller given the JavaScript node object reference. All
        /// nodes that form the path from the node to the root are also sent to the client as a series of
        /// `setChildNodes` notifications.
        /// </summary>
        public class RequestNodeCommand : ICommand<RequestNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.requestNode";
        }

        public class RequestNodeResponse
        {
        }

        /// <summary>
        /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
        /// </summary>
        public class ResolveNodeCommand : ICommand<ResolveNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.resolveNode";
        }

        public class ResolveNodeResponse
        {
        }

        /// <summary>
        /// Sets attribute for an element with given id.
        /// </summary>
        public class SetAttributeValueCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setAttributeValue";
        }

        /// <summary>
        /// Sets attributes on element with given id. This method is useful when user edits some existing
        /// attribute value and types in several attribute name/value pairs.
        /// </summary>
        public class SetAttributesAsTextCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setAttributesAsText";
        }

        /// <summary>
        /// Sets files for the given file input element.
        /// </summary>
        public class SetFileInputFilesCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setFileInputFiles";
        }

        /// <summary>
        /// Returns file information for the given
        /// File wrapper.
        /// </summary>
        public class GetFileInfoCommand : ICommand<GetFileInfoResponse>
        {
            string ICommand.Name { get; } = "DOM.getFileInfo";
        }

        public class GetFileInfoResponse
        {
        }

        /// <summary>
        /// Enables console to refer to the node with given id via $x (see Command Line API for more details
        /// $x functions).
        /// </summary>
        public class SetInspectedNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setInspectedNode";
        }

        /// <summary>
        /// Sets node name for a node with given id.
        /// </summary>
        public class SetNodeNameCommand : ICommand<SetNodeNameResponse>
        {
            string ICommand.Name { get; } = "DOM.setNodeName";
        }

        public class SetNodeNameResponse
        {
        }

        /// <summary>
        /// Sets node value for a node with given id.
        /// </summary>
        public class SetNodeValueCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setNodeValue";
        }

        /// <summary>
        /// Sets node HTML markup, returns new node id.
        /// </summary>
        public class SetOuterHTMLCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setOuterHTML";
        }

        /// <summary>
        /// Undoes the last performed action.
        /// </summary>
        public class UndoCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.undo";
        }

        /// <summary>
        /// Returns iframe node that owns iframe with the given domain.
        /// </summary>
        public class GetFrameOwnerCommand : ICommand<GetFrameOwnerResponse>
        {
            string ICommand.Name { get; } = "DOM.getFrameOwner";
        }

        public class GetFrameOwnerResponse
        {
        }
    }

    /// <summary>
    /// DOM debugging allows setting breakpoints on particular DOM operations and events. JavaScript
    /// execution will stop on these operations as if there was a regular breakpoint set.
    /// </summary>
    namespace DOMDebugger
    {

        /// <summary>
        /// DOM breakpoint type.
        /// </summary>
        public class DOMBreakpointType
        {
        }

        /// <summary>
        /// Object event listener.
        /// </summary>
        public class EventListener
        {
        }

        /// <summary>
        /// Returns event listeners of the given object.
        /// </summary>
        public class GetEventListenersCommand : ICommand<GetEventListenersResponse>
        {
            string ICommand.Name { get; } = "DOMDebugger.getEventListeners";
        }

        public class GetEventListenersResponse
        {
        }

        /// <summary>
        /// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
        /// </summary>
        public class RemoveDOMBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeDOMBreakpoint";
        }

        /// <summary>
        /// Removes breakpoint on particular DOM event.
        /// </summary>
        public class RemoveEventListenerBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeEventListenerBreakpoint";
        }

        /// <summary>
        /// Removes breakpoint on particular native event.
        /// </summary>
        public class RemoveInstrumentationBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeInstrumentationBreakpoint";
        }

        /// <summary>
        /// Removes breakpoint from XMLHttpRequest.
        /// </summary>
        public class RemoveXHRBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeXHRBreakpoint";
        }

        /// <summary>
        /// Sets breakpoint on particular operation with DOM.
        /// </summary>
        public class SetDOMBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setDOMBreakpoint";
        }

        /// <summary>
        /// Sets breakpoint on particular DOM event.
        /// </summary>
        public class SetEventListenerBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setEventListenerBreakpoint";
        }

        /// <summary>
        /// Sets breakpoint on particular native event.
        /// </summary>
        public class SetInstrumentationBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setInstrumentationBreakpoint";
        }

        /// <summary>
        /// Sets breakpoint on XMLHttpRequest.
        /// </summary>
        public class SetXHRBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setXHRBreakpoint";
        }
    }

    /// <summary>
    /// This domain facilitates obtaining document snapshots with DOM, layout, and style information.
    /// </summary>
    namespace DOMSnapshot
    {

        /// <summary>
        /// A Node in the DOM tree.
        /// </summary>
        public class DOMNode
        {
        }

        /// <summary>
        /// Details of post layout rendered text positions. The exact layout should not be regarded as
        /// stable and may change between versions.
        /// </summary>
        public class InlineTextBox
        {
        }

        /// <summary>
        /// Details of an element in the DOM tree with a LayoutObject.
        /// </summary>
        public class LayoutTreeNode
        {
        }

        /// <summary>
        /// A subset of the full ComputedStyle as defined by the request whitelist.
        /// </summary>
        public class ComputedStyle
        {
        }

        /// <summary>
        /// A name/value pair.
        /// </summary>
        public class NameValue
        {
        }

        /// <summary>
        /// Index of the string in the strings table.
        /// </summary>
        public class StringIndex
        {
        }

        /// <summary>
        /// Index of the string in the strings table.
        /// </summary>
        public class ArrayOfStrings
        {
        }

        /// <summary>
        /// Data that is only present on rare nodes.
        /// </summary>
        public class RareStringData
        {
        }

        public class RareBooleanData
        {
        }

        public class RareIntegerData
        {
        }

        public class Rectangle
        {
        }

        /// <summary>
        /// Document snapshot.
        /// </summary>
        public class DocumentSnapshot
        {
        }

        /// <summary>
        /// Table containing nodes.
        /// </summary>
        public class NodeTreeSnapshot
        {
        }

        /// <summary>
        /// Details of an element in the DOM tree with a LayoutObject.
        /// </summary>
        public class LayoutTreeSnapshot
        {
        }

        /// <summary>
        /// Details of post layout rendered text positions. The exact layout should not be regarded as
        /// stable and may change between versions.
        /// </summary>
        public class TextBoxSnapshot
        {
        }

        /// <summary>
        /// Disables DOM snapshot agent for the given page.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMSnapshot.disable";
        }

        /// <summary>
        /// Enables DOM snapshot agent for the given page.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMSnapshot.enable";
        }

        /// <summary>
        /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
        /// template contents, and imported documents) in a flattened array, as well as layout and
        /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
        /// flattened.
        /// </summary>
        [Obsolete]
        public class GetSnapshotCommand : ICommand<GetSnapshotResponse>
        {
            string ICommand.Name { get; } = "DOMSnapshot.getSnapshot";
        }

        public class GetSnapshotResponse
        {
        }

        /// <summary>
        /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
        /// template contents, and imported documents) in a flattened array, as well as layout and
        /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
        /// flattened.
        /// </summary>
        public class CaptureSnapshotCommand : ICommand<CaptureSnapshotResponse>
        {
            string ICommand.Name { get; } = "DOMSnapshot.captureSnapshot";
        }

        public class CaptureSnapshotResponse
        {
        }
    }

    /// <summary>
    /// Query and modify DOM storage.
    /// </summary>
    namespace DOMStorage
    {

        /// <summary>
        /// DOM Storage identifier.
        /// </summary>
        public class StorageId
        {
        }

        /// <summary>
        /// DOM Storage item.
        /// </summary>
        public class Item
        {
        }

        public class ClearCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.clear";
        }

        /// <summary>
        /// Disables storage tracking, prevents storage events from being sent to the client.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.disable";
        }

        /// <summary>
        /// Enables storage tracking, storage events will now be delivered to the client.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.enable";
        }

        public class GetDOMStorageItemsCommand : ICommand<GetDOMStorageItemsResponse>
        {
            string ICommand.Name { get; } = "DOMStorage.getDOMStorageItems";
        }

        public class GetDOMStorageItemsResponse
        {
        }

        public class RemoveDOMStorageItemCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.removeDOMStorageItem";
        }

        public class SetDOMStorageItemCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.setDOMStorageItem";
        }
    }

    namespace Database
    {

        /// <summary>
        /// Unique identifier of Database object.
        /// </summary>
        public class DatabaseId
        {
        }

        /// <summary>
        /// Database object.
        /// </summary>
        public class Database
        {
        }

        /// <summary>
        /// Database error.
        /// </summary>
        public class Error
        {
        }

        /// <summary>
        /// Disables database tracking, prevents database events from being sent to the client.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Database.disable";
        }

        /// <summary>
        /// Enables database tracking, database events will now be delivered to the client.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Database.enable";
        }

        public class ExecuteSQLCommand : ICommand<ExecuteSQLResponse>
        {
            string ICommand.Name { get; } = "Database.executeSQL";
        }

        public class ExecuteSQLResponse
        {
        }

        public class GetDatabaseTableNamesCommand : ICommand<GetDatabaseTableNamesResponse>
        {
            string ICommand.Name { get; } = "Database.getDatabaseTableNames";
        }

        public class GetDatabaseTableNamesResponse
        {
        }
    }

    namespace DeviceOrientation
    {

        /// <summary>
        /// Clears the overridden Device Orientation.
        /// </summary>
        public class ClearDeviceOrientationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "DeviceOrientation.clearDeviceOrientationOverride";
        }

        /// <summary>
        /// Overrides the Device Orientation.
        /// </summary>
        public class SetDeviceOrientationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "DeviceOrientation.setDeviceOrientationOverride";
        }
    }

    /// <summary>
    /// This domain emulates different environments for the page.
    /// </summary>
    namespace Emulation
    {

        /// <summary>
        /// Screen orientation.
        /// </summary>
        public class ScreenOrientation
        {
        }

        /// <summary>
        /// advance: If the scheduler runs out of immediate work, the virtual time base may fast forward to
        /// allow the next delayed task (if any) to run; pause: The virtual time base may not advance;
        /// pauseIfNetworkFetchesPending: The virtual time base may not advance if there are any pending
        /// resource fetches.
        /// </summary>
        public class VirtualTimePolicy
        {
        }

        /// <summary>
        /// Tells whether emulation is supported.
        /// </summary>
        public class CanEmulateCommand : ICommand<CanEmulateResponse>
        {
            string ICommand.Name { get; } = "Emulation.canEmulate";
        }

        public class CanEmulateResponse
        {
        }

        /// <summary>
        /// Clears the overriden device metrics.
        /// </summary>
        public class ClearDeviceMetricsOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.clearDeviceMetricsOverride";
        }

        /// <summary>
        /// Clears the overriden Geolocation Position and Error.
        /// </summary>
        public class ClearGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.clearGeolocationOverride";
        }

        /// <summary>
        /// Requests that page scale factor is reset to initial values.
        /// </summary>
        public class ResetPageScaleFactorCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.resetPageScaleFactor";
        }

        /// <summary>
        /// Enables or disables simulating a focused and active page.
        /// </summary>
        public class SetFocusEmulationEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setFocusEmulationEnabled";
        }

        /// <summary>
        /// Enables CPU throttling to emulate slow CPUs.
        /// </summary>
        public class SetCPUThrottlingRateCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setCPUThrottlingRate";
        }

        /// <summary>
        /// Sets or clears an override of the default background color of the frame. This override is used
        /// if the content does not specify one.
        /// </summary>
        public class SetDefaultBackgroundColorOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDefaultBackgroundColorOverride";
        }

        /// <summary>
        /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
        /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
        /// query results).
        /// </summary>
        public class SetDeviceMetricsOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDeviceMetricsOverride";
        }

        public class SetScrollbarsHiddenCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setScrollbarsHidden";
        }

        public class SetDocumentCookieDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDocumentCookieDisabled";
        }

        public class SetEmitTouchEventsForMouseCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setEmitTouchEventsForMouse";
        }

        /// <summary>
        /// Emulates the given media for CSS media queries.
        /// </summary>
        public class SetEmulatedMediaCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setEmulatedMedia";
        }

        /// <summary>
        /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
        /// unavailable.
        /// </summary>
        public class SetGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setGeolocationOverride";
        }

        /// <summary>
        /// Overrides value returned by the javascript navigator object.
        /// </summary>
        [Obsolete]
        public class SetNavigatorOverridesCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setNavigatorOverrides";
        }

        /// <summary>
        /// Sets a specified page scale factor.
        /// </summary>
        public class SetPageScaleFactorCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setPageScaleFactor";
        }

        /// <summary>
        /// Switches script execution in the page.
        /// </summary>
        public class SetScriptExecutionDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setScriptExecutionDisabled";
        }

        /// <summary>
        /// Enables touch on platforms which do not support them.
        /// </summary>
        public class SetTouchEmulationEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setTouchEmulationEnabled";
        }

        /// <summary>
        /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
        /// the current virtual time policy.  Note this supersedes any previous time budget.
        /// </summary>
        public class SetVirtualTimePolicyCommand : ICommand<SetVirtualTimePolicyResponse>
        {
            string ICommand.Name { get; } = "Emulation.setVirtualTimePolicy";
        }

        public class SetVirtualTimePolicyResponse
        {
        }

        /// <summary>
        /// Resizes the frame/viewport of the page. Note that this does not affect the frame's container
        /// (e.g. browser window). Can be used to produce screenshots of the specified size. Not supported
        /// on Android.
        /// </summary>
        [Obsolete]
        public class SetVisibleSizeCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setVisibleSize";
        }

        /// <summary>
        /// Allows overriding user agent with the given string.
        /// </summary>
        public class SetUserAgentOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setUserAgentOverride";
        }
    }

    /// <summary>
    /// This domain provides experimental commands only supported in headless mode.
    /// </summary>
    namespace HeadlessExperimental
    {

        /// <summary>
        /// Encoding options for a screenshot.
        /// </summary>
        public class ScreenshotParams
        {
        }

        /// <summary>
        /// Sends a BeginFrame to the target and returns when the frame was completed. Optionally captures a
        /// screenshot from the resulting frame. Requires that the target was created with enabled
        /// BeginFrameControl. Designed for use with --run-all-compositor-stages-before-draw, see also
        /// https://goo.gl/3zHXhB for more background.
        /// </summary>
        public class BeginFrameCommand : ICommand<BeginFrameResponse>
        {
            string ICommand.Name { get; } = "HeadlessExperimental.beginFrame";
        }

        public class BeginFrameResponse
        {
        }

        /// <summary>
        /// Disables headless events for the target.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "HeadlessExperimental.disable";
        }

        /// <summary>
        /// Enables headless events for the target.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "HeadlessExperimental.enable";
        }
    }

    /// <summary>
    /// Input/Output operations for streams produced by DevTools.
    /// </summary>
    namespace IO
    {

        /// <summary>
        /// This is either obtained from another method or specifed as `blob:&amp;lt;uuid&amp;gt;` where
        /// `&amp;lt;uuid&amp;gt` is an UUID of a Blob.
        /// </summary>
        public class StreamHandle
        {
        }

        /// <summary>
        /// Close the stream, discard any temporary backing storage.
        /// </summary>
        public class CloseCommand : ICommand
        {
            string ICommand.Name { get; } = "IO.close";
        }

        /// <summary>
        /// Read a chunk of the stream
        /// </summary>
        public class ReadCommand : ICommand<ReadResponse>
        {
            string ICommand.Name { get; } = "IO.read";
        }

        public class ReadResponse
        {
        }

        /// <summary>
        /// Return UUID of Blob object specified by a remote object id.
        /// </summary>
        public class ResolveBlobCommand : ICommand<ResolveBlobResponse>
        {
            string ICommand.Name { get; } = "IO.resolveBlob";
        }

        public class ResolveBlobResponse
        {
        }
    }

    namespace IndexedDB
    {

        /// <summary>
        /// Database with an array of object stores.
        /// </summary>
        public class DatabaseWithObjectStores
        {
        }

        /// <summary>
        /// Object store.
        /// </summary>
        public class ObjectStore
        {
        }

        /// <summary>
        /// Object store index.
        /// </summary>
        public class ObjectStoreIndex
        {
        }

        /// <summary>
        /// Key.
        /// </summary>
        public class Key
        {
        }

        /// <summary>
        /// Key range.
        /// </summary>
        public class KeyRange
        {
        }

        /// <summary>
        /// Data entry.
        /// </summary>
        public class DataEntry
        {
        }

        /// <summary>
        /// Key path.
        /// </summary>
        public class KeyPath
        {
        }

        /// <summary>
        /// Clears all entries from an object store.
        /// </summary>
        public class ClearObjectStoreCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.clearObjectStore";
        }

        /// <summary>
        /// Deletes a database.
        /// </summary>
        public class DeleteDatabaseCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.deleteDatabase";
        }

        /// <summary>
        /// Delete a range of entries from an object store
        /// </summary>
        public class DeleteObjectStoreEntriesCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.deleteObjectStoreEntries";
        }

        /// <summary>
        /// Disables events from backend.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.disable";
        }

        /// <summary>
        /// Enables events from backend.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.enable";
        }

        /// <summary>
        /// Requests data from object store or index.
        /// </summary>
        public class RequestDataCommand : ICommand<RequestDataResponse>
        {
            string ICommand.Name { get; } = "IndexedDB.requestData";
        }

        public class RequestDataResponse
        {
        }

        /// <summary>
        /// Requests database with given name in given frame.
        /// </summary>
        public class RequestDatabaseCommand : ICommand<RequestDatabaseResponse>
        {
            string ICommand.Name { get; } = "IndexedDB.requestDatabase";
        }

        public class RequestDatabaseResponse
        {
        }

        /// <summary>
        /// Requests database names for given security origin.
        /// </summary>
        public class RequestDatabaseNamesCommand : ICommand<RequestDatabaseNamesResponse>
        {
            string ICommand.Name { get; } = "IndexedDB.requestDatabaseNames";
        }

        public class RequestDatabaseNamesResponse
        {
        }
    }

    namespace Input
    {

        public class TouchPoint
        {
        }

        public class GestureSourceType
        {
        }

        /// <summary>
        /// UTC time in seconds, counted from January 1, 1970.
        /// </summary>
        public class TimeSinceEpoch
        {
        }

        /// <summary>
        /// Dispatches a key event to the page.
        /// </summary>
        public class DispatchKeyEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.dispatchKeyEvent";
        }

        /// <summary>
        /// This method emulates inserting text that doesn't come from a key press,
        /// for example an emoji keyboard or an IME.
        /// </summary>
        public class InsertTextCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.insertText";
        }

        /// <summary>
        /// Dispatches a mouse event to the page.
        /// </summary>
        public class DispatchMouseEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.dispatchMouseEvent";
        }

        /// <summary>
        /// Dispatches a touch event to the page.
        /// </summary>
        public class DispatchTouchEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.dispatchTouchEvent";
        }

        /// <summary>
        /// Emulates touch event from the mouse event parameters.
        /// </summary>
        public class EmulateTouchFromMouseEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.emulateTouchFromMouseEvent";
        }

        /// <summary>
        /// Ignores input events (useful while auditing page).
        /// </summary>
        public class SetIgnoreInputEventsCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.setIgnoreInputEvents";
        }

        /// <summary>
        /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizePinchGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizePinchGesture";
        }

        /// <summary>
        /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizeScrollGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizeScrollGesture";
        }

        /// <summary>
        /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizeTapGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizeTapGesture";
        }
    }

    namespace Inspector
    {

        /// <summary>
        /// Disables inspector domain notifications.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Inspector.disable";
        }

        /// <summary>
        /// Enables inspector domain notifications.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Inspector.enable";
        }
    }

    namespace LayerTree
    {

        /// <summary>
        /// Unique Layer identifier.
        /// </summary>
        public class LayerId
        {
        }

        /// <summary>
        /// Unique snapshot identifier.
        /// </summary>
        public class SnapshotId
        {
        }

        /// <summary>
        /// Rectangle where scrolling happens on the main thread.
        /// </summary>
        public class ScrollRect
        {
        }

        /// <summary>
        /// Sticky position constraints.
        /// </summary>
        public class StickyPositionConstraint
        {
        }

        /// <summary>
        /// Serialized fragment of layer picture along with its offset within the layer.
        /// </summary>
        public class PictureTile
        {
        }

        /// <summary>
        /// Information about a compositing layer.
        /// </summary>
        public class Layer
        {
        }

        /// <summary>
        /// Array of timings, one per paint step.
        /// </summary>
        public class PaintProfile
        {
        }

        /// <summary>
        /// Provides the reasons why the given layer was composited.
        /// </summary>
        public class CompositingReasonsCommand : ICommand<CompositingReasonsResponse>
        {
            string ICommand.Name { get; } = "LayerTree.compositingReasons";
        }

        public class CompositingReasonsResponse
        {
        }

        /// <summary>
        /// Disables compositing tree inspection.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.disable";
        }

        /// <summary>
        /// Enables compositing tree inspection.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.enable";
        }

        /// <summary>
        /// Returns the snapshot identifier.
        /// </summary>
        public class LoadSnapshotCommand : ICommand<LoadSnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.loadSnapshot";
        }

        public class LoadSnapshotResponse
        {
        }

        /// <summary>
        /// Returns the layer snapshot identifier.
        /// </summary>
        public class MakeSnapshotCommand : ICommand<MakeSnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.makeSnapshot";
        }

        public class MakeSnapshotResponse
        {
        }

        public class ProfileSnapshotCommand : ICommand<ProfileSnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.profileSnapshot";
        }

        public class ProfileSnapshotResponse
        {
        }

        /// <summary>
        /// Releases layer snapshot captured by the back-end.
        /// </summary>
        public class ReleaseSnapshotCommand : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.releaseSnapshot";
        }

        /// <summary>
        /// Replays the layer snapshot and returns the resulting bitmap.
        /// </summary>
        public class ReplaySnapshotCommand : ICommand<ReplaySnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.replaySnapshot";
        }

        public class ReplaySnapshotResponse
        {
        }

        /// <summary>
        /// Replays the layer snapshot and returns canvas log.
        /// </summary>
        public class SnapshotCommandLogCommand : ICommand<SnapshotCommandLogResponse>
        {
            string ICommand.Name { get; } = "LayerTree.snapshotCommandLog";
        }

        public class SnapshotCommandLogResponse
        {
        }
    }

    /// <summary>
    /// Provides access to log entries.
    /// </summary>
    namespace Log
    {

        /// <summary>
        /// Log entry.
        /// </summary>
        public class LogEntry
        {
        }

        /// <summary>
        /// Violation configuration setting.
        /// </summary>
        public class ViolationSetting
        {
        }

        /// <summary>
        /// Clears the log.
        /// </summary>
        public class ClearCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.clear";
        }

        /// <summary>
        /// Disables log domain, prevents further log entries from being reported to the client.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.disable";
        }

        /// <summary>
        /// Enables log domain, sends the entries collected so far to the client by means of the
        /// `entryAdded` notification.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.enable";
        }

        /// <summary>
        /// start violation reporting.
        /// </summary>
        public class StartViolationsReportCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.startViolationsReport";
        }

        /// <summary>
        /// Stop violation reporting.
        /// </summary>
        public class StopViolationsReportCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.stopViolationsReport";
        }
    }

    namespace Memory
    {

        /// <summary>
        /// Memory pressure level.
        /// </summary>
        public class PressureLevel
        {
        }

        /// <summary>
        /// Heap profile sample.
        /// </summary>
        public class SamplingProfileNode
        {
        }

        /// <summary>
        /// Array of heap profile samples.
        /// </summary>
        public class SamplingProfile
        {
        }

        /// <summary>
        /// Executable module information
        /// </summary>
        public class Module
        {
        }

        public class GetDOMCountersCommand : ICommand<GetDOMCountersResponse>
        {
            string ICommand.Name { get; } = "Memory.getDOMCounters";
        }

        public class GetDOMCountersResponse
        {
        }

        public class PrepareForLeakDetectionCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.prepareForLeakDetection";
        }

        /// <summary>
        /// Enable/disable suppressing memory pressure notifications in all processes.
        /// </summary>
        public class SetPressureNotificationsSuppressedCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.setPressureNotificationsSuppressed";
        }

        /// <summary>
        /// Simulate a memory pressure notification in all processes.
        /// </summary>
        public class SimulatePressureNotificationCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.simulatePressureNotification";
        }

        /// <summary>
        /// Start collecting native memory profile.
        /// </summary>
        public class StartSamplingCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.startSampling";
        }

        /// <summary>
        /// Stop collecting native memory profile.
        /// </summary>
        public class StopSamplingCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.stopSampling";
        }

        /// <summary>
        /// Retrieve native memory allocations profile
        /// collected since renderer process startup.
        /// </summary>
        public class GetAllTimeSamplingProfileCommand : ICommand<GetAllTimeSamplingProfileResponse>
        {
            string ICommand.Name { get; } = "Memory.getAllTimeSamplingProfile";
        }

        public class GetAllTimeSamplingProfileResponse
        {
        }

        /// <summary>
        /// Retrieve native memory allocations profile
        /// collected since browser process startup.
        /// </summary>
        public class GetBrowserSamplingProfileCommand : ICommand<GetBrowserSamplingProfileResponse>
        {
            string ICommand.Name { get; } = "Memory.getBrowserSamplingProfile";
        }

        public class GetBrowserSamplingProfileResponse
        {
        }

        /// <summary>
        /// Retrieve native memory allocations profile collected since last
        /// `startSampling` call.
        /// </summary>
        public class GetSamplingProfileCommand : ICommand<GetSamplingProfileResponse>
        {
            string ICommand.Name { get; } = "Memory.getSamplingProfile";
        }

        public class GetSamplingProfileResponse
        {
        }
    }

    /// <summary>
    /// Network domain allows tracking network activities of the page. It exposes information about http,
    /// file, data and other requests and responses, their headers, bodies, timing, etc.
    /// </summary>
    namespace Network
    {

        /// <summary>
        /// Resource type as it was perceived by the rendering engine.
        /// </summary>
        public class ResourceType
        {
        }

        /// <summary>
        /// Unique loader identifier.
        /// </summary>
        public class LoaderId
        {
        }

        /// <summary>
        /// Unique request identifier.
        /// </summary>
        public class RequestId
        {
        }

        /// <summary>
        /// Unique intercepted request identifier.
        /// </summary>
        public class InterceptionId
        {
        }

        /// <summary>
        /// Network level fetch failure reason.
        /// </summary>
        public class ErrorReason
        {
        }

        /// <summary>
        /// UTC time in seconds, counted from January 1, 1970.
        /// </summary>
        public class TimeSinceEpoch
        {
        }

        /// <summary>
        /// Monotonically increasing time in seconds since an arbitrary point in the past.
        /// </summary>
        public class MonotonicTime
        {
        }

        /// <summary>
        /// Request / response headers as keys / values of JSON object.
        /// </summary>
        public class Headers
        {
        }

        /// <summary>
        /// The underlying connection technology that the browser is supposedly using.
        /// </summary>
        public class ConnectionType
        {
        }

        /// <summary>
        /// Represents the cookie's 'SameSite' status:
        /// https://tools.ietf.org/html/draft-west-first-party-cookies
        /// </summary>
        public class CookieSameSite
        {
        }

        /// <summary>
        /// Timing information for the request.
        /// </summary>
        public class ResourceTiming
        {
        }

        /// <summary>
        /// Loading priority of a resource request.
        /// </summary>
        public class ResourcePriority
        {
        }

        /// <summary>
        /// HTTP request data.
        /// </summary>
        public class Request
        {
        }

        /// <summary>
        /// Details of a signed certificate timestamp (SCT).
        /// </summary>
        public class SignedCertificateTimestamp
        {
        }

        /// <summary>
        /// Security details about a request.
        /// </summary>
        public class SecurityDetails
        {
        }

        /// <summary>
        /// Whether the request complied with Certificate Transparency policy.
        /// </summary>
        public class CertificateTransparencyCompliance
        {
        }

        /// <summary>
        /// The reason why request was blocked.
        /// </summary>
        public class BlockedReason
        {
        }

        /// <summary>
        /// HTTP response data.
        /// </summary>
        public class Response
        {
        }

        /// <summary>
        /// WebSocket request data.
        /// </summary>
        public class WebSocketRequest
        {
        }

        /// <summary>
        /// WebSocket response data.
        /// </summary>
        public class WebSocketResponse
        {
        }

        /// <summary>
        /// WebSocket message data. This represents an entire WebSocket message, not just a fragmented frame as the name suggests.
        /// </summary>
        public class WebSocketFrame
        {
        }

        /// <summary>
        /// Information about the cached resource.
        /// </summary>
        public class CachedResource
        {
        }

        /// <summary>
        /// Information about the request initiator.
        /// </summary>
        public class Initiator
        {
        }

        /// <summary>
        /// Cookie object
        /// </summary>
        public class Cookie
        {
        }

        /// <summary>
        /// Cookie parameter object
        /// </summary>
        public class CookieParam
        {
        }

        /// <summary>
        /// Authorization challenge for HTTP status code 401 or 407.
        /// </summary>
        public class AuthChallenge
        {
        }

        /// <summary>
        /// Response to an AuthChallenge.
        /// </summary>
        public class AuthChallengeResponse
        {
        }

        /// <summary>
        /// Stages of the interception to begin intercepting. Request will intercept before the request is
        /// sent. Response will intercept after the response is received.
        /// </summary>
        public class InterceptionStage
        {
        }

        /// <summary>
        /// Request pattern for interception.
        /// </summary>
        public class RequestPattern
        {
        }

        /// <summary>
        /// Information about a signed exchange signature.
        /// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#rfc.section.3.1
        /// </summary>
        public class SignedExchangeSignature
        {
        }

        /// <summary>
        /// Information about a signed exchange header.
        /// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#cbor-representation
        /// </summary>
        public class SignedExchangeHeader
        {
        }

        /// <summary>
        /// Field type for a signed exchange related error.
        /// </summary>
        public class SignedExchangeErrorField
        {
        }

        /// <summary>
        /// Information about a signed exchange response.
        /// </summary>
        public class SignedExchangeError
        {
        }

        /// <summary>
        /// Information about a signed exchange response.
        /// </summary>
        public class SignedExchangeInfo
        {
        }

        /// <summary>
        /// Tells whether clearing browser cache is supported.
        /// </summary>
        [Obsolete]
        public class CanClearBrowserCacheCommand : ICommand<CanClearBrowserCacheResponse>
        {
            string ICommand.Name { get; } = "Network.canClearBrowserCache";
        }

        public class CanClearBrowserCacheResponse
        {
        }

        /// <summary>
        /// Tells whether clearing browser cookies is supported.
        /// </summary>
        [Obsolete]
        public class CanClearBrowserCookiesCommand : ICommand<CanClearBrowserCookiesResponse>
        {
            string ICommand.Name { get; } = "Network.canClearBrowserCookies";
        }

        public class CanClearBrowserCookiesResponse
        {
        }

        /// <summary>
        /// Tells whether emulation of network conditions is supported.
        /// </summary>
        [Obsolete]
        public class CanEmulateNetworkConditionsCommand : ICommand<CanEmulateNetworkConditionsResponse>
        {
            string ICommand.Name { get; } = "Network.canEmulateNetworkConditions";
        }

        public class CanEmulateNetworkConditionsResponse
        {
        }

        /// <summary>
        /// Clears browser cache.
        /// </summary>
        public class ClearBrowserCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.clearBrowserCache";
        }

        /// <summary>
        /// Clears browser cookies.
        /// </summary>
        public class ClearBrowserCookiesCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.clearBrowserCookies";
        }

        /// <summary>
        /// Response to Network.requestIntercepted which either modifies the request to continue with any
        /// modifications, or blocks it, or completes it with the provided response bytes. If a network
        /// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
        /// event will be sent with the same InterceptionId.
        /// </summary>
        public class ContinueInterceptedRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.continueInterceptedRequest";
        }

        /// <summary>
        /// Deletes browser cookies with matching name and url or domain/path pair.
        /// </summary>
        public class DeleteCookiesCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.deleteCookies";
        }

        /// <summary>
        /// Disables network tracking, prevents network events from being sent to the client.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.disable";
        }

        /// <summary>
        /// Activates emulation of network conditions.
        /// </summary>
        public class EmulateNetworkConditionsCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.emulateNetworkConditions";
        }

        /// <summary>
        /// Enables network tracking, network events will now be delivered to the client.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.enable";
        }

        /// <summary>
        /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
        /// information in the `cookies` field.
        /// </summary>
        public class GetAllCookiesCommand : ICommand<GetAllCookiesResponse>
        {
            string ICommand.Name { get; } = "Network.getAllCookies";
        }

        public class GetAllCookiesResponse
        {
        }

        /// <summary>
        /// Returns the DER-encoded certificate.
        /// </summary>
        public class GetCertificateCommand : ICommand<GetCertificateResponse>
        {
            string ICommand.Name { get; } = "Network.getCertificate";
        }

        public class GetCertificateResponse
        {
        }

        /// <summary>
        /// Returns all browser cookies for the current URL. Depending on the backend support, will return
        /// detailed cookie information in the `cookies` field.
        /// </summary>
        public class GetCookiesCommand : ICommand<GetCookiesResponse>
        {
            string ICommand.Name { get; } = "Network.getCookies";
        }

        public class GetCookiesResponse
        {
        }

        /// <summary>
        /// Returns content served for the given request.
        /// </summary>
        public class GetResponseBodyCommand : ICommand<GetResponseBodyResponse>
        {
            string ICommand.Name { get; } = "Network.getResponseBody";
        }

        public class GetResponseBodyResponse
        {
        }

        /// <summary>
        /// Returns post data sent with the request. Returns an error when no data was sent with the request.
        /// </summary>
        public class GetRequestPostDataCommand : ICommand<GetRequestPostDataResponse>
        {
            string ICommand.Name { get; } = "Network.getRequestPostData";
        }

        public class GetRequestPostDataResponse
        {
        }

        /// <summary>
        /// Returns content served for the given currently intercepted request.
        /// </summary>
        public class GetResponseBodyForInterceptionCommand : ICommand<GetResponseBodyForInterceptionResponse>
        {
            string ICommand.Name { get; } = "Network.getResponseBodyForInterception";
        }

        public class GetResponseBodyForInterceptionResponse
        {
        }

        /// <summary>
        /// Returns a handle to the stream representing the response body. Note that after this command,
        /// the intercepted request can't be continued as is -- you either need to cancel it or to provide
        /// the response body. The stream only supports sequential read, IO.read will fail if the position
        /// is specified.
        /// </summary>
        public class TakeResponseBodyForInterceptionAsStreamCommand : ICommand<TakeResponseBodyForInterceptionAsStreamResponse>
        {
            string ICommand.Name { get; } = "Network.takeResponseBodyForInterceptionAsStream";
        }

        public class TakeResponseBodyForInterceptionAsStreamResponse
        {
        }

        /// <summary>
        /// This method sends a new XMLHttpRequest which is identical to the original one. The following
        /// parameters should be identical: method, url, async, request body, extra headers, withCredentials
        /// attribute, user, password.
        /// </summary>
        public class ReplayXHRCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.replayXHR";
        }

        /// <summary>
        /// Searches for given string in response content.
        /// </summary>
        public class SearchInResponseBodyCommand : ICommand<SearchInResponseBodyResponse>
        {
            string ICommand.Name { get; } = "Network.searchInResponseBody";
        }

        public class SearchInResponseBodyResponse
        {
        }

        /// <summary>
        /// Blocks URLs from loading.
        /// </summary>
        public class SetBlockedURLsCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setBlockedURLs";
        }

        /// <summary>
        /// Toggles ignoring of service worker for each request.
        /// </summary>
        public class SetBypassServiceWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setBypassServiceWorker";
        }

        /// <summary>
        /// Toggles ignoring cache for each request. If `true`, cache will not be used.
        /// </summary>
        public class SetCacheDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setCacheDisabled";
        }

        /// <summary>
        /// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
        /// </summary>
        public class SetCookieCommand : ICommand<SetCookieResponse>
        {
            string ICommand.Name { get; } = "Network.setCookie";
        }

        public class SetCookieResponse
        {
        }

        /// <summary>
        /// Sets given cookies.
        /// </summary>
        public class SetCookiesCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setCookies";
        }

        /// <summary>
        /// For testing.
        /// </summary>
        public class SetDataSizeLimitsForTestCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setDataSizeLimitsForTest";
        }

        /// <summary>
        /// Specifies whether to always send extra HTTP headers with the requests from this page.
        /// </summary>
        public class SetExtraHTTPHeadersCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setExtraHTTPHeaders";
        }

        /// <summary>
        /// Sets the requests to intercept that match a the provided patterns and optionally resource types.
        /// </summary>
        public class SetRequestInterceptionCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setRequestInterception";
        }

        /// <summary>
        /// Allows overriding user agent with the given string.
        /// </summary>
        public class SetUserAgentOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setUserAgentOverride";
        }
    }

    /// <summary>
    /// This domain provides various functionality related to drawing atop the inspected page.
    /// </summary>
    namespace Overlay
    {

        /// <summary>
        /// Configuration data for the highlighting of page elements.
        /// </summary>
        public class HighlightConfig
        {
        }

        public class InspectMode
        {
        }

        /// <summary>
        /// Disables domain notifications.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.disable";
        }

        /// <summary>
        /// Enables domain notifications.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.enable";
        }

        /// <summary>
        /// For testing.
        /// </summary>
        public class GetHighlightObjectForTestCommand : ICommand<GetHighlightObjectForTestResponse>
        {
            string ICommand.Name { get; } = "Overlay.getHighlightObjectForTest";
        }

        public class GetHighlightObjectForTestResponse
        {
        }

        /// <summary>
        /// Hides any highlight.
        /// </summary>
        public class HideHighlightCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.hideHighlight";
        }

        /// <summary>
        /// Highlights owner element of the frame with given id.
        /// </summary>
        public class HighlightFrameCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightFrame";
        }

        /// <summary>
        /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
        /// objectId must be specified.
        /// </summary>
        public class HighlightNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightNode";
        }

        /// <summary>
        /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
        /// </summary>
        public class HighlightQuadCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightQuad";
        }

        /// <summary>
        /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
        /// </summary>
        public class HighlightRectCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightRect";
        }

        /// <summary>
        /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
        /// Backend then generates 'inspectNodeRequested' event upon element selection.
        /// </summary>
        public class SetInspectModeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setInspectMode";
        }

        public class SetPausedInDebuggerMessageCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setPausedInDebuggerMessage";
        }

        /// <summary>
        /// Requests that backend shows debug borders on layers
        /// </summary>
        public class SetShowDebugBordersCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowDebugBorders";
        }

        /// <summary>
        /// Requests that backend shows the FPS counter
        /// </summary>
        public class SetShowFPSCounterCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowFPSCounter";
        }

        /// <summary>
        /// Requests that backend shows paint rectangles
        /// </summary>
        public class SetShowPaintRectsCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowPaintRects";
        }

        /// <summary>
        /// Requests that backend shows scroll bottleneck rects
        /// </summary>
        public class SetShowScrollBottleneckRectsCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowScrollBottleneckRects";
        }

        /// <summary>
        /// Requests that backend shows hit-test borders on layers
        /// </summary>
        public class SetShowHitTestBordersCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowHitTestBorders";
        }

        /// <summary>
        /// Paints viewport size upon main frame resize.
        /// </summary>
        public class SetShowViewportSizeOnResizeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowViewportSizeOnResize";
        }

        public class SetSuspendedCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setSuspended";
        }
    }

    /// <summary>
    /// Actions and events related to the inspected page belong to the page domain.
    /// </summary>
    namespace Page
    {

        /// <summary>
        /// Unique frame identifier.
        /// </summary>
        public class FrameId
        {
        }

        /// <summary>
        /// Information about the Frame on the page.
        /// </summary>
        public class Frame
        {
        }

        /// <summary>
        /// Information about the Resource on the page.
        /// </summary>
        public class FrameResource
        {
        }

        /// <summary>
        /// Information about the Frame hierarchy along with their cached resources.
        /// </summary>
        public class FrameResourceTree
        {
        }

        /// <summary>
        /// Information about the Frame hierarchy.
        /// </summary>
        public class FrameTree
        {
        }

        /// <summary>
        /// Unique script identifier.
        /// </summary>
        public class ScriptIdentifier
        {
        }

        /// <summary>
        /// Transition type.
        /// </summary>
        public class TransitionType
        {
        }

        /// <summary>
        /// Navigation history entry.
        /// </summary>
        public class NavigationEntry
        {
        }

        /// <summary>
        /// Screencast frame metadata.
        /// </summary>
        public class ScreencastFrameMetadata
        {
        }

        /// <summary>
        /// Javascript dialog type.
        /// </summary>
        public class DialogType
        {
        }

        /// <summary>
        /// Error while paring app manifest.
        /// </summary>
        public class AppManifestError
        {
        }

        /// <summary>
        /// Layout viewport position and dimensions.
        /// </summary>
        public class LayoutViewport
        {
        }

        /// <summary>
        /// Visual viewport position, dimensions, and scale.
        /// </summary>
        public class VisualViewport
        {
        }

        /// <summary>
        /// Viewport for capturing screenshot.
        /// </summary>
        public class Viewport
        {
        }

        /// <summary>
        /// Generic font families collection.
        /// </summary>
        public class FontFamilies
        {
        }

        /// <summary>
        /// Default font sizes.
        /// </summary>
        public class FontSizes
        {
        }

        /// <summary>
        /// Deprecated, please use addScriptToEvaluateOnNewDocument instead.
        /// </summary>
        [Obsolete]
        public class AddScriptToEvaluateOnLoadCommand : ICommand<AddScriptToEvaluateOnLoadResponse>
        {
            string ICommand.Name { get; } = "Page.addScriptToEvaluateOnLoad";
        }

        public class AddScriptToEvaluateOnLoadResponse
        {
        }

        /// <summary>
        /// Evaluates given script in every frame upon creation (before loading frame's scripts).
        /// </summary>
        public class AddScriptToEvaluateOnNewDocumentCommand : ICommand<AddScriptToEvaluateOnNewDocumentResponse>
        {
            string ICommand.Name { get; } = "Page.addScriptToEvaluateOnNewDocument";
        }

        public class AddScriptToEvaluateOnNewDocumentResponse
        {
        }

        /// <summary>
        /// Brings page to front (activates tab).
        /// </summary>
        public class BringToFrontCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.bringToFront";
        }

        /// <summary>
        /// Capture page screenshot.
        /// </summary>
        public class CaptureScreenshotCommand : ICommand<CaptureScreenshotResponse>
        {
            string ICommand.Name { get; } = "Page.captureScreenshot";
        }

        public class CaptureScreenshotResponse
        {
        }

        /// <summary>
        /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
        /// iframes, shadow DOM, external resources, and element-inline styles.
        /// </summary>
        public class CaptureSnapshotCommand : ICommand<CaptureSnapshotResponse>
        {
            string ICommand.Name { get; } = "Page.captureSnapshot";
        }

        public class CaptureSnapshotResponse
        {
        }

        /// <summary>
        /// Clears the overriden device metrics.
        /// </summary>
        [Obsolete]
        public class ClearDeviceMetricsOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.clearDeviceMetricsOverride";
        }

        /// <summary>
        /// Clears the overridden Device Orientation.
        /// </summary>
        [Obsolete]
        public class ClearDeviceOrientationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.clearDeviceOrientationOverride";
        }

        /// <summary>
        /// Clears the overriden Geolocation Position and Error.
        /// </summary>
        [Obsolete]
        public class ClearGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.clearGeolocationOverride";
        }

        /// <summary>
        /// Creates an isolated world for the given frame.
        /// </summary>
        public class CreateIsolatedWorldCommand : ICommand<CreateIsolatedWorldResponse>
        {
            string ICommand.Name { get; } = "Page.createIsolatedWorld";
        }

        public class CreateIsolatedWorldResponse
        {
        }

        /// <summary>
        /// Deletes browser cookie with given name, domain and path.
        /// </summary>
        [Obsolete]
        public class DeleteCookieCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.deleteCookie";
        }

        /// <summary>
        /// Disables page domain notifications.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.disable";
        }

        /// <summary>
        /// Enables page domain notifications.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.enable";
        }

        public class GetAppManifestCommand : ICommand<GetAppManifestResponse>
        {
            string ICommand.Name { get; } = "Page.getAppManifest";
        }

        public class GetAppManifestResponse
        {
        }

        /// <summary>
        /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
        /// information in the `cookies` field.
        /// </summary>
        [Obsolete]
        public class GetCookiesCommand : ICommand<GetCookiesResponse>
        {
            string ICommand.Name { get; } = "Page.getCookies";
        }

        public class GetCookiesResponse
        {
        }

        /// <summary>
        /// Returns present frame tree structure.
        /// </summary>
        public class GetFrameTreeCommand : ICommand<GetFrameTreeResponse>
        {
            string ICommand.Name { get; } = "Page.getFrameTree";
        }

        public class GetFrameTreeResponse
        {
        }

        /// <summary>
        /// Returns metrics relating to the layouting of the page, such as viewport bounds/scale.
        /// </summary>
        public class GetLayoutMetricsCommand : ICommand<GetLayoutMetricsResponse>
        {
            string ICommand.Name { get; } = "Page.getLayoutMetrics";
        }

        public class GetLayoutMetricsResponse
        {
        }

        /// <summary>
        /// Returns navigation history for the current page.
        /// </summary>
        public class GetNavigationHistoryCommand : ICommand<GetNavigationHistoryResponse>
        {
            string ICommand.Name { get; } = "Page.getNavigationHistory";
        }

        public class GetNavigationHistoryResponse
        {
        }

        /// <summary>
        /// Resets navigation history for the current page.
        /// </summary>
        public class ResetNavigationHistoryCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.resetNavigationHistory";
        }

        /// <summary>
        /// Returns content of the given resource.
        /// </summary>
        public class GetResourceContentCommand : ICommand<GetResourceContentResponse>
        {
            string ICommand.Name { get; } = "Page.getResourceContent";
        }

        public class GetResourceContentResponse
        {
        }

        /// <summary>
        /// Returns present frame / resource tree structure.
        /// </summary>
        public class GetResourceTreeCommand : ICommand<GetResourceTreeResponse>
        {
            string ICommand.Name { get; } = "Page.getResourceTree";
        }

        public class GetResourceTreeResponse
        {
        }

        /// <summary>
        /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
        /// </summary>
        public class HandleJavaScriptDialogCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.handleJavaScriptDialog";
        }

        /// <summary>
        /// Navigates current page to the given URL.
        /// </summary>
        public class NavigateCommand : ICommand<NavigateResponse>
        {
            string ICommand.Name { get; } = "Page.navigate";
        }

        public class NavigateResponse
        {
        }

        /// <summary>
        /// Navigates current page to the given history entry.
        /// </summary>
        public class NavigateToHistoryEntryCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.navigateToHistoryEntry";
        }

        /// <summary>
        /// Print page as PDF.
        /// </summary>
        public class PrintToPDFCommand : ICommand<PrintToPDFResponse>
        {
            string ICommand.Name { get; } = "Page.printToPDF";
        }

        public class PrintToPDFResponse
        {
        }

        /// <summary>
        /// Reloads given page optionally ignoring the cache.
        /// </summary>
        public class ReloadCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.reload";
        }

        /// <summary>
        /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
        /// </summary>
        [Obsolete]
        public class RemoveScriptToEvaluateOnLoadCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.removeScriptToEvaluateOnLoad";
        }

        /// <summary>
        /// Removes given script from the list.
        /// </summary>
        public class RemoveScriptToEvaluateOnNewDocumentCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.removeScriptToEvaluateOnNewDocument";
        }

        /// <summary>
        /// Acknowledges that a screencast frame has been received by the frontend.
        /// </summary>
        public class ScreencastFrameAckCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.screencastFrameAck";
        }

        /// <summary>
        /// Searches for given string in resource content.
        /// </summary>
        public class SearchInResourceCommand : ICommand<SearchInResourceResponse>
        {
            string ICommand.Name { get; } = "Page.searchInResource";
        }

        public class SearchInResourceResponse
        {
        }

        /// <summary>
        /// Enable Chrome's experimental ad filter on all sites.
        /// </summary>
        public class SetAdBlockingEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setAdBlockingEnabled";
        }

        /// <summary>
        /// Enable page Content Security Policy by-passing.
        /// </summary>
        public class SetBypassCSPCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setBypassCSP";
        }

        /// <summary>
        /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
        /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
        /// query results).
        /// </summary>
        [Obsolete]
        public class SetDeviceMetricsOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDeviceMetricsOverride";
        }

        /// <summary>
        /// Overrides the Device Orientation.
        /// </summary>
        [Obsolete]
        public class SetDeviceOrientationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDeviceOrientationOverride";
        }

        /// <summary>
        /// Set generic font families.
        /// </summary>
        public class SetFontFamiliesCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setFontFamilies";
        }

        /// <summary>
        /// Set default font sizes.
        /// </summary>
        public class SetFontSizesCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setFontSizes";
        }

        /// <summary>
        /// Sets given markup as the document's HTML.
        /// </summary>
        public class SetDocumentContentCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDocumentContent";
        }

        /// <summary>
        /// Set the behavior when downloading a file.
        /// </summary>
        public class SetDownloadBehaviorCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDownloadBehavior";
        }

        /// <summary>
        /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
        /// unavailable.
        /// </summary>
        [Obsolete]
        public class SetGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setGeolocationOverride";
        }

        /// <summary>
        /// Controls whether page will emit lifecycle events.
        /// </summary>
        public class SetLifecycleEventsEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setLifecycleEventsEnabled";
        }

        /// <summary>
        /// Toggles mouse event-based touch event emulation.
        /// </summary>
        [Obsolete]
        public class SetTouchEmulationEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setTouchEmulationEnabled";
        }

        /// <summary>
        /// Starts sending each frame using the `screencastFrame` event.
        /// </summary>
        public class StartScreencastCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.startScreencast";
        }

        /// <summary>
        /// Force the page stop all navigations and pending resource fetches.
        /// </summary>
        public class StopLoadingCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.stopLoading";
        }

        /// <summary>
        /// Crashes renderer on the IO thread, generates minidumps.
        /// </summary>
        public class CrashCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.crash";
        }

        /// <summary>
        /// Tries to close page, running its beforeunload hooks, if any.
        /// </summary>
        public class CloseCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.close";
        }

        /// <summary>
        /// Tries to update the web lifecycle state of the page.
        /// It will transition the page to the given state according to:
        /// https://github.com/WICG/web-lifecycle/
        /// </summary>
        public class SetWebLifecycleStateCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setWebLifecycleState";
        }

        /// <summary>
        /// Stops sending each frame in the `screencastFrame`.
        /// </summary>
        public class StopScreencastCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.stopScreencast";
        }

        /// <summary>
        /// Forces compilation cache to be generated for every subresource script.
        /// </summary>
        public class SetProduceCompilationCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setProduceCompilationCache";
        }

        /// <summary>
        /// Seeds compilation cache for given url. Compilation cache does not survive
        /// cross-process navigation.
        /// </summary>
        public class AddCompilationCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.addCompilationCache";
        }

        /// <summary>
        /// Clears seeded compilation cache.
        /// </summary>
        public class ClearCompilationCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.clearCompilationCache";
        }

        /// <summary>
        /// Generates a report for testing.
        /// </summary>
        public class GenerateTestReportCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.generateTestReport";
        }

        /// <summary>
        /// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
        /// </summary>
        public class WaitForDebuggerCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.waitForDebugger";
        }
    }

    namespace Performance
    {

        /// <summary>
        /// Run-time execution metric.
        /// </summary>
        public class Metric
        {
        }

        /// <summary>
        /// Disable collecting and reporting metrics.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Performance.disable";
        }

        /// <summary>
        /// Enable collecting and reporting metrics.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Performance.enable";
        }

        /// <summary>
        /// Sets time domain to use for collecting and reporting duration metrics.
        /// Note that this must be called before enabling metrics collection. Calling
        /// this method while metrics collection is enabled returns an error.
        /// </summary>
        public class SetTimeDomainCommand : ICommand
        {
            string ICommand.Name { get; } = "Performance.setTimeDomain";
        }

        /// <summary>
        /// Retrieve current values of run-time metrics.
        /// </summary>
        public class GetMetricsCommand : ICommand<GetMetricsResponse>
        {
            string ICommand.Name { get; } = "Performance.getMetrics";
        }

        public class GetMetricsResponse
        {
        }
    }

    /// <summary>
    /// Security
    /// </summary>
    namespace Security
    {

        /// <summary>
        /// An internal certificate ID value.
        /// </summary>
        public class CertificateId
        {
        }

        /// <summary>
        /// A description of mixed content (HTTP resources on HTTPS pages), as defined by
        /// https://www.w3.org/TR/mixed-content/#categories
        /// </summary>
        public class MixedContentType
        {
        }

        /// <summary>
        /// The security level of a page or resource.
        /// </summary>
        public class SecurityState
        {
        }

        /// <summary>
        /// An explanation of an factor contributing to the security state.
        /// </summary>
        public class SecurityStateExplanation
        {
        }

        /// <summary>
        /// Information about insecure content on the page.
        /// </summary>
        public class InsecureContentStatus
        {
        }

        /// <summary>
        /// The action to take when a certificate error occurs. continue will continue processing the
        /// request and cancel will cancel the request.
        /// </summary>
        public class CertificateErrorAction
        {
        }

        /// <summary>
        /// Disables tracking security state changes.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.disable";
        }

        /// <summary>
        /// Enables tracking security state changes.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.enable";
        }

        /// <summary>
        /// Enable/disable whether all certificate errors should be ignored.
        /// </summary>
        public class SetIgnoreCertificateErrorsCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.setIgnoreCertificateErrors";
        }

        /// <summary>
        /// Handles a certificate error that fired a certificateError event.
        /// </summary>
        [Obsolete]
        public class HandleCertificateErrorCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.handleCertificateError";
        }

        /// <summary>
        /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
        /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
        /// </summary>
        [Obsolete]
        public class SetOverrideCertificateErrorsCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.setOverrideCertificateErrors";
        }
    }

    namespace ServiceWorker
    {

        /// <summary>
        /// ServiceWorker registration.
        /// </summary>
        public class ServiceWorkerRegistration
        {
        }

        public class ServiceWorkerVersionRunningStatus
        {
        }

        public class ServiceWorkerVersionStatus
        {
        }

        /// <summary>
        /// ServiceWorker version.
        /// </summary>
        public class ServiceWorkerVersion
        {
        }

        /// <summary>
        /// ServiceWorker error message.
        /// </summary>
        public class ServiceWorkerErrorMessage
        {
        }

        public class DeliverPushMessageCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.deliverPushMessage";
        }

        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.disable";
        }

        public class DispatchSyncEventCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.dispatchSyncEvent";
        }

        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.enable";
        }

        public class InspectWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.inspectWorker";
        }

        public class SetForceUpdateOnPageLoadCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.setForceUpdateOnPageLoad";
        }

        public class SkipWaitingCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.skipWaiting";
        }

        public class StartWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.startWorker";
        }

        public class StopAllWorkersCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.stopAllWorkers";
        }

        public class StopWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.stopWorker";
        }

        public class UnregisterCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.unregister";
        }

        public class UpdateRegistrationCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.updateRegistration";
        }
    }

    namespace Storage
    {

        /// <summary>
        /// Enum of possible storage types.
        /// </summary>
        public class StorageType
        {
        }

        /// <summary>
        /// Usage for a storage type.
        /// </summary>
        public class UsageForType
        {
        }

        /// <summary>
        /// Clears storage for origin.
        /// </summary>
        public class ClearDataForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.clearDataForOrigin";
        }

        /// <summary>
        /// Returns usage and quota in bytes.
        /// </summary>
        public class GetUsageAndQuotaCommand : ICommand<GetUsageAndQuotaResponse>
        {
            string ICommand.Name { get; } = "Storage.getUsageAndQuota";
        }

        public class GetUsageAndQuotaResponse
        {
        }

        /// <summary>
        /// Registers origin to be notified when an update occurs to its cache storage list.
        /// </summary>
        public class TrackCacheStorageForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.trackCacheStorageForOrigin";
        }

        /// <summary>
        /// Registers origin to be notified when an update occurs to its IndexedDB.
        /// </summary>
        public class TrackIndexedDBForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.trackIndexedDBForOrigin";
        }

        /// <summary>
        /// Unregisters origin from receiving notifications for cache storage.
        /// </summary>
        public class UntrackCacheStorageForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.untrackCacheStorageForOrigin";
        }

        /// <summary>
        /// Unregisters origin from receiving notifications for IndexedDB.
        /// </summary>
        public class UntrackIndexedDBForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.untrackIndexedDBForOrigin";
        }
    }

    /// <summary>
    /// The SystemInfo domain defines methods and events for querying low-level system information.
    /// </summary>
    namespace SystemInfo
    {

        /// <summary>
        /// Describes a single graphics processor (GPU).
        /// </summary>
        public class GPUDevice
        {
        }

        /// <summary>
        /// Provides information about the GPU(s) on the system.
        /// </summary>
        public class GPUInfo
        {
        }

        /// <summary>
        /// Represents process info.
        /// </summary>
        public class ProcessInfo
        {
        }

        /// <summary>
        /// Returns information about the system.
        /// </summary>
        public class GetInfoCommand : ICommand<GetInfoResponse>
        {
            string ICommand.Name { get; } = "SystemInfo.getInfo";
        }

        public class GetInfoResponse
        {
        }

        /// <summary>
        /// Returns information about all running processes.
        /// </summary>
        public class GetProcessInfoCommand : ICommand<GetProcessInfoResponse>
        {
            string ICommand.Name { get; } = "SystemInfo.getProcessInfo";
        }

        public class GetProcessInfoResponse
        {
        }
    }

    /// <summary>
    /// Supports additional targets discovery and allows to attach to them.
    /// </summary>
    namespace Target
    {

        public class TargetID
        {
        }

        /// <summary>
        /// Unique identifier of attached debugging session.
        /// </summary>
        public class SessionID
        {
        }

        public class BrowserContextID
        {
        }

        public class TargetInfo
        {
        }

        public class RemoteLocation
        {
        }

        /// <summary>
        /// Activates (focuses) the target.
        /// </summary>
        public class ActivateTargetCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.activateTarget";
        }

        /// <summary>
        /// Attaches to the target with given id.
        /// </summary>
        public class AttachToTargetCommand : ICommand<AttachToTargetResponse>
        {
            string ICommand.Name { get; } = "Target.attachToTarget";
        }

        public class AttachToTargetResponse
        {
        }

        /// <summary>
        /// Attaches to the browser target, only uses flat sessionId mode.
        /// </summary>
        public class AttachToBrowserTargetCommand : ICommand<AttachToBrowserTargetResponse>
        {
            string ICommand.Name { get; } = "Target.attachToBrowserTarget";
        }

        public class AttachToBrowserTargetResponse
        {
        }

        /// <summary>
        /// Closes the target. If the target is a page that gets closed too.
        /// </summary>
        public class CloseTargetCommand : ICommand<CloseTargetResponse>
        {
            string ICommand.Name { get; } = "Target.closeTarget";
        }

        public class CloseTargetResponse
        {
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
        public class ExposeDevToolsProtocolCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.exposeDevToolsProtocol";
        }

        /// <summary>
        /// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
        /// one.
        /// </summary>
        public class CreateBrowserContextCommand : ICommand<CreateBrowserContextResponse>
        {
            string ICommand.Name { get; } = "Target.createBrowserContext";
        }

        public class CreateBrowserContextResponse
        {
        }

        /// <summary>
        /// Returns all browser contexts created with `Target.createBrowserContext` method.
        /// </summary>
        public class GetBrowserContextsCommand : ICommand<GetBrowserContextsResponse>
        {
            string ICommand.Name { get; } = "Target.getBrowserContexts";
        }

        public class GetBrowserContextsResponse
        {
        }

        /// <summary>
        /// Creates a new page.
        /// </summary>
        public class CreateTargetCommand : ICommand<CreateTargetResponse>
        {
            string ICommand.Name { get; } = "Target.createTarget";
        }

        public class CreateTargetResponse
        {
        }

        /// <summary>
        /// Detaches session with given id.
        /// </summary>
        public class DetachFromTargetCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.detachFromTarget";
        }

        /// <summary>
        /// Deletes a BrowserContext. All the belonging pages will be closed without calling their
        /// beforeunload hooks.
        /// </summary>
        public class DisposeBrowserContextCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.disposeBrowserContext";
        }

        /// <summary>
        /// Returns information about a target.
        /// </summary>
        public class GetTargetInfoCommand : ICommand<GetTargetInfoResponse>
        {
            string ICommand.Name { get; } = "Target.getTargetInfo";
        }

        public class GetTargetInfoResponse
        {
        }

        /// <summary>
        /// Retrieves a list of available targets.
        /// </summary>
        public class GetTargetsCommand : ICommand<GetTargetsResponse>
        {
            string ICommand.Name { get; } = "Target.getTargets";
        }

        public class GetTargetsResponse
        {
        }

        /// <summary>
        /// Sends protocol message over session with given id.
        /// </summary>
        public class SendMessageToTargetCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.sendMessageToTarget";
        }

        /// <summary>
        /// Controls whether to automatically attach to new targets which are considered to be related to
        /// this one. When turned on, attaches to all existing related targets as well. When turned off,
        /// automatically detaches from all currently attached targets.
        /// </summary>
        public class SetAutoAttachCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setAutoAttach";
        }

        /// <summary>
        /// Controls whether to discover available targets and notify via
        /// `targetCreated/targetInfoChanged/targetDestroyed` events.
        /// </summary>
        public class SetDiscoverTargetsCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setDiscoverTargets";
        }

        /// <summary>
        /// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
        /// `true`.
        /// </summary>
        public class SetRemoteLocationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setRemoteLocations";
        }
    }

    /// <summary>
    /// The Tethering domain defines methods and events for browser port binding.
    /// </summary>
    namespace Tethering
    {

        /// <summary>
        /// Request browser port binding.
        /// </summary>
        public class BindCommand : ICommand
        {
            string ICommand.Name { get; } = "Tethering.bind";
        }

        /// <summary>
        /// Request browser port unbinding.
        /// </summary>
        public class UnbindCommand : ICommand
        {
            string ICommand.Name { get; } = "Tethering.unbind";
        }
    }

    namespace Tracing
    {

        /// <summary>
        /// Configuration for memory dump. Used only when "memory-infra" category is enabled.
        /// </summary>
        public class MemoryDumpConfig
        {
        }

        public class TraceConfig
        {
        }

        /// <summary>
        /// Compression type to use for traces returned via streams.
        /// </summary>
        public class StreamCompression
        {
        }

        /// <summary>
        /// Stop trace events collection.
        /// </summary>
        public class EndCommand : ICommand
        {
            string ICommand.Name { get; } = "Tracing.end";
        }

        /// <summary>
        /// Gets supported tracing categories.
        /// </summary>
        public class GetCategoriesCommand : ICommand<GetCategoriesResponse>
        {
            string ICommand.Name { get; } = "Tracing.getCategories";
        }

        public class GetCategoriesResponse
        {
        }

        /// <summary>
        /// Record a clock sync marker in the trace.
        /// </summary>
        public class RecordClockSyncMarkerCommand : ICommand
        {
            string ICommand.Name { get; } = "Tracing.recordClockSyncMarker";
        }

        /// <summary>
        /// Request a global memory dump.
        /// </summary>
        public class RequestMemoryDumpCommand : ICommand<RequestMemoryDumpResponse>
        {
            string ICommand.Name { get; } = "Tracing.requestMemoryDump";
        }

        public class RequestMemoryDumpResponse
        {
        }

        /// <summary>
        /// Start trace events collection.
        /// </summary>
        public class StartCommand : ICommand
        {
            string ICommand.Name { get; } = "Tracing.start";
        }
    }

    /// <summary>
    /// Testing domain is a dumping ground for the capabilities requires for browser or app testing that do not fit other
    /// domains.
    /// </summary>
    namespace Testing
    {

        /// <summary>
        /// Generates a report for testing.
        /// </summary>
        public class GenerateTestReportCommand : ICommand
        {
            string ICommand.Name { get; } = "Testing.generateTestReport";
        }
    }

    /// <summary>
    /// A domain for letting clients substitute browser's network layer with client code.
    /// </summary>
    namespace Fetch
    {

        /// <summary>
        /// Unique request identifier.
        /// </summary>
        public class RequestId
        {
        }

        /// <summary>
        /// Stages of the request to handle. Request will intercept before the request is
        /// sent. Response will intercept after the response is received (but before response
        /// body is received.
        /// </summary>
        public class RequestStage
        {
        }

        public class RequestPattern
        {
        }

        /// <summary>
        /// Response HTTP header entry
        /// </summary>
        public class HeaderEntry
        {
        }

        /// <summary>
        /// Authorization challenge for HTTP status code 401 or 407.
        /// </summary>
        public class AuthChallenge
        {
        }

        /// <summary>
        /// Response to an AuthChallenge.
        /// </summary>
        public class AuthChallengeResponse
        {
        }

        /// <summary>
        /// Disables the fetch domain.
        /// </summary>
        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.disable";
        }

        /// <summary>
        /// Enables issuing of requestPaused events. A request will be paused until client
        /// calls one of failRequest, fulfillRequest or continueRequest/continueWithAuth.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.enable";
        }

        /// <summary>
        /// Causes the request to fail with specified reason.
        /// </summary>
        public class FailRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.failRequest";
        }

        /// <summary>
        /// Provides response to the request.
        /// </summary>
        public class FulfillRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.fulfillRequest";
        }

        /// <summary>
        /// Continues the request, optionally modifying some of its parameters.
        /// </summary>
        public class ContinueRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.continueRequest";
        }

        /// <summary>
        /// Continues a request supplying authChallengeResponse following authRequired event.
        /// </summary>
        public class ContinueWithAuthCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.continueWithAuth";
        }

        /// <summary>
        /// Causes the body of the response to be received from the server and
        /// returned as a single string. May only be issued for a request that
        /// is paused in the Response stage and is mutually exclusive with
        /// takeResponseBodyForInterceptionAsStream. Calling other methods that
        /// affect the request or disabling fetch domain before body is received
        /// results in an undefined behavior.
        /// </summary>
        public class GetResponseBodyCommand : ICommand<GetResponseBodyResponse>
        {
            string ICommand.Name { get; } = "Fetch.getResponseBody";
        }

        public class GetResponseBodyResponse
        {
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
        public class TakeResponseBodyAsStreamCommand : ICommand<TakeResponseBodyAsStreamResponse>
        {
            string ICommand.Name { get; } = "Fetch.takeResponseBodyAsStream";
        }

        public class TakeResponseBodyAsStreamResponse
        {
        }
    }
}
