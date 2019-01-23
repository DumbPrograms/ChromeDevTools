using System;

namespace DumbPrograms.ChromeDevTools.Protocol.Accessibility
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables the accessibility domain which causes `AXNodeId`s to remain consistent between method calls.
    /// This turns on accessibility for the page, which can impact performance until accessibility is disabled.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
    /// </summary>
    public class getPartialAXTreeCommand
    {
    }

    /// <summary>
    /// Fetches the entire accessibility tree
    /// </summary>
    public class getFullAXTreeCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Animation
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables animation domain notifications.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Returns the current time of the an animation.
    /// </summary>
    public class getCurrentTimeCommand
    {
    }

    /// <summary>
    /// Gets the playback rate of the document timeline.
    /// </summary>
    public class getPlaybackRateCommand
    {
    }

    /// <summary>
    /// Releases a set of animations to no longer be manipulated.
    /// </summary>
    public class releaseAnimationsCommand
    {
    }

    /// <summary>
    /// Gets the remote object of the Animation.
    /// </summary>
    public class resolveAnimationCommand
    {
    }

    /// <summary>
    /// Seek a set of animations to a particular time within each animation.
    /// </summary>
    public class seekAnimationsCommand
    {
    }

    /// <summary>
    /// Sets the paused state of a set of animations.
    /// </summary>
    public class setPausedCommand
    {
    }

    /// <summary>
    /// Sets the playback rate of the document timeline.
    /// </summary>
    public class setPlaybackRateCommand
    {
    }

    /// <summary>
    /// Sets the timing of an animation node.
    /// </summary>
    public class setTimingCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.ApplicationCache
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
    public class enableCommand
    {
    }

    /// <summary>
    /// Returns relevant application cache data for the document in given frame.
    /// </summary>
    public class getApplicationCacheForFrameCommand
    {
    }

    /// <summary>
    /// Returns array of frame identifiers with manifest urls for each frame containing a document
    /// associated with some application cache.
    /// </summary>
    public class getFramesWithManifestsCommand
    {
    }

    /// <summary>
    /// Returns manifest URL for document in the given frame.
    /// </summary>
    public class getManifestForFrameCommand
    {
    }
}

/// <summary>
/// Audits domain allows investigation of page violations and possible improvements.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Audits
{

    /// <summary>
    /// Returns the response body and size if it were re-encoded with the specified settings. Only
    /// applies to images.
    /// </summary>
    public class getEncodedResponseCommand
    {
    }
}

/// <summary>
/// The Browser domain defines methods and events for browser managing.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Browser
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
    public class grantPermissionsCommand
    {
    }

    /// <summary>
    /// Reset all permission management for all origins.
    /// </summary>
    public class resetPermissionsCommand
    {
    }

    /// <summary>
    /// Close browser gracefully.
    /// </summary>
    public class closeCommand
    {
    }

    /// <summary>
    /// Crashes browser on the main thread.
    /// </summary>
    public class crashCommand
    {
    }

    /// <summary>
    /// Returns version information.
    /// </summary>
    public class getVersionCommand
    {
    }

    /// <summary>
    /// Returns the command line switches for the browser process if, and only if
    /// --enable-automation is on the commandline.
    /// </summary>
    public class getBrowserCommandLineCommand
    {
    }

    /// <summary>
    /// Get Chrome histograms.
    /// </summary>
    public class getHistogramsCommand
    {
    }

    /// <summary>
    /// Get a Chrome histogram by name.
    /// </summary>
    public class getHistogramCommand
    {
    }

    /// <summary>
    /// Get position and size of the browser window.
    /// </summary>
    public class getWindowBoundsCommand
    {
    }

    /// <summary>
    /// Get the browser window that contains the devtools target.
    /// </summary>
    public class getWindowForTargetCommand
    {
    }

    /// <summary>
    /// Set position and/or size of the browser window.
    /// </summary>
    public class setWindowBoundsCommand
    {
    }

    /// <summary>
    /// Set dock tile details, platform-specific.
    /// </summary>
    public class setDockTileCommand
    {
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
namespace DumbPrograms.ChromeDevTools.Protocol.CSS
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
    public class addRuleCommand
    {
    }

    /// <summary>
    /// Returns all class names from specified stylesheet.
    /// </summary>
    public class collectClassNamesCommand
    {
    }

    /// <summary>
    /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
    /// </summary>
    public class createStyleSheetCommand
    {
    }

    /// <summary>
    /// Disables the CSS agent for the given page.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables the CSS agent for the given page. Clients should not assume that the CSS agent has been
    /// enabled until the result of this command is received.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Ensures that the given node will have specified pseudo-classes whenever its style is computed by
    /// the browser.
    /// </summary>
    public class forcePseudoStateCommand
    {
    }

    public class getBackgroundColorsCommand
    {
    }

    /// <summary>
    /// Returns the computed style for a DOM node identified by `nodeId`.
    /// </summary>
    public class getComputedStyleForNodeCommand
    {
    }

    /// <summary>
    /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
    /// attributes) for a DOM node identified by `nodeId`.
    /// </summary>
    public class getInlineStylesForNodeCommand
    {
    }

    /// <summary>
    /// Returns requested styles for a DOM node identified by `nodeId`.
    /// </summary>
    public class getMatchedStylesForNodeCommand
    {
    }

    /// <summary>
    /// Returns all media queries parsed by the rendering engine.
    /// </summary>
    public class getMediaQueriesCommand
    {
    }

    /// <summary>
    /// Requests information about platform fonts which we used to render child TextNodes in the given
    /// node.
    /// </summary>
    public class getPlatformFontsForNodeCommand
    {
    }

    /// <summary>
    /// Returns the current textual content for a stylesheet.
    /// </summary>
    public class getStyleSheetTextCommand
    {
    }

    /// <summary>
    /// Find a rule with the given active property for the given node and set the new value for this
    /// property
    /// </summary>
    public class setEffectivePropertyValueForNodeCommand
    {
    }

    /// <summary>
    /// Modifies the keyframe rule key text.
    /// </summary>
    public class setKeyframeKeyCommand
    {
    }

    /// <summary>
    /// Modifies the rule selector.
    /// </summary>
    public class setMediaTextCommand
    {
    }

    /// <summary>
    /// Modifies the rule selector.
    /// </summary>
    public class setRuleSelectorCommand
    {
    }

    /// <summary>
    /// Sets the new stylesheet text.
    /// </summary>
    public class setStyleSheetTextCommand
    {
    }

    /// <summary>
    /// Applies specified style edits one after another in the given order.
    /// </summary>
    public class setStyleTextsCommand
    {
    }

    /// <summary>
    /// Enables the selector recording.
    /// </summary>
    public class startRuleUsageTrackingCommand
    {
    }

    /// <summary>
    /// Stop tracking rule usage and return the list of rules that were used since last call to
    /// `takeCoverageDelta` (or since start of coverage instrumentation)
    /// </summary>
    public class stopRuleUsageTrackingCommand
    {
    }

    /// <summary>
    /// Obtain list of rules that became used since last call to this method (or since start of coverage
    /// instrumentation)
    /// </summary>
    public class takeCoverageDeltaCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.CacheStorage
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
    public class deleteCacheCommand
    {
    }

    /// <summary>
    /// Deletes a cache entry.
    /// </summary>
    public class deleteEntryCommand
    {
    }

    /// <summary>
    /// Requests cache names.
    /// </summary>
    public class requestCacheNamesCommand
    {
    }

    /// <summary>
    /// Fetches cache entry.
    /// </summary>
    public class requestCachedResponseCommand
    {
    }

    /// <summary>
    /// Requests data from cache.
    /// </summary>
    public class requestEntriesCommand
    {
    }
}

/// <summary>
/// A domain for interacting with Cast, Presentation API, and Remote Playback API
/// functionalities.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Cast
{

    /// <summary>
    /// Starts observing for sinks that can be used for tab mirroring, and if set,
    /// sinks compatible with |presentationUrl| as well. When sinks are found, a
    /// |sinksUpdated| event is fired.
    /// Also starts observing for issue messages. When an issue is added or removed,
    /// an |issueUpdated| event is fired.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Stops observing for sinks and issues.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Sets a sink to be used when the web page requests the browser to choose a
    /// sink via Presentation API, Remote Playback API, or Cast SDK.
    /// </summary>
    public class setSinkToUseCommand
    {
    }

    /// <summary>
    /// Starts mirroring the tab to the sink.
    /// </summary>
    public class startTabMirroringCommand
    {
    }

    /// <summary>
    /// Stops the active Cast session on the sink.
    /// </summary>
    public class stopCastingCommand
    {
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
namespace DumbPrograms.ChromeDevTools.Protocol.DOM
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
    public class collectClassNamesFromSubtreeCommand
    {
    }

    /// <summary>
    /// Creates a deep copy of the specified node and places it into the target container before the
    /// given anchor.
    /// </summary>
    public class copyToCommand
    {
    }

    /// <summary>
    /// Describes node given its id, does not require domain to be enabled. Does not start tracking any
    /// objects, can be used for automation.
    /// </summary>
    public class describeNodeCommand
    {
    }

    /// <summary>
    /// Disables DOM agent for the given page.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Discards search results from the session with the given id. `getSearchResults` should no longer
    /// be called for that search.
    /// </summary>
    public class discardSearchResultsCommand
    {
    }

    /// <summary>
    /// Enables DOM agent for the given page.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Focuses the given element.
    /// </summary>
    public class focusCommand
    {
    }

    /// <summary>
    /// Returns attributes for the specified node.
    /// </summary>
    public class getAttributesCommand
    {
    }

    /// <summary>
    /// Returns boxes for the given node.
    /// </summary>
    public class getBoxModelCommand
    {
    }

    /// <summary>
    /// Returns quads that describe node position on the page. This method
    /// might return multiple quads for inline nodes.
    /// </summary>
    public class getContentQuadsCommand
    {
    }

    /// <summary>
    /// Returns the root DOM node (and optionally the subtree) to the caller.
    /// </summary>
    public class getDocumentCommand
    {
    }

    /// <summary>
    /// Returns the root DOM node (and optionally the subtree) to the caller.
    /// </summary>
    public class getFlattenedDocumentCommand
    {
    }

    /// <summary>
    /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
    /// either returned or not.
    /// </summary>
    public class getNodeForLocationCommand
    {
    }

    /// <summary>
    /// Returns node's HTML markup.
    /// </summary>
    public class getOuterHTMLCommand
    {
    }

    /// <summary>
    /// Returns the id of the nearest ancestor that is a relayout boundary.
    /// </summary>
    public class getRelayoutBoundaryCommand
    {
    }

    /// <summary>
    /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
    /// identifier.
    /// </summary>
    public class getSearchResultsCommand
    {
    }

    /// <summary>
    /// Hides any highlight.
    /// </summary>
    public class hideHighlightCommand
    {
    }

    /// <summary>
    /// Highlights DOM node.
    /// </summary>
    public class highlightNodeCommand
    {
    }

    /// <summary>
    /// Highlights given rectangle.
    /// </summary>
    public class highlightRectCommand
    {
    }

    /// <summary>
    /// Marks last undoable state.
    /// </summary>
    public class markUndoableStateCommand
    {
    }

    /// <summary>
    /// Moves node into the new container, places it before the given anchor.
    /// </summary>
    public class moveToCommand
    {
    }

    /// <summary>
    /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
    /// `cancelSearch` to end this search session.
    /// </summary>
    public class performSearchCommand
    {
    }

    /// <summary>
    /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
    /// </summary>
    public class pushNodeByPathToFrontendCommand
    {
    }

    /// <summary>
    /// Requests that a batch of nodes is sent to the caller given their backend node ids.
    /// </summary>
    public class pushNodesByBackendIdsToFrontendCommand
    {
    }

    /// <summary>
    /// Executes `querySelector` on a given node.
    /// </summary>
    public class querySelectorCommand
    {
    }

    /// <summary>
    /// Executes `querySelectorAll` on a given node.
    /// </summary>
    public class querySelectorAllCommand
    {
    }

    /// <summary>
    /// Re-does the last undone action.
    /// </summary>
    public class redoCommand
    {
    }

    /// <summary>
    /// Removes attribute with given name from an element with given id.
    /// </summary>
    public class removeAttributeCommand
    {
    }

    /// <summary>
    /// Removes node with given id.
    /// </summary>
    public class removeNodeCommand
    {
    }

    /// <summary>
    /// Requests that children of the node with given id are returned to the caller in form of
    /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
    /// the specified depth.
    /// </summary>
    public class requestChildNodesCommand
    {
    }

    /// <summary>
    /// Requests that the node is sent to the caller given the JavaScript node object reference. All
    /// nodes that form the path from the node to the root are also sent to the client as a series of
    /// `setChildNodes` notifications.
    /// </summary>
    public class requestNodeCommand
    {
    }

    /// <summary>
    /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
    /// </summary>
    public class resolveNodeCommand
    {
    }

    /// <summary>
    /// Sets attribute for an element with given id.
    /// </summary>
    public class setAttributeValueCommand
    {
    }

    /// <summary>
    /// Sets attributes on element with given id. This method is useful when user edits some existing
    /// attribute value and types in several attribute name/value pairs.
    /// </summary>
    public class setAttributesAsTextCommand
    {
    }

    /// <summary>
    /// Sets files for the given file input element.
    /// </summary>
    public class setFileInputFilesCommand
    {
    }

    /// <summary>
    /// Returns file information for the given
    /// File wrapper.
    /// </summary>
    public class getFileInfoCommand
    {
    }

    /// <summary>
    /// Enables console to refer to the node with given id via $x (see Command Line API for more details
    /// $x functions).
    /// </summary>
    public class setInspectedNodeCommand
    {
    }

    /// <summary>
    /// Sets node name for a node with given id.
    /// </summary>
    public class setNodeNameCommand
    {
    }

    /// <summary>
    /// Sets node value for a node with given id.
    /// </summary>
    public class setNodeValueCommand
    {
    }

    /// <summary>
    /// Sets node HTML markup, returns new node id.
    /// </summary>
    public class setOuterHTMLCommand
    {
    }

    /// <summary>
    /// Undoes the last performed action.
    /// </summary>
    public class undoCommand
    {
    }

    /// <summary>
    /// Returns iframe node that owns iframe with the given domain.
    /// </summary>
    public class getFrameOwnerCommand
    {
    }
}

/// <summary>
/// DOM debugging allows setting breakpoints on particular DOM operations and events. JavaScript
/// execution will stop on these operations as if there was a regular breakpoint set.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.DOMDebugger
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
    public class getEventListenersCommand
    {
    }

    /// <summary>
    /// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
    /// </summary>
    public class removeDOMBreakpointCommand
    {
    }

    /// <summary>
    /// Removes breakpoint on particular DOM event.
    /// </summary>
    public class removeEventListenerBreakpointCommand
    {
    }

    /// <summary>
    /// Removes breakpoint on particular native event.
    /// </summary>
    public class removeInstrumentationBreakpointCommand
    {
    }

    /// <summary>
    /// Removes breakpoint from XMLHttpRequest.
    /// </summary>
    public class removeXHRBreakpointCommand
    {
    }

    /// <summary>
    /// Sets breakpoint on particular operation with DOM.
    /// </summary>
    public class setDOMBreakpointCommand
    {
    }

    /// <summary>
    /// Sets breakpoint on particular DOM event.
    /// </summary>
    public class setEventListenerBreakpointCommand
    {
    }

    /// <summary>
    /// Sets breakpoint on particular native event.
    /// </summary>
    public class setInstrumentationBreakpointCommand
    {
    }

    /// <summary>
    /// Sets breakpoint on XMLHttpRequest.
    /// </summary>
    public class setXHRBreakpointCommand
    {
    }
}

/// <summary>
/// This domain facilitates obtaining document snapshots with DOM, layout, and style information.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.DOMSnapshot
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables DOM snapshot agent for the given page.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
    /// template contents, and imported documents) in a flattened array, as well as layout and
    /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
    /// flattened.
    /// </summary>
    [Obsolete]
    public class getSnapshotCommand
    {
    }

    /// <summary>
    /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
    /// template contents, and imported documents) in a flattened array, as well as layout and
    /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
    /// flattened.
    /// </summary>
    public class captureSnapshotCommand
    {
    }
}

/// <summary>
/// Query and modify DOM storage.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.DOMStorage
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

    public class clearCommand
    {
    }

    /// <summary>
    /// Disables storage tracking, prevents storage events from being sent to the client.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables storage tracking, storage events will now be delivered to the client.
    /// </summary>
    public class enableCommand
    {
    }

    public class getDOMStorageItemsCommand
    {
    }

    public class removeDOMStorageItemCommand
    {
    }

    public class setDOMStorageItemCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Database
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables database tracking, database events will now be delivered to the client.
    /// </summary>
    public class enableCommand
    {
    }

    public class executeSQLCommand
    {
    }

    public class getDatabaseTableNamesCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.DeviceOrientation
{

    /// <summary>
    /// Clears the overridden Device Orientation.
    /// </summary>
    public class clearDeviceOrientationOverrideCommand
    {
    }

    /// <summary>
    /// Overrides the Device Orientation.
    /// </summary>
    public class setDeviceOrientationOverrideCommand
    {
    }
}

/// <summary>
/// This domain emulates different environments for the page.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Emulation
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
    public class canEmulateCommand
    {
    }

    /// <summary>
    /// Clears the overriden device metrics.
    /// </summary>
    public class clearDeviceMetricsOverrideCommand
    {
    }

    /// <summary>
    /// Clears the overriden Geolocation Position and Error.
    /// </summary>
    public class clearGeolocationOverrideCommand
    {
    }

    /// <summary>
    /// Requests that page scale factor is reset to initial values.
    /// </summary>
    public class resetPageScaleFactorCommand
    {
    }

    /// <summary>
    /// Enables or disables simulating a focused and active page.
    /// </summary>
    public class setFocusEmulationEnabledCommand
    {
    }

    /// <summary>
    /// Enables CPU throttling to emulate slow CPUs.
    /// </summary>
    public class setCPUThrottlingRateCommand
    {
    }

    /// <summary>
    /// Sets or clears an override of the default background color of the frame. This override is used
    /// if the content does not specify one.
    /// </summary>
    public class setDefaultBackgroundColorOverrideCommand
    {
    }

    /// <summary>
    /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
    /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
    /// query results).
    /// </summary>
    public class setDeviceMetricsOverrideCommand
    {
    }

    public class setScrollbarsHiddenCommand
    {
    }

    public class setDocumentCookieDisabledCommand
    {
    }

    public class setEmitTouchEventsForMouseCommand
    {
    }

    /// <summary>
    /// Emulates the given media for CSS media queries.
    /// </summary>
    public class setEmulatedMediaCommand
    {
    }

    /// <summary>
    /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
    /// unavailable.
    /// </summary>
    public class setGeolocationOverrideCommand
    {
    }

    /// <summary>
    /// Overrides value returned by the javascript navigator object.
    /// </summary>
    [Obsolete]
    public class setNavigatorOverridesCommand
    {
    }

    /// <summary>
    /// Sets a specified page scale factor.
    /// </summary>
    public class setPageScaleFactorCommand
    {
    }

    /// <summary>
    /// Switches script execution in the page.
    /// </summary>
    public class setScriptExecutionDisabledCommand
    {
    }

    /// <summary>
    /// Enables touch on platforms which do not support them.
    /// </summary>
    public class setTouchEmulationEnabledCommand
    {
    }

    /// <summary>
    /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
    /// the current virtual time policy.  Note this supersedes any previous time budget.
    /// </summary>
    public class setVirtualTimePolicyCommand
    {
    }

    /// <summary>
    /// Resizes the frame/viewport of the page. Note that this does not affect the frame's container
    /// (e.g. browser window). Can be used to produce screenshots of the specified size. Not supported
    /// on Android.
    /// </summary>
    [Obsolete]
    public class setVisibleSizeCommand
    {
    }

    /// <summary>
    /// Allows overriding user agent with the given string.
    /// </summary>
    public class setUserAgentOverrideCommand
    {
    }
}

/// <summary>
/// This domain provides experimental commands only supported in headless mode.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.HeadlessExperimental
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
    public class beginFrameCommand
    {
    }

    /// <summary>
    /// Disables headless events for the target.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables headless events for the target.
    /// </summary>
    public class enableCommand
    {
    }
}

/// <summary>
/// Input/Output operations for streams produced by DevTools.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.IO
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
    public class closeCommand
    {
    }

    /// <summary>
    /// Read a chunk of the stream
    /// </summary>
    public class readCommand
    {
    }

    /// <summary>
    /// Return UUID of Blob object specified by a remote object id.
    /// </summary>
    public class resolveBlobCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.IndexedDB
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
    public class clearObjectStoreCommand
    {
    }

    /// <summary>
    /// Deletes a database.
    /// </summary>
    public class deleteDatabaseCommand
    {
    }

    /// <summary>
    /// Delete a range of entries from an object store
    /// </summary>
    public class deleteObjectStoreEntriesCommand
    {
    }

    /// <summary>
    /// Disables events from backend.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables events from backend.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Requests data from object store or index.
    /// </summary>
    public class requestDataCommand
    {
    }

    /// <summary>
    /// Requests database with given name in given frame.
    /// </summary>
    public class requestDatabaseCommand
    {
    }

    /// <summary>
    /// Requests database names for given security origin.
    /// </summary>
    public class requestDatabaseNamesCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Input
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
    public class dispatchKeyEventCommand
    {
    }

    /// <summary>
    /// This method emulates inserting text that doesn't come from a key press,
    /// for example an emoji keyboard or an IME.
    /// </summary>
    public class insertTextCommand
    {
    }

    /// <summary>
    /// Dispatches a mouse event to the page.
    /// </summary>
    public class dispatchMouseEventCommand
    {
    }

    /// <summary>
    /// Dispatches a touch event to the page.
    /// </summary>
    public class dispatchTouchEventCommand
    {
    }

    /// <summary>
    /// Emulates touch event from the mouse event parameters.
    /// </summary>
    public class emulateTouchFromMouseEventCommand
    {
    }

    /// <summary>
    /// Ignores input events (useful while auditing page).
    /// </summary>
    public class setIgnoreInputEventsCommand
    {
    }

    /// <summary>
    /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public class synthesizePinchGestureCommand
    {
    }

    /// <summary>
    /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public class synthesizeScrollGestureCommand
    {
    }

    /// <summary>
    /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public class synthesizeTapGestureCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Inspector
{

    /// <summary>
    /// Disables inspector domain notifications.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables inspector domain notifications.
    /// </summary>
    public class enableCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.LayerTree
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
    public class compositingReasonsCommand
    {
    }

    /// <summary>
    /// Disables compositing tree inspection.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables compositing tree inspection.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Returns the snapshot identifier.
    /// </summary>
    public class loadSnapshotCommand
    {
    }

    /// <summary>
    /// Returns the layer snapshot identifier.
    /// </summary>
    public class makeSnapshotCommand
    {
    }

    public class profileSnapshotCommand
    {
    }

    /// <summary>
    /// Releases layer snapshot captured by the back-end.
    /// </summary>
    public class releaseSnapshotCommand
    {
    }

    /// <summary>
    /// Replays the layer snapshot and returns the resulting bitmap.
    /// </summary>
    public class replaySnapshotCommand
    {
    }

    /// <summary>
    /// Replays the layer snapshot and returns canvas log.
    /// </summary>
    public class snapshotCommandLogCommand
    {
    }
}

/// <summary>
/// Provides access to log entries.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Log
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
    public class clearCommand
    {
    }

    /// <summary>
    /// Disables log domain, prevents further log entries from being reported to the client.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables log domain, sends the entries collected so far to the client by means of the
    /// `entryAdded` notification.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// start violation reporting.
    /// </summary>
    public class startViolationsReportCommand
    {
    }

    /// <summary>
    /// Stop violation reporting.
    /// </summary>
    public class stopViolationsReportCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Memory
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

    public class getDOMCountersCommand
    {
    }

    public class prepareForLeakDetectionCommand
    {
    }

    /// <summary>
    /// Enable/disable suppressing memory pressure notifications in all processes.
    /// </summary>
    public class setPressureNotificationsSuppressedCommand
    {
    }

    /// <summary>
    /// Simulate a memory pressure notification in all processes.
    /// </summary>
    public class simulatePressureNotificationCommand
    {
    }

    /// <summary>
    /// Start collecting native memory profile.
    /// </summary>
    public class startSamplingCommand
    {
    }

    /// <summary>
    /// Stop collecting native memory profile.
    /// </summary>
    public class stopSamplingCommand
    {
    }

    /// <summary>
    /// Retrieve native memory allocations profile
    /// collected since renderer process startup.
    /// </summary>
    public class getAllTimeSamplingProfileCommand
    {
    }

    /// <summary>
    /// Retrieve native memory allocations profile
    /// collected since browser process startup.
    /// </summary>
    public class getBrowserSamplingProfileCommand
    {
    }

    /// <summary>
    /// Retrieve native memory allocations profile collected since last
    /// `startSampling` call.
    /// </summary>
    public class getSamplingProfileCommand
    {
    }
}

/// <summary>
/// Network domain allows tracking network activities of the page. It exposes information about http,
/// file, data and other requests and responses, their headers, bodies, timing, etc.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Network
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
    public class canClearBrowserCacheCommand
    {
    }

    /// <summary>
    /// Tells whether clearing browser cookies is supported.
    /// </summary>
    [Obsolete]
    public class canClearBrowserCookiesCommand
    {
    }

    /// <summary>
    /// Tells whether emulation of network conditions is supported.
    /// </summary>
    [Obsolete]
    public class canEmulateNetworkConditionsCommand
    {
    }

    /// <summary>
    /// Clears browser cache.
    /// </summary>
    public class clearBrowserCacheCommand
    {
    }

    /// <summary>
    /// Clears browser cookies.
    /// </summary>
    public class clearBrowserCookiesCommand
    {
    }

    /// <summary>
    /// Response to Network.requestIntercepted which either modifies the request to continue with any
    /// modifications, or blocks it, or completes it with the provided response bytes. If a network
    /// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
    /// event will be sent with the same InterceptionId.
    /// </summary>
    public class continueInterceptedRequestCommand
    {
    }

    /// <summary>
    /// Deletes browser cookies with matching name and url or domain/path pair.
    /// </summary>
    public class deleteCookiesCommand
    {
    }

    /// <summary>
    /// Disables network tracking, prevents network events from being sent to the client.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Activates emulation of network conditions.
    /// </summary>
    public class emulateNetworkConditionsCommand
    {
    }

    /// <summary>
    /// Enables network tracking, network events will now be delivered to the client.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
    /// information in the `cookies` field.
    /// </summary>
    public class getAllCookiesCommand
    {
    }

    /// <summary>
    /// Returns the DER-encoded certificate.
    /// </summary>
    public class getCertificateCommand
    {
    }

    /// <summary>
    /// Returns all browser cookies for the current URL. Depending on the backend support, will return
    /// detailed cookie information in the `cookies` field.
    /// </summary>
    public class getCookiesCommand
    {
    }

    /// <summary>
    /// Returns content served for the given request.
    /// </summary>
    public class getResponseBodyCommand
    {
    }

    /// <summary>
    /// Returns post data sent with the request. Returns an error when no data was sent with the request.
    /// </summary>
    public class getRequestPostDataCommand
    {
    }

    /// <summary>
    /// Returns content served for the given currently intercepted request.
    /// </summary>
    public class getResponseBodyForInterceptionCommand
    {
    }

    /// <summary>
    /// Returns a handle to the stream representing the response body. Note that after this command,
    /// the intercepted request can't be continued as is -- you either need to cancel it or to provide
    /// the response body. The stream only supports sequential read, IO.read will fail if the position
    /// is specified.
    /// </summary>
    public class takeResponseBodyForInterceptionAsStreamCommand
    {
    }

    /// <summary>
    /// This method sends a new XMLHttpRequest which is identical to the original one. The following
    /// parameters should be identical: method, url, async, request body, extra headers, withCredentials
    /// attribute, user, password.
    /// </summary>
    public class replayXHRCommand
    {
    }

    /// <summary>
    /// Searches for given string in response content.
    /// </summary>
    public class searchInResponseBodyCommand
    {
    }

    /// <summary>
    /// Blocks URLs from loading.
    /// </summary>
    public class setBlockedURLsCommand
    {
    }

    /// <summary>
    /// Toggles ignoring of service worker for each request.
    /// </summary>
    public class setBypassServiceWorkerCommand
    {
    }

    /// <summary>
    /// Toggles ignoring cache for each request. If `true`, cache will not be used.
    /// </summary>
    public class setCacheDisabledCommand
    {
    }

    /// <summary>
    /// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
    /// </summary>
    public class setCookieCommand
    {
    }

    /// <summary>
    /// Sets given cookies.
    /// </summary>
    public class setCookiesCommand
    {
    }

    /// <summary>
    /// For testing.
    /// </summary>
    public class setDataSizeLimitsForTestCommand
    {
    }

    /// <summary>
    /// Specifies whether to always send extra HTTP headers with the requests from this page.
    /// </summary>
    public class setExtraHTTPHeadersCommand
    {
    }

    /// <summary>
    /// Sets the requests to intercept that match a the provided patterns and optionally resource types.
    /// </summary>
    public class setRequestInterceptionCommand
    {
    }

    /// <summary>
    /// Allows overriding user agent with the given string.
    /// </summary>
    public class setUserAgentOverrideCommand
    {
    }
}

/// <summary>
/// This domain provides various functionality related to drawing atop the inspected page.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Overlay
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables domain notifications.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// For testing.
    /// </summary>
    public class getHighlightObjectForTestCommand
    {
    }

    /// <summary>
    /// Hides any highlight.
    /// </summary>
    public class hideHighlightCommand
    {
    }

    /// <summary>
    /// Highlights owner element of the frame with given id.
    /// </summary>
    public class highlightFrameCommand
    {
    }

    /// <summary>
    /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
    /// objectId must be specified.
    /// </summary>
    public class highlightNodeCommand
    {
    }

    /// <summary>
    /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
    /// </summary>
    public class highlightQuadCommand
    {
    }

    /// <summary>
    /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
    /// </summary>
    public class highlightRectCommand
    {
    }

    /// <summary>
    /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
    /// Backend then generates 'inspectNodeRequested' event upon element selection.
    /// </summary>
    public class setInspectModeCommand
    {
    }

    public class setPausedInDebuggerMessageCommand
    {
    }

    /// <summary>
    /// Requests that backend shows debug borders on layers
    /// </summary>
    public class setShowDebugBordersCommand
    {
    }

    /// <summary>
    /// Requests that backend shows the FPS counter
    /// </summary>
    public class setShowFPSCounterCommand
    {
    }

    /// <summary>
    /// Requests that backend shows paint rectangles
    /// </summary>
    public class setShowPaintRectsCommand
    {
    }

    /// <summary>
    /// Requests that backend shows scroll bottleneck rects
    /// </summary>
    public class setShowScrollBottleneckRectsCommand
    {
    }

    /// <summary>
    /// Requests that backend shows hit-test borders on layers
    /// </summary>
    public class setShowHitTestBordersCommand
    {
    }

    /// <summary>
    /// Paints viewport size upon main frame resize.
    /// </summary>
    public class setShowViewportSizeOnResizeCommand
    {
    }

    public class setSuspendedCommand
    {
    }
}

/// <summary>
/// Actions and events related to the inspected page belong to the page domain.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Page
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
    public class addScriptToEvaluateOnLoadCommand
    {
    }

    /// <summary>
    /// Evaluates given script in every frame upon creation (before loading frame's scripts).
    /// </summary>
    public class addScriptToEvaluateOnNewDocumentCommand
    {
    }

    /// <summary>
    /// Brings page to front (activates tab).
    /// </summary>
    public class bringToFrontCommand
    {
    }

    /// <summary>
    /// Capture page screenshot.
    /// </summary>
    public class captureScreenshotCommand
    {
    }

    /// <summary>
    /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
    /// iframes, shadow DOM, external resources, and element-inline styles.
    /// </summary>
    public class captureSnapshotCommand
    {
    }

    /// <summary>
    /// Clears the overriden device metrics.
    /// </summary>
    [Obsolete]
    public class clearDeviceMetricsOverrideCommand
    {
    }

    /// <summary>
    /// Clears the overridden Device Orientation.
    /// </summary>
    [Obsolete]
    public class clearDeviceOrientationOverrideCommand
    {
    }

    /// <summary>
    /// Clears the overriden Geolocation Position and Error.
    /// </summary>
    [Obsolete]
    public class clearGeolocationOverrideCommand
    {
    }

    /// <summary>
    /// Creates an isolated world for the given frame.
    /// </summary>
    public class createIsolatedWorldCommand
    {
    }

    /// <summary>
    /// Deletes browser cookie with given name, domain and path.
    /// </summary>
    [Obsolete]
    public class deleteCookieCommand
    {
    }

    /// <summary>
    /// Disables page domain notifications.
    /// </summary>
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables page domain notifications.
    /// </summary>
    public class enableCommand
    {
    }

    public class getAppManifestCommand
    {
    }

    /// <summary>
    /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
    /// information in the `cookies` field.
    /// </summary>
    [Obsolete]
    public class getCookiesCommand
    {
    }

    /// <summary>
    /// Returns present frame tree structure.
    /// </summary>
    public class getFrameTreeCommand
    {
    }

    /// <summary>
    /// Returns metrics relating to the layouting of the page, such as viewport bounds/scale.
    /// </summary>
    public class getLayoutMetricsCommand
    {
    }

    /// <summary>
    /// Returns navigation history for the current page.
    /// </summary>
    public class getNavigationHistoryCommand
    {
    }

    /// <summary>
    /// Resets navigation history for the current page.
    /// </summary>
    public class resetNavigationHistoryCommand
    {
    }

    /// <summary>
    /// Returns content of the given resource.
    /// </summary>
    public class getResourceContentCommand
    {
    }

    /// <summary>
    /// Returns present frame / resource tree structure.
    /// </summary>
    public class getResourceTreeCommand
    {
    }

    /// <summary>
    /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
    /// </summary>
    public class handleJavaScriptDialogCommand
    {
    }

    /// <summary>
    /// Navigates current page to the given URL.
    /// </summary>
    public class navigateCommand
    {
    }

    /// <summary>
    /// Navigates current page to the given history entry.
    /// </summary>
    public class navigateToHistoryEntryCommand
    {
    }

    /// <summary>
    /// Print page as PDF.
    /// </summary>
    public class printToPDFCommand
    {
    }

    /// <summary>
    /// Reloads given page optionally ignoring the cache.
    /// </summary>
    public class reloadCommand
    {
    }

    /// <summary>
    /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
    /// </summary>
    [Obsolete]
    public class removeScriptToEvaluateOnLoadCommand
    {
    }

    /// <summary>
    /// Removes given script from the list.
    /// </summary>
    public class removeScriptToEvaluateOnNewDocumentCommand
    {
    }

    /// <summary>
    /// Acknowledges that a screencast frame has been received by the frontend.
    /// </summary>
    public class screencastFrameAckCommand
    {
    }

    /// <summary>
    /// Searches for given string in resource content.
    /// </summary>
    public class searchInResourceCommand
    {
    }

    /// <summary>
    /// Enable Chrome's experimental ad filter on all sites.
    /// </summary>
    public class setAdBlockingEnabledCommand
    {
    }

    /// <summary>
    /// Enable page Content Security Policy by-passing.
    /// </summary>
    public class setBypassCSPCommand
    {
    }

    /// <summary>
    /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
    /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
    /// query results).
    /// </summary>
    [Obsolete]
    public class setDeviceMetricsOverrideCommand
    {
    }

    /// <summary>
    /// Overrides the Device Orientation.
    /// </summary>
    [Obsolete]
    public class setDeviceOrientationOverrideCommand
    {
    }

    /// <summary>
    /// Set generic font families.
    /// </summary>
    public class setFontFamiliesCommand
    {
    }

    /// <summary>
    /// Set default font sizes.
    /// </summary>
    public class setFontSizesCommand
    {
    }

    /// <summary>
    /// Sets given markup as the document's HTML.
    /// </summary>
    public class setDocumentContentCommand
    {
    }

    /// <summary>
    /// Set the behavior when downloading a file.
    /// </summary>
    public class setDownloadBehaviorCommand
    {
    }

    /// <summary>
    /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
    /// unavailable.
    /// </summary>
    [Obsolete]
    public class setGeolocationOverrideCommand
    {
    }

    /// <summary>
    /// Controls whether page will emit lifecycle events.
    /// </summary>
    public class setLifecycleEventsEnabledCommand
    {
    }

    /// <summary>
    /// Toggles mouse event-based touch event emulation.
    /// </summary>
    [Obsolete]
    public class setTouchEmulationEnabledCommand
    {
    }

    /// <summary>
    /// Starts sending each frame using the `screencastFrame` event.
    /// </summary>
    public class startScreencastCommand
    {
    }

    /// <summary>
    /// Force the page stop all navigations and pending resource fetches.
    /// </summary>
    public class stopLoadingCommand
    {
    }

    /// <summary>
    /// Crashes renderer on the IO thread, generates minidumps.
    /// </summary>
    public class crashCommand
    {
    }

    /// <summary>
    /// Tries to close page, running its beforeunload hooks, if any.
    /// </summary>
    public class closeCommand
    {
    }

    /// <summary>
    /// Tries to update the web lifecycle state of the page.
    /// It will transition the page to the given state according to:
    /// https://github.com/WICG/web-lifecycle/
    /// </summary>
    public class setWebLifecycleStateCommand
    {
    }

    /// <summary>
    /// Stops sending each frame in the `screencastFrame`.
    /// </summary>
    public class stopScreencastCommand
    {
    }

    /// <summary>
    /// Forces compilation cache to be generated for every subresource script.
    /// </summary>
    public class setProduceCompilationCacheCommand
    {
    }

    /// <summary>
    /// Seeds compilation cache for given url. Compilation cache does not survive
    /// cross-process navigation.
    /// </summary>
    public class addCompilationCacheCommand
    {
    }

    /// <summary>
    /// Clears seeded compilation cache.
    /// </summary>
    public class clearCompilationCacheCommand
    {
    }

    /// <summary>
    /// Generates a report for testing.
    /// </summary>
    public class generateTestReportCommand
    {
    }

    /// <summary>
    /// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
    /// </summary>
    public class waitForDebuggerCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Performance
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enable collecting and reporting metrics.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Sets time domain to use for collecting and reporting duration metrics.
    /// Note that this must be called before enabling metrics collection. Calling
    /// this method while metrics collection is enabled returns an error.
    /// </summary>
    public class setTimeDomainCommand
    {
    }

    /// <summary>
    /// Retrieve current values of run-time metrics.
    /// </summary>
    public class getMetricsCommand
    {
    }
}

/// <summary>
/// Security
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Security
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables tracking security state changes.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Enable/disable whether all certificate errors should be ignored.
    /// </summary>
    public class setIgnoreCertificateErrorsCommand
    {
    }

    /// <summary>
    /// Handles a certificate error that fired a certificateError event.
    /// </summary>
    [Obsolete]
    public class handleCertificateErrorCommand
    {
    }

    /// <summary>
    /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
    /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
    /// </summary>
    [Obsolete]
    public class setOverrideCertificateErrorsCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.ServiceWorker
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

    public class deliverPushMessageCommand
    {
    }

    public class disableCommand
    {
    }

    public class dispatchSyncEventCommand
    {
    }

    public class enableCommand
    {
    }

    public class inspectWorkerCommand
    {
    }

    public class setForceUpdateOnPageLoadCommand
    {
    }

    public class skipWaitingCommand
    {
    }

    public class startWorkerCommand
    {
    }

    public class stopAllWorkersCommand
    {
    }

    public class stopWorkerCommand
    {
    }

    public class unregisterCommand
    {
    }

    public class updateRegistrationCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Storage
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
    public class clearDataForOriginCommand
    {
    }

    /// <summary>
    /// Returns usage and quota in bytes.
    /// </summary>
    public class getUsageAndQuotaCommand
    {
    }

    /// <summary>
    /// Registers origin to be notified when an update occurs to its cache storage list.
    /// </summary>
    public class trackCacheStorageForOriginCommand
    {
    }

    /// <summary>
    /// Registers origin to be notified when an update occurs to its IndexedDB.
    /// </summary>
    public class trackIndexedDBForOriginCommand
    {
    }

    /// <summary>
    /// Unregisters origin from receiving notifications for cache storage.
    /// </summary>
    public class untrackCacheStorageForOriginCommand
    {
    }

    /// <summary>
    /// Unregisters origin from receiving notifications for IndexedDB.
    /// </summary>
    public class untrackIndexedDBForOriginCommand
    {
    }
}

/// <summary>
/// The SystemInfo domain defines methods and events for querying low-level system information.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.SystemInfo
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
    public class getInfoCommand
    {
    }

    /// <summary>
    /// Returns information about all running processes.
    /// </summary>
    public class getProcessInfoCommand
    {
    }
}

/// <summary>
/// Supports additional targets discovery and allows to attach to them.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Target
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
    public class activateTargetCommand
    {
    }

    /// <summary>
    /// Attaches to the target with given id.
    /// </summary>
    public class attachToTargetCommand
    {
    }

    /// <summary>
    /// Attaches to the browser target, only uses flat sessionId mode.
    /// </summary>
    public class attachToBrowserTargetCommand
    {
    }

    /// <summary>
    /// Closes the target. If the target is a page that gets closed too.
    /// </summary>
    public class closeTargetCommand
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
    public class exposeDevToolsProtocolCommand
    {
    }

    /// <summary>
    /// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
    /// one.
    /// </summary>
    public class createBrowserContextCommand
    {
    }

    /// <summary>
    /// Returns all browser contexts created with `Target.createBrowserContext` method.
    /// </summary>
    public class getBrowserContextsCommand
    {
    }

    /// <summary>
    /// Creates a new page.
    /// </summary>
    public class createTargetCommand
    {
    }

    /// <summary>
    /// Detaches session with given id.
    /// </summary>
    public class detachFromTargetCommand
    {
    }

    /// <summary>
    /// Deletes a BrowserContext. All the belonging pages will be closed without calling their
    /// beforeunload hooks.
    /// </summary>
    public class disposeBrowserContextCommand
    {
    }

    /// <summary>
    /// Returns information about a target.
    /// </summary>
    public class getTargetInfoCommand
    {
    }

    /// <summary>
    /// Retrieves a list of available targets.
    /// </summary>
    public class getTargetsCommand
    {
    }

    /// <summary>
    /// Sends protocol message over session with given id.
    /// </summary>
    public class sendMessageToTargetCommand
    {
    }

    /// <summary>
    /// Controls whether to automatically attach to new targets which are considered to be related to
    /// this one. When turned on, attaches to all existing related targets as well. When turned off,
    /// automatically detaches from all currently attached targets.
    /// </summary>
    public class setAutoAttachCommand
    {
    }

    /// <summary>
    /// Controls whether to discover available targets and notify via
    /// `targetCreated/targetInfoChanged/targetDestroyed` events.
    /// </summary>
    public class setDiscoverTargetsCommand
    {
    }

    /// <summary>
    /// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
    /// `true`.
    /// </summary>
    public class setRemoteLocationsCommand
    {
    }
}

/// <summary>
/// The Tethering domain defines methods and events for browser port binding.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Tethering
{

    /// <summary>
    /// Request browser port binding.
    /// </summary>
    public class bindCommand
    {
    }

    /// <summary>
    /// Request browser port unbinding.
    /// </summary>
    public class unbindCommand
    {
    }
}

namespace DumbPrograms.ChromeDevTools.Protocol.Tracing
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
    public class endCommand
    {
    }

    /// <summary>
    /// Gets supported tracing categories.
    /// </summary>
    public class getCategoriesCommand
    {
    }

    /// <summary>
    /// Record a clock sync marker in the trace.
    /// </summary>
    public class recordClockSyncMarkerCommand
    {
    }

    /// <summary>
    /// Request a global memory dump.
    /// </summary>
    public class requestMemoryDumpCommand
    {
    }

    /// <summary>
    /// Start trace events collection.
    /// </summary>
    public class startCommand
    {
    }
}

/// <summary>
/// Testing domain is a dumping ground for the capabilities requires for browser or app testing that do not fit other
/// domains.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Testing
{

    /// <summary>
    /// Generates a report for testing.
    /// </summary>
    public class generateTestReportCommand
    {
    }
}

/// <summary>
/// A domain for letting clients substitute browser's network layer with client code.
/// </summary>
namespace DumbPrograms.ChromeDevTools.Protocol.Fetch
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
    public class disableCommand
    {
    }

    /// <summary>
    /// Enables issuing of requestPaused events. A request will be paused until client
    /// calls one of failRequest, fulfillRequest or continueRequest/continueWithAuth.
    /// </summary>
    public class enableCommand
    {
    }

    /// <summary>
    /// Causes the request to fail with specified reason.
    /// </summary>
    public class failRequestCommand
    {
    }

    /// <summary>
    /// Provides response to the request.
    /// </summary>
    public class fulfillRequestCommand
    {
    }

    /// <summary>
    /// Continues the request, optionally modifying some of its parameters.
    /// </summary>
    public class continueRequestCommand
    {
    }

    /// <summary>
    /// Continues a request supplying authChallengeResponse following authRequired event.
    /// </summary>
    public class continueWithAuthCommand
    {
    }

    /// <summary>
    /// Causes the body of the response to be received from the server and
    /// returned as a single string. May only be issued for a request that
    /// is paused in the Response stage and is mutually exclusive with
    /// takeResponseBodyForInterceptionAsStream. Calling other methods that
    /// affect the request or disabling fetch domain before body is received
    /// results in an undefined behavior.
    /// </summary>
    public class getResponseBodyCommand
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
    public class takeResponseBodyAsStreamCommand
    {
    }
}
