using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools.Protocol
{

    namespace Accessibility
    {

        /// <summary>
        /// Unique accessibility node identifier.
        /// </summary>
        public struct AXNodeId : IAlias<string>
        {
            public string Value { get; private set; }

            public AXNodeId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Enum of possible property types.
        /// </summary>
        public struct AXValueType : IEnum
        {
            public string Value { get; private set; }

            public AXValueType(string value)
            {
                Value = value;
            }

            public static AXValueType Boolean => new AXValueType("boolean");
            public static AXValueType Tristate => new AXValueType("tristate");
            public static AXValueType BooleanOrUndefined => new AXValueType("booleanOrUndefined");
            public static AXValueType Idref => new AXValueType("idref");
            public static AXValueType IdrefList => new AXValueType("idrefList");
            public static AXValueType Integer => new AXValueType("integer");
            public static AXValueType Node => new AXValueType("node");
            public static AXValueType NodeList => new AXValueType("nodeList");
            public static AXValueType Number => new AXValueType("number");
            public static AXValueType String => new AXValueType("string");
            public static AXValueType ComputedString => new AXValueType("computedString");
            public static AXValueType Token => new AXValueType("token");
            public static AXValueType TokenList => new AXValueType("tokenList");
            public static AXValueType DomRelation => new AXValueType("domRelation");
            public static AXValueType Role => new AXValueType("role");
            public static AXValueType InternalRole => new AXValueType("internalRole");
            public static AXValueType ValueUndefined => new AXValueType("valueUndefined");
        }

        /// <summary>
        /// Enum of possible property sources.
        /// </summary>
        public struct AXValueSourceType : IEnum
        {
            public string Value { get; private set; }

            public AXValueSourceType(string value)
            {
                Value = value;
            }

            public static AXValueSourceType Attribute => new AXValueSourceType("attribute");
            public static AXValueSourceType Implicit => new AXValueSourceType("implicit");
            public static AXValueSourceType Style => new AXValueSourceType("style");
            public static AXValueSourceType Contents => new AXValueSourceType("contents");
            public static AXValueSourceType Placeholder => new AXValueSourceType("placeholder");
            public static AXValueSourceType RelatedElement => new AXValueSourceType("relatedElement");
        }

        /// <summary>
        /// Enum of possible native property sources (as a subtype of a particular AXValueSourceType).
        /// </summary>
        public struct AXValueNativeSourceType : IEnum
        {
            public string Value { get; private set; }

            public AXValueNativeSourceType(string value)
            {
                Value = value;
            }

            public static AXValueNativeSourceType Figcaption => new AXValueNativeSourceType("figcaption");
            public static AXValueNativeSourceType Label => new AXValueNativeSourceType("label");
            public static AXValueNativeSourceType Labelfor => new AXValueNativeSourceType("labelfor");
            public static AXValueNativeSourceType Labelwrapped => new AXValueNativeSourceType("labelwrapped");
            public static AXValueNativeSourceType Legend => new AXValueNativeSourceType("legend");
            public static AXValueNativeSourceType Tablecaption => new AXValueNativeSourceType("tablecaption");
            public static AXValueNativeSourceType Title => new AXValueNativeSourceType("title");
            public static AXValueNativeSourceType Other => new AXValueNativeSourceType("other");
        }

        /// <summary>
        /// A single source for a computed AX property.
        /// </summary>
        public class AXValueSource
        {

            /// <summary>
            /// What type of source this is.
            /// </summary>
            [JsonProperty("type")]
            public AXValueSourceType Type { get; set; }

            /// <summary>
            /// The value of this property source.
            /// </summary>
            [JsonProperty("value")]
            public AXValue Value { get; set; }

            /// <summary>
            /// The name of the relevant attribute, if any.
            /// </summary>
            [JsonProperty("attribute")]
            public string Attribute { get; set; }

            /// <summary>
            /// The value of the relevant attribute, if any.
            /// </summary>
            [JsonProperty("attributeValue")]
            public AXValue AttributeValue { get; set; }

            /// <summary>
            /// Whether this source is superseded by a higher priority source.
            /// </summary>
            [JsonProperty("superseded")]
            public bool Superseded { get; set; }

            /// <summary>
            /// The native markup source for this value, e.g. a &lt;label&gt; element.
            /// </summary>
            [JsonProperty("nativeSource")]
            public AXValueNativeSourceType NativeSource { get; set; }

            /// <summary>
            /// The value, such as a node or node list, of the native source.
            /// </summary>
            [JsonProperty("nativeSourceValue")]
            public AXValue NativeSourceValue { get; set; }

            /// <summary>
            /// Whether the value for this property is invalid.
            /// </summary>
            [JsonProperty("invalid")]
            public bool Invalid { get; set; }

            /// <summary>
            /// Reason for the value being invalid, if it is.
            /// </summary>
            [JsonProperty("invalidReason")]
            public string InvalidReason { get; set; }
        }

        public class AXRelatedNode
        {

            /// <summary>
            /// The BackendNodeId of the related DOM node.
            /// </summary>
            [JsonProperty("backendDOMNodeId")]
            public DOM.BackendNodeId BackendDOMNodeId { get; set; }

            /// <summary>
            /// The IDRef value provided, if any.
            /// </summary>
            [JsonProperty("idref")]
            public string Idref { get; set; }

            /// <summary>
            /// The text alternative of this node in the current context.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public class AXProperty
        {

            /// <summary>
            /// The name of this property.
            /// </summary>
            [JsonProperty("name")]
            public AXPropertyName Name { get; set; }

            /// <summary>
            /// The value of this property.
            /// </summary>
            [JsonProperty("value")]
            public AXValue Value { get; set; }
        }

        /// <summary>
        /// A single computed AX property.
        /// </summary>
        public class AXValue
        {

            /// <summary>
            /// The type of this value.
            /// </summary>
            [JsonProperty("type")]
            public AXValueType Type { get; set; }

            /// <summary>
            /// The computed value of this property.
            /// </summary>
            [JsonProperty("value")]
            public object Value { get; set; }

            /// <summary>
            /// One or more related nodes, if applicable.
            /// </summary>
            [JsonProperty("relatedNodes")]
            public AXRelatedNode[] RelatedNodes { get; set; }

            /// <summary>
            /// The sources which contributed to the computation of this property.
            /// </summary>
            [JsonProperty("sources")]
            public AXValueSource[] Sources { get; set; }
        }

        /// <summary>
        /// Values of AXProperty name:
        /// - from 'busy' to 'roledescription': states which apply to every AX node
        /// - from 'live' to 'root': attributes which apply to nodes in live regions
        /// - from 'autocomplete' to 'valuetext': attributes which apply to widgets
        /// - from 'checked' to 'selected': states which apply to widgets
        /// - from 'activedescendant' to 'owns' - relationships between elements other than parent/child/sibling.
        /// </summary>
        public struct AXPropertyName : IEnum
        {
            public string Value { get; private set; }

            public AXPropertyName(string value)
            {
                Value = value;
            }

            public static AXPropertyName Busy => new AXPropertyName("busy");
            public static AXPropertyName Disabled => new AXPropertyName("disabled");
            public static AXPropertyName Editable => new AXPropertyName("editable");
            public static AXPropertyName Focusable => new AXPropertyName("focusable");
            public static AXPropertyName Focused => new AXPropertyName("focused");
            public static AXPropertyName Hidden => new AXPropertyName("hidden");
            public static AXPropertyName HiddenRoot => new AXPropertyName("hiddenRoot");
            public static AXPropertyName Invalid => new AXPropertyName("invalid");
            public static AXPropertyName Keyshortcuts => new AXPropertyName("keyshortcuts");
            public static AXPropertyName Settable => new AXPropertyName("settable");
            public static AXPropertyName Roledescription => new AXPropertyName("roledescription");
            public static AXPropertyName Live => new AXPropertyName("live");
            public static AXPropertyName Atomic => new AXPropertyName("atomic");
            public static AXPropertyName Relevant => new AXPropertyName("relevant");
            public static AXPropertyName Root => new AXPropertyName("root");
            public static AXPropertyName Autocomplete => new AXPropertyName("autocomplete");
            public static AXPropertyName HasPopup => new AXPropertyName("hasPopup");
            public static AXPropertyName Level => new AXPropertyName("level");
            public static AXPropertyName Multiselectable => new AXPropertyName("multiselectable");
            public static AXPropertyName Orientation => new AXPropertyName("orientation");
            public static AXPropertyName Multiline => new AXPropertyName("multiline");
            public static AXPropertyName Readonly => new AXPropertyName("readonly");
            public static AXPropertyName Required => new AXPropertyName("required");
            public static AXPropertyName Valuemin => new AXPropertyName("valuemin");
            public static AXPropertyName Valuemax => new AXPropertyName("valuemax");
            public static AXPropertyName Valuetext => new AXPropertyName("valuetext");
            public static AXPropertyName Checked => new AXPropertyName("checked");
            public static AXPropertyName Expanded => new AXPropertyName("expanded");
            public static AXPropertyName Modal => new AXPropertyName("modal");
            public static AXPropertyName Pressed => new AXPropertyName("pressed");
            public static AXPropertyName Selected => new AXPropertyName("selected");
            public static AXPropertyName Activedescendant => new AXPropertyName("activedescendant");
            public static AXPropertyName Controls => new AXPropertyName("controls");
            public static AXPropertyName Describedby => new AXPropertyName("describedby");
            public static AXPropertyName Details => new AXPropertyName("details");
            public static AXPropertyName Errormessage => new AXPropertyName("errormessage");
            public static AXPropertyName Flowto => new AXPropertyName("flowto");
            public static AXPropertyName Labelledby => new AXPropertyName("labelledby");
            public static AXPropertyName Owns => new AXPropertyName("owns");
        }

        /// <summary>
        /// A node in the accessibility tree.
        /// </summary>
        public class AXNode
        {

            /// <summary>
            /// Unique identifier for this node.
            /// </summary>
            [JsonProperty("nodeId")]
            public AXNodeId NodeId { get; set; }

            /// <summary>
            /// Whether this node is ignored for accessibility
            /// </summary>
            [JsonProperty("ignored")]
            public bool Ignored { get; set; }

            /// <summary>
            /// Collection of reasons why this node is hidden.
            /// </summary>
            [JsonProperty("ignoredReasons")]
            public AXProperty[] IgnoredReasons { get; set; }

            /// <summary>
            /// This `Node`'s role, whether explicit or implicit.
            /// </summary>
            [JsonProperty("role")]
            public AXValue Role { get; set; }

            /// <summary>
            /// The accessible name for this `Node`.
            /// </summary>
            [JsonProperty("name")]
            public AXValue Name { get; set; }

            /// <summary>
            /// The accessible description for this `Node`.
            /// </summary>
            [JsonProperty("description")]
            public AXValue Description { get; set; }

            /// <summary>
            /// The value for this `Node`.
            /// </summary>
            [JsonProperty("value")]
            public AXValue Value { get; set; }

            /// <summary>
            /// All other properties
            /// </summary>
            [JsonProperty("properties")]
            public AXProperty[] Properties { get; set; }

            /// <summary>
            /// IDs for each of this node's child nodes.
            /// </summary>
            [JsonProperty("childIds")]
            public AXNodeId[] ChildIds { get; set; }

            /// <summary>
            /// The backend ID for the associated DOM node, if any.
            /// </summary>
            [JsonProperty("backendDOMNodeId")]
            public DOM.BackendNodeId BackendDOMNodeId { get; set; }
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

            /// <summary>
            /// `Animation`'s id.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            /// `Animation`'s name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// `Animation`'s internal paused state.
            /// </summary>
            [JsonProperty("pausedState")]
            public bool PausedState { get; set; }

            /// <summary>
            /// `Animation`'s play state.
            /// </summary>
            [JsonProperty("playState")]
            public string PlayState { get; set; }

            /// <summary>
            /// `Animation`'s playback rate.
            /// </summary>
            [JsonProperty("playbackRate")]
            public double PlaybackRate { get; set; }

            /// <summary>
            /// `Animation`'s start time.
            /// </summary>
            [JsonProperty("startTime")]
            public double StartTime { get; set; }

            /// <summary>
            /// `Animation`'s current time.
            /// </summary>
            [JsonProperty("currentTime")]
            public double CurrentTime { get; set; }

            /// <summary>
            /// Animation type of `Animation`.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// `Animation`'s source animation node.
            /// </summary>
            [JsonProperty("source")]
            public AnimationEffect Source { get; set; }

            /// <summary>
            /// A unique ID for `Animation` representing the sources that triggered this CSS
            /// animation/transition.
            /// </summary>
            [JsonProperty("cssId")]
            public string CssId { get; set; }
        }

        /// <summary>
        /// AnimationEffect instance
        /// </summary>
        public class AnimationEffect
        {

            /// <summary>
            /// `AnimationEffect`'s delay.
            /// </summary>
            [JsonProperty("delay")]
            public double Delay { get; set; }

            /// <summary>
            /// `AnimationEffect`'s end delay.
            /// </summary>
            [JsonProperty("endDelay")]
            public double EndDelay { get; set; }

            /// <summary>
            /// `AnimationEffect`'s iteration start.
            /// </summary>
            [JsonProperty("iterationStart")]
            public double IterationStart { get; set; }

            /// <summary>
            /// `AnimationEffect`'s iterations.
            /// </summary>
            [JsonProperty("iterations")]
            public double Iterations { get; set; }

            /// <summary>
            /// `AnimationEffect`'s iteration duration.
            /// </summary>
            [JsonProperty("duration")]
            public double Duration { get; set; }

            /// <summary>
            /// `AnimationEffect`'s playback direction.
            /// </summary>
            [JsonProperty("direction")]
            public string Direction { get; set; }

            /// <summary>
            /// `AnimationEffect`'s fill mode.
            /// </summary>
            [JsonProperty("fill")]
            public string Fill { get; set; }

            /// <summary>
            /// `AnimationEffect`'s target node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// `AnimationEffect`'s keyframes.
            /// </summary>
            [JsonProperty("keyframesRule")]
            public KeyframesRule KeyframesRule { get; set; }

            /// <summary>
            /// `AnimationEffect`'s timing function.
            /// </summary>
            [JsonProperty("easing")]
            public string Easing { get; set; }
        }

        /// <summary>
        /// Keyframes Rule
        /// </summary>
        public class KeyframesRule
        {

            /// <summary>
            /// CSS keyframed animation's name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// List of animation keyframes.
            /// </summary>
            [JsonProperty("keyframes")]
            public KeyframeStyle[] Keyframes { get; set; }
        }

        /// <summary>
        /// Keyframe Style
        /// </summary>
        public class KeyframeStyle
        {

            /// <summary>
            /// Keyframe's time offset.
            /// </summary>
            [JsonProperty("offset")]
            public string Offset { get; set; }

            /// <summary>
            /// `AnimationEffect`'s timing function.
            /// </summary>
            [JsonProperty("easing")]
            public string Easing { get; set; }
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

            /// <summary>
            /// Resource url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Resource size.
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }

            /// <summary>
            /// Resource type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
        }

        /// <summary>
        /// Detailed application cache information.
        /// </summary>
        public class ApplicationCache
        {

            /// <summary>
            /// Manifest URL.
            /// </summary>
            [JsonProperty("manifestURL")]
            public string ManifestURL { get; set; }

            /// <summary>
            /// Application cache size.
            /// </summary>
            [JsonProperty("size")]
            public double Size { get; set; }

            /// <summary>
            /// Application cache creation time.
            /// </summary>
            [JsonProperty("creationTime")]
            public double CreationTime { get; set; }

            /// <summary>
            /// Application cache update time.
            /// </summary>
            [JsonProperty("updateTime")]
            public double UpdateTime { get; set; }

            /// <summary>
            /// Application cache resources.
            /// </summary>
            [JsonProperty("resources")]
            public ApplicationCacheResource[] Resources { get; set; }
        }

        /// <summary>
        /// Frame identifier - manifest URL pair.
        /// </summary>
        public class FrameWithManifest
        {

            /// <summary>
            /// Frame identifier.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// Manifest URL.
            /// </summary>
            [JsonProperty("manifestURL")]
            public string ManifestURL { get; set; }

            /// <summary>
            /// Application cache status.
            /// </summary>
            [JsonProperty("status")]
            public int Status { get; set; }
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

        public struct WindowID : IAlias<int>
        {
            public int Value { get; private set; }

            public WindowID(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// The state of the browser window.
        /// </summary>
        public struct WindowState : IEnum
        {
            public string Value { get; private set; }

            public WindowState(string value)
            {
                Value = value;
            }

            public static WindowState Normal => new WindowState("normal");
            public static WindowState Minimized => new WindowState("minimized");
            public static WindowState Maximized => new WindowState("maximized");
            public static WindowState Fullscreen => new WindowState("fullscreen");
        }

        /// <summary>
        /// Browser window bounds information
        /// </summary>
        public class Bounds
        {

            /// <summary>
            /// The offset from the left edge of the screen to the window in pixels.
            /// </summary>
            [JsonProperty("left")]
            public int Left { get; set; }

            /// <summary>
            /// The offset from the top edge of the screen to the window in pixels.
            /// </summary>
            [JsonProperty("top")]
            public int Top { get; set; }

            /// <summary>
            /// The window width in pixels.
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// The window height in pixels.
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// The window state. Default to normal.
            /// </summary>
            [JsonProperty("windowState")]
            public WindowState WindowState { get; set; }
        }

        public struct PermissionType : IEnum
        {
            public string Value { get; private set; }

            public PermissionType(string value)
            {
                Value = value;
            }

            public static PermissionType AccessibilityEvents => new PermissionType("accessibilityEvents");
            public static PermissionType AudioCapture => new PermissionType("audioCapture");
            public static PermissionType BackgroundSync => new PermissionType("backgroundSync");
            public static PermissionType BackgroundFetch => new PermissionType("backgroundFetch");
            public static PermissionType ClipboardRead => new PermissionType("clipboardRead");
            public static PermissionType ClipboardWrite => new PermissionType("clipboardWrite");
            public static PermissionType DurableStorage => new PermissionType("durableStorage");
            public static PermissionType Flash => new PermissionType("flash");
            public static PermissionType Geolocation => new PermissionType("geolocation");
            public static PermissionType Midi => new PermissionType("midi");
            public static PermissionType MidiSysex => new PermissionType("midiSysex");
            public static PermissionType Notifications => new PermissionType("notifications");
            public static PermissionType PaymentHandler => new PermissionType("paymentHandler");
            public static PermissionType ProtectedMediaIdentifier => new PermissionType("protectedMediaIdentifier");
            public static PermissionType Sensors => new PermissionType("sensors");
            public static PermissionType VideoCapture => new PermissionType("videoCapture");
        }

        /// <summary>
        /// Chrome histogram bucket.
        /// </summary>
        public class Bucket
        {

            /// <summary>
            /// Minimum value (inclusive).
            /// </summary>
            [JsonProperty("low")]
            public int Low { get; set; }

            /// <summary>
            /// Maximum value (exclusive).
            /// </summary>
            [JsonProperty("high")]
            public int High { get; set; }

            /// <summary>
            /// Number of samples.
            /// </summary>
            [JsonProperty("count")]
            public int Count { get; set; }
        }

        /// <summary>
        /// Chrome histogram.
        /// </summary>
        public class Histogram
        {

            /// <summary>
            /// Name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Sum of sample values.
            /// </summary>
            [JsonProperty("sum")]
            public int Sum { get; set; }

            /// <summary>
            /// Total number of samples.
            /// </summary>
            [JsonProperty("count")]
            public int Count { get; set; }

            /// <summary>
            /// Buckets.
            /// </summary>
            [JsonProperty("buckets")]
            public Bucket[] Buckets { get; set; }
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

        public struct StyleSheetId : IAlias<string>
        {
            public string Value { get; private set; }

            public StyleSheetId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Stylesheet type: "injected" for stylesheets injected via extension, "user-agent" for user-agent
        /// stylesheets, "inspector" for stylesheets created by the inspector (i.e. those holding the "via
        /// inspector" rules), "regular" for regular stylesheets.
        /// </summary>
        public struct StyleSheetOrigin : IEnum
        {
            public string Value { get; private set; }

            public StyleSheetOrigin(string value)
            {
                Value = value;
            }

            public static StyleSheetOrigin Injected => new StyleSheetOrigin("injected");
            public static StyleSheetOrigin UserAgent => new StyleSheetOrigin("user-agent");
            public static StyleSheetOrigin Inspector => new StyleSheetOrigin("inspector");
            public static StyleSheetOrigin Regular => new StyleSheetOrigin("regular");
        }

        /// <summary>
        /// CSS rule collection for a single pseudo style.
        /// </summary>
        public class PseudoElementMatches
        {

            /// <summary>
            /// Pseudo element type.
            /// </summary>
            [JsonProperty("pseudoType")]
            public DOM.PseudoType PseudoType { get; set; }

            /// <summary>
            /// Matches of CSS rules applicable to the pseudo style.
            /// </summary>
            [JsonProperty("matches")]
            public RuleMatch[] Matches { get; set; }
        }

        /// <summary>
        /// Inherited CSS rule collection from ancestor node.
        /// </summary>
        public class InheritedStyleEntry
        {

            /// <summary>
            /// The ancestor node's inline style, if any, in the style inheritance chain.
            /// </summary>
            [JsonProperty("inlineStyle")]
            public CSSStyle InlineStyle { get; set; }

            /// <summary>
            /// Matches of CSS rules matching the ancestor node in the style inheritance chain.
            /// </summary>
            [JsonProperty("matchedCSSRules")]
            public RuleMatch[] MatchedCSSRules { get; set; }
        }

        /// <summary>
        /// Match data for a CSS rule.
        /// </summary>
        public class RuleMatch
        {

            /// <summary>
            /// CSS rule in the match.
            /// </summary>
            [JsonProperty("rule")]
            public CSSRule Rule { get; set; }

            /// <summary>
            /// Matching selector indices in the rule's selectorList selectors (0-based).
            /// </summary>
            [JsonProperty("matchingSelectors")]
            public int[] MatchingSelectors { get; set; }
        }

        /// <summary>
        /// Data for a simple selector (these are delimited by commas in a selector list).
        /// </summary>
        public class Value
        {

            /// <summary>
            /// Value text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Value range in the underlying resource (if available).
            /// </summary>
            [JsonProperty("range")]
            public SourceRange Range { get; set; }
        }

        /// <summary>
        /// Selector list data.
        /// </summary>
        public class SelectorList
        {

            /// <summary>
            /// Selectors in the list.
            /// </summary>
            [JsonProperty("selectors")]
            public Value[] Selectors { get; set; }

            /// <summary>
            /// Rule selector text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        /// <summary>
        /// CSS stylesheet metainformation.
        /// </summary>
        public class CSSStyleSheetHeader
        {

            /// <summary>
            /// The stylesheet identifier.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// Owner frame identifier.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// Stylesheet resource URL.
            /// </summary>
            [JsonProperty("sourceURL")]
            public string SourceURL { get; set; }

            /// <summary>
            /// URL of source map associated with the stylesheet (if any).
            /// </summary>
            [JsonProperty("sourceMapURL")]
            public string SourceMapURL { get; set; }

            /// <summary>
            /// Stylesheet origin.
            /// </summary>
            [JsonProperty("origin")]
            public StyleSheetOrigin Origin { get; set; }

            /// <summary>
            /// Stylesheet title.
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// The backend id for the owner node of the stylesheet.
            /// </summary>
            [JsonProperty("ownerNode")]
            public DOM.BackendNodeId OwnerNode { get; set; }

            /// <summary>
            /// Denotes whether the stylesheet is disabled.
            /// </summary>
            [JsonProperty("disabled")]
            public bool Disabled { get; set; }

            /// <summary>
            /// Whether the sourceURL field value comes from the sourceURL comment.
            /// </summary>
            [JsonProperty("hasSourceURL")]
            public bool HasSourceURL { get; set; }

            /// <summary>
            /// Whether this stylesheet is created for STYLE tag by parser. This flag is not set for
            /// document.written STYLE tags.
            /// </summary>
            [JsonProperty("isInline")]
            public bool IsInline { get; set; }

            /// <summary>
            /// Line offset of the stylesheet within the resource (zero based).
            /// </summary>
            [JsonProperty("startLine")]
            public double StartLine { get; set; }

            /// <summary>
            /// Column offset of the stylesheet within the resource (zero based).
            /// </summary>
            [JsonProperty("startColumn")]
            public double StartColumn { get; set; }

            /// <summary>
            /// Size of the content (in characters).
            /// </summary>
            [JsonProperty("length")]
            public double Length { get; set; }
        }

        /// <summary>
        /// CSS rule representation.
        /// </summary>
        public class CSSRule
        {

            /// <summary>
            /// The css style sheet identifier (absent for user agent stylesheet and user-specified
            /// stylesheet rules) this rule came from.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// Rule selector data.
            /// </summary>
            [JsonProperty("selectorList")]
            public SelectorList SelectorList { get; set; }

            /// <summary>
            /// Parent stylesheet's origin.
            /// </summary>
            [JsonProperty("origin")]
            public StyleSheetOrigin Origin { get; set; }

            /// <summary>
            /// Associated style declaration.
            /// </summary>
            [JsonProperty("style")]
            public CSSStyle Style { get; set; }

            /// <summary>
            /// Media list array (for rules involving media queries). The array enumerates media queries
            /// starting with the innermost one, going outwards.
            /// </summary>
            [JsonProperty("media")]
            public CSSMedia[] Media { get; set; }
        }

        /// <summary>
        /// CSS coverage information.
        /// </summary>
        public class RuleUsage
        {

            /// <summary>
            /// The css style sheet identifier (absent for user agent stylesheet and user-specified
            /// stylesheet rules) this rule came from.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// Offset of the start of the rule (including selector) from the beginning of the stylesheet.
            /// </summary>
            [JsonProperty("startOffset")]
            public double StartOffset { get; set; }

            /// <summary>
            /// Offset of the end of the rule body from the beginning of the stylesheet.
            /// </summary>
            [JsonProperty("endOffset")]
            public double EndOffset { get; set; }

            /// <summary>
            /// Indicates whether the rule was actually used by some element in the page.
            /// </summary>
            [JsonProperty("used")]
            public bool Used { get; set; }
        }

        /// <summary>
        /// Text range within a resource. All numbers are zero-based.
        /// </summary>
        public class SourceRange
        {

            /// <summary>
            /// Start line of range.
            /// </summary>
            [JsonProperty("startLine")]
            public int StartLine { get; set; }

            /// <summary>
            /// Start column of range (inclusive).
            /// </summary>
            [JsonProperty("startColumn")]
            public int StartColumn { get; set; }

            /// <summary>
            /// End line of range
            /// </summary>
            [JsonProperty("endLine")]
            public int EndLine { get; set; }

            /// <summary>
            /// End column of range (exclusive).
            /// </summary>
            [JsonProperty("endColumn")]
            public int EndColumn { get; set; }
        }

        public class ShorthandEntry
        {

            /// <summary>
            /// Shorthand name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Shorthand value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// Whether the property has "!important" annotation (implies `false` if absent).
            /// </summary>
            [JsonProperty("important")]
            public bool Important { get; set; }
        }

        public class CSSComputedStyleProperty
        {

            /// <summary>
            /// Computed style property name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Computed style property value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// CSS style representation.
        /// </summary>
        public class CSSStyle
        {

            /// <summary>
            /// The css style sheet identifier (absent for user agent stylesheet and user-specified
            /// stylesheet rules) this rule came from.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// CSS properties in the style.
            /// </summary>
            [JsonProperty("cssProperties")]
            public CSSProperty[] CssProperties { get; set; }

            /// <summary>
            /// Computed values for all shorthands found in the style.
            /// </summary>
            [JsonProperty("shorthandEntries")]
            public ShorthandEntry[] ShorthandEntries { get; set; }

            /// <summary>
            /// Style declaration text (if available).
            /// </summary>
            [JsonProperty("cssText")]
            public string CssText { get; set; }

            /// <summary>
            /// Style declaration range in the enclosing stylesheet (if available).
            /// </summary>
            [JsonProperty("range")]
            public SourceRange Range { get; set; }
        }

        /// <summary>
        /// CSS property declaration data.
        /// </summary>
        public class CSSProperty
        {

            /// <summary>
            /// The property name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// The property value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// Whether the property has "!important" annotation (implies `false` if absent).
            /// </summary>
            [JsonProperty("important")]
            public bool Important { get; set; }

            /// <summary>
            /// Whether the property is implicit (implies `false` if absent).
            /// </summary>
            [JsonProperty("implicit")]
            public bool Implicit { get; set; }

            /// <summary>
            /// The full property text as specified in the style.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Whether the property is understood by the browser (implies `true` if absent).
            /// </summary>
            [JsonProperty("parsedOk")]
            public bool ParsedOk { get; set; }

            /// <summary>
            /// Whether the property is disabled by the user (present for source-based properties only).
            /// </summary>
            [JsonProperty("disabled")]
            public bool Disabled { get; set; }

            /// <summary>
            /// The entire property range in the enclosing style declaration (if available).
            /// </summary>
            [JsonProperty("range")]
            public SourceRange Range { get; set; }
        }

        /// <summary>
        /// CSS media rule descriptor.
        /// </summary>
        public class CSSMedia
        {

            /// <summary>
            /// Media query text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Source of the media query: "mediaRule" if specified by a @media rule, "importRule" if
            /// specified by an @import rule, "linkedSheet" if specified by a "media" attribute in a linked
            /// stylesheet's LINK tag, "inlineSheet" if specified by a "media" attribute in an inline
            /// stylesheet's STYLE tag.
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// URL of the document containing the media query description.
            /// </summary>
            [JsonProperty("sourceURL")]
            public string SourceURL { get; set; }

            /// <summary>
            /// The associated rule (@media or @import) header range in the enclosing stylesheet (if
            /// available).
            /// </summary>
            [JsonProperty("range")]
            public SourceRange Range { get; set; }

            /// <summary>
            /// Identifier of the stylesheet containing this object (if exists).
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// Array of media queries.
            /// </summary>
            [JsonProperty("mediaList")]
            public MediaQuery[] MediaList { get; set; }
        }

        /// <summary>
        /// Media query descriptor.
        /// </summary>
        public class MediaQuery
        {

            /// <summary>
            /// Array of media query expressions.
            /// </summary>
            [JsonProperty("expressions")]
            public MediaQueryExpression[] Expressions { get; set; }

            /// <summary>
            /// Whether the media query condition is satisfied.
            /// </summary>
            [JsonProperty("active")]
            public bool Active { get; set; }
        }

        /// <summary>
        /// Media query expression descriptor.
        /// </summary>
        public class MediaQueryExpression
        {

            /// <summary>
            /// Media query expression value.
            /// </summary>
            [JsonProperty("value")]
            public double Value { get; set; }

            /// <summary>
            /// Media query expression units.
            /// </summary>
            [JsonProperty("unit")]
            public string Unit { get; set; }

            /// <summary>
            /// Media query expression feature.
            /// </summary>
            [JsonProperty("feature")]
            public string Feature { get; set; }

            /// <summary>
            /// The associated range of the value text in the enclosing stylesheet (if available).
            /// </summary>
            [JsonProperty("valueRange")]
            public SourceRange ValueRange { get; set; }

            /// <summary>
            /// Computed length of media query expression (if applicable).
            /// </summary>
            [JsonProperty("computedLength")]
            public double ComputedLength { get; set; }
        }

        /// <summary>
        /// Information about amount of glyphs that were rendered with given font.
        /// </summary>
        public class PlatformFontUsage
        {

            /// <summary>
            /// Font's family name reported by platform.
            /// </summary>
            [JsonProperty("familyName")]
            public string FamilyName { get; set; }

            /// <summary>
            /// Indicates if the font was downloaded or resolved locally.
            /// </summary>
            [JsonProperty("isCustomFont")]
            public bool IsCustomFont { get; set; }

            /// <summary>
            /// Amount of glyphs that were rendered with this font.
            /// </summary>
            [JsonProperty("glyphCount")]
            public double GlyphCount { get; set; }
        }

        /// <summary>
        /// Properties of a web font: https://www.w3.org/TR/2008/REC-CSS2-20080411/fonts.html#font-descriptions
        /// </summary>
        public class FontFace
        {

            /// <summary>
            /// The font-family.
            /// </summary>
            [JsonProperty("fontFamily")]
            public string FontFamily { get; set; }

            /// <summary>
            /// The font-style.
            /// </summary>
            [JsonProperty("fontStyle")]
            public string FontStyle { get; set; }

            /// <summary>
            /// The font-variant.
            /// </summary>
            [JsonProperty("fontVariant")]
            public string FontVariant { get; set; }

            /// <summary>
            /// The font-weight.
            /// </summary>
            [JsonProperty("fontWeight")]
            public string FontWeight { get; set; }

            /// <summary>
            /// The font-stretch.
            /// </summary>
            [JsonProperty("fontStretch")]
            public string FontStretch { get; set; }

            /// <summary>
            /// The unicode-range.
            /// </summary>
            [JsonProperty("unicodeRange")]
            public string UnicodeRange { get; set; }

            /// <summary>
            /// The src.
            /// </summary>
            [JsonProperty("src")]
            public string Src { get; set; }

            /// <summary>
            /// The resolved platform font family
            /// </summary>
            [JsonProperty("platformFontFamily")]
            public string PlatformFontFamily { get; set; }
        }

        /// <summary>
        /// CSS keyframes rule representation.
        /// </summary>
        public class CSSKeyframesRule
        {

            /// <summary>
            /// Animation name.
            /// </summary>
            [JsonProperty("animationName")]
            public Value AnimationName { get; set; }

            /// <summary>
            /// List of keyframes.
            /// </summary>
            [JsonProperty("keyframes")]
            public CSSKeyframeRule[] Keyframes { get; set; }
        }

        /// <summary>
        /// CSS keyframe rule representation.
        /// </summary>
        public class CSSKeyframeRule
        {

            /// <summary>
            /// The css style sheet identifier (absent for user agent stylesheet and user-specified
            /// stylesheet rules) this rule came from.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// Parent stylesheet's origin.
            /// </summary>
            [JsonProperty("origin")]
            public StyleSheetOrigin Origin { get; set; }

            /// <summary>
            /// Associated key text.
            /// </summary>
            [JsonProperty("keyText")]
            public Value KeyText { get; set; }

            /// <summary>
            /// Associated style declaration.
            /// </summary>
            [JsonProperty("style")]
            public CSSStyle Style { get; set; }
        }

        /// <summary>
        /// A descriptor of operation to mutate style declaration text.
        /// </summary>
        public class StyleDeclarationEdit
        {

            /// <summary>
            /// The css style sheet identifier.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// The range of the style text in the enclosing stylesheet.
            /// </summary>
            [JsonProperty("range")]
            public SourceRange Range { get; set; }

            /// <summary>
            /// New style text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
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
        public struct CacheId : IAlias<string>
        {
            public string Value { get; private set; }

            public CacheId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// type of HTTP response cached
        /// </summary>
        public struct CachedResponseType : IEnum
        {
            public string Value { get; private set; }

            public CachedResponseType(string value)
            {
                Value = value;
            }

            public static CachedResponseType Basic => new CachedResponseType("basic");
            public static CachedResponseType Cors => new CachedResponseType("cors");
            public static CachedResponseType Default => new CachedResponseType("default");
            public static CachedResponseType Error => new CachedResponseType("error");
            public static CachedResponseType OpaqueResponse => new CachedResponseType("opaqueResponse");
            public static CachedResponseType OpaqueRedirect => new CachedResponseType("opaqueRedirect");
        }

        /// <summary>
        /// Data entry.
        /// </summary>
        public class DataEntry
        {

            /// <summary>
            /// Request URL.
            /// </summary>
            [JsonProperty("requestURL")]
            public string RequestURL { get; set; }

            /// <summary>
            /// Request method.
            /// </summary>
            [JsonProperty("requestMethod")]
            public string RequestMethod { get; set; }

            /// <summary>
            /// Request headers
            /// </summary>
            [JsonProperty("requestHeaders")]
            public Header[] RequestHeaders { get; set; }

            /// <summary>
            /// Number of seconds since epoch.
            /// </summary>
            [JsonProperty("responseTime")]
            public double ResponseTime { get; set; }

            /// <summary>
            /// HTTP response status code.
            /// </summary>
            [JsonProperty("responseStatus")]
            public int ResponseStatus { get; set; }

            /// <summary>
            /// HTTP response status text.
            /// </summary>
            [JsonProperty("responseStatusText")]
            public string ResponseStatusText { get; set; }

            /// <summary>
            /// HTTP response type
            /// </summary>
            [JsonProperty("responseType")]
            public CachedResponseType ResponseType { get; set; }

            /// <summary>
            /// Response headers
            /// </summary>
            [JsonProperty("responseHeaders")]
            public Header[] ResponseHeaders { get; set; }
        }

        /// <summary>
        /// Cache identifier.
        /// </summary>
        public class Cache
        {

            /// <summary>
            /// An opaque unique id of the cache.
            /// </summary>
            [JsonProperty("cacheId")]
            public CacheId CacheId { get; set; }

            /// <summary>
            /// Security origin of the cache.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// The name of the cache.
            /// </summary>
            [JsonProperty("cacheName")]
            public string CacheName { get; set; }
        }

        public class Header
        {

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Cached response
        /// </summary>
        public class CachedResponse
        {

            /// <summary>
            /// Entry content, base64-encoded.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }
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
        public struct NodeId : IAlias<int>
        {
            public int Value { get; private set; }

            public NodeId(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique DOM node identifier used to reference a node that may not have been pushed to the
        /// front-end.
        /// </summary>
        public struct BackendNodeId : IAlias<int>
        {
            public int Value { get; private set; }

            public BackendNodeId(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Backend node with a friendly name.
        /// </summary>
        public class BackendNode
        {

            /// <summary>
            /// `Node`'s nodeType.
            /// </summary>
            [JsonProperty("nodeType")]
            public int NodeType { get; set; }

            /// <summary>
            /// `Node`'s nodeName.
            /// </summary>
            [JsonProperty("nodeName")]
            public string NodeName { get; set; }

            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }
        }

        /// <summary>
        /// Pseudo element type.
        /// </summary>
        public struct PseudoType : IEnum
        {
            public string Value { get; private set; }

            public PseudoType(string value)
            {
                Value = value;
            }

            public static PseudoType FirstLine => new PseudoType("first-line");
            public static PseudoType FirstLetter => new PseudoType("first-letter");
            public static PseudoType Before => new PseudoType("before");
            public static PseudoType After => new PseudoType("after");
            public static PseudoType Backdrop => new PseudoType("backdrop");
            public static PseudoType Selection => new PseudoType("selection");
            public static PseudoType FirstLineInherited => new PseudoType("first-line-inherited");
            public static PseudoType Scrollbar => new PseudoType("scrollbar");
            public static PseudoType ScrollbarThumb => new PseudoType("scrollbar-thumb");
            public static PseudoType ScrollbarButton => new PseudoType("scrollbar-button");
            public static PseudoType ScrollbarTrack => new PseudoType("scrollbar-track");
            public static PseudoType ScrollbarTrackPiece => new PseudoType("scrollbar-track-piece");
            public static PseudoType ScrollbarCorner => new PseudoType("scrollbar-corner");
            public static PseudoType Resizer => new PseudoType("resizer");
            public static PseudoType InputListButton => new PseudoType("input-list-button");
        }

        /// <summary>
        /// Shadow root type.
        /// </summary>
        public struct ShadowRootType : IEnum
        {
            public string Value { get; private set; }

            public ShadowRootType(string value)
            {
                Value = value;
            }

            public static ShadowRootType UserAgent => new ShadowRootType("user-agent");
            public static ShadowRootType Open => new ShadowRootType("open");
            public static ShadowRootType Closed => new ShadowRootType("closed");
        }

        /// <summary>
        /// DOM interaction is implemented in terms of mirror objects that represent the actual DOM nodes.
        /// DOMNode is a base node mirror type.
        /// </summary>
        public class Node
        {

            /// <summary>
            /// Node identifier that is passed into the rest of the DOM messages as the `nodeId`. Backend
            /// will only push node with given `id` once. It is aware of all requested nodes and will only
            /// fire DOM events for nodes known to the client.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// The id of the parent node if any.
            /// </summary>
            [JsonProperty("parentId")]
            public NodeId ParentId { get; set; }

            /// <summary>
            /// The BackendNodeId for this node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// `Node`'s nodeType.
            /// </summary>
            [JsonProperty("nodeType")]
            public int NodeType { get; set; }

            /// <summary>
            /// `Node`'s nodeName.
            /// </summary>
            [JsonProperty("nodeName")]
            public string NodeName { get; set; }

            /// <summary>
            /// `Node`'s localName.
            /// </summary>
            [JsonProperty("localName")]
            public string LocalName { get; set; }

            /// <summary>
            /// `Node`'s nodeValue.
            /// </summary>
            [JsonProperty("nodeValue")]
            public string NodeValue { get; set; }

            /// <summary>
            /// Child count for `Container` nodes.
            /// </summary>
            [JsonProperty("childNodeCount")]
            public int ChildNodeCount { get; set; }

            /// <summary>
            /// Child nodes of this node when requested with children.
            /// </summary>
            [JsonProperty("children")]
            public Node[] Children { get; set; }

            /// <summary>
            /// Attributes of the `Element` node in the form of flat array `[name1, value1, name2, value2]`.
            /// </summary>
            [JsonProperty("attributes")]
            public string[] Attributes { get; set; }

            /// <summary>
            /// Document URL that `Document` or `FrameOwner` node points to.
            /// </summary>
            [JsonProperty("documentURL")]
            public string DocumentURL { get; set; }

            /// <summary>
            /// Base URL that `Document` or `FrameOwner` node uses for URL completion.
            /// </summary>
            [JsonProperty("baseURL")]
            public string BaseURL { get; set; }

            /// <summary>
            /// `DocumentType`'s publicId.
            /// </summary>
            [JsonProperty("publicId")]
            public string PublicId { get; set; }

            /// <summary>
            /// `DocumentType`'s systemId.
            /// </summary>
            [JsonProperty("systemId")]
            public string SystemId { get; set; }

            /// <summary>
            /// `DocumentType`'s internalSubset.
            /// </summary>
            [JsonProperty("internalSubset")]
            public string InternalSubset { get; set; }

            /// <summary>
            /// `Document`'s XML version in case of XML documents.
            /// </summary>
            [JsonProperty("xmlVersion")]
            public string XmlVersion { get; set; }

            /// <summary>
            /// `Attr`'s name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// `Attr`'s value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// Pseudo element type for this node.
            /// </summary>
            [JsonProperty("pseudoType")]
            public PseudoType PseudoType { get; set; }

            /// <summary>
            /// Shadow root type.
            /// </summary>
            [JsonProperty("shadowRootType")]
            public ShadowRootType ShadowRootType { get; set; }

            /// <summary>
            /// Frame ID for frame owner elements.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// Content document for frame owner elements.
            /// </summary>
            [JsonProperty("contentDocument")]
            public Node ContentDocument { get; set; }

            /// <summary>
            /// Shadow root list for given element host.
            /// </summary>
            [JsonProperty("shadowRoots")]
            public Node[] ShadowRoots { get; set; }

            /// <summary>
            /// Content document fragment for template elements.
            /// </summary>
            [JsonProperty("templateContent")]
            public Node TemplateContent { get; set; }

            /// <summary>
            /// Pseudo elements associated with this node.
            /// </summary>
            [JsonProperty("pseudoElements")]
            public Node[] PseudoElements { get; set; }

            /// <summary>
            /// Import document for the HTMLImport links.
            /// </summary>
            [JsonProperty("importedDocument")]
            public Node ImportedDocument { get; set; }

            /// <summary>
            /// Distributed nodes for given insertion point.
            /// </summary>
            [JsonProperty("distributedNodes")]
            public BackendNode[] DistributedNodes { get; set; }

            /// <summary>
            /// Whether the node is SVG.
            /// </summary>
            [JsonProperty("isSVG")]
            public bool IsSVG { get; set; }
        }

        /// <summary>
        /// A structure holding an RGBA color.
        /// </summary>
        public class RGBA
        {

            /// <summary>
            /// The red component, in the [0-255] range.
            /// </summary>
            [JsonProperty("r")]
            public int R { get; set; }

            /// <summary>
            /// The green component, in the [0-255] range.
            /// </summary>
            [JsonProperty("g")]
            public int G { get; set; }

            /// <summary>
            /// The blue component, in the [0-255] range.
            /// </summary>
            [JsonProperty("b")]
            public int B { get; set; }

            /// <summary>
            /// The alpha component, in the [0-1] range (default: 1).
            /// </summary>
            [JsonProperty("a")]
            public double A { get; set; }
        }

        /// <summary>
        /// An array of quad vertices, x immediately followed by y for each point, points clock-wise.
        /// </summary>
        public struct Quad : IAlias<double[]>
        {
            public double[] Value { get; private set; }

            public Quad(double[] value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Box model.
        /// </summary>
        public class BoxModel
        {

            /// <summary>
            /// Content box
            /// </summary>
            [JsonProperty("content")]
            public Quad Content { get; set; }

            /// <summary>
            /// Padding box
            /// </summary>
            [JsonProperty("padding")]
            public Quad Padding { get; set; }

            /// <summary>
            /// Border box
            /// </summary>
            [JsonProperty("border")]
            public Quad Border { get; set; }

            /// <summary>
            /// Margin box
            /// </summary>
            [JsonProperty("margin")]
            public Quad Margin { get; set; }

            /// <summary>
            /// Node width
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Node height
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// Shape outside coordinates
            /// </summary>
            [JsonProperty("shapeOutside")]
            public ShapeOutsideInfo ShapeOutside { get; set; }
        }

        /// <summary>
        /// CSS Shape Outside details.
        /// </summary>
        public class ShapeOutsideInfo
        {

            /// <summary>
            /// Shape bounds
            /// </summary>
            [JsonProperty("bounds")]
            public Quad Bounds { get; set; }

            /// <summary>
            /// Shape coordinate details
            /// </summary>
            [JsonProperty("shape")]
            public object[] Shape { get; set; }

            /// <summary>
            /// Margin shape bounds
            /// </summary>
            [JsonProperty("marginShape")]
            public object[] MarginShape { get; set; }
        }

        /// <summary>
        /// Rectangle.
        /// </summary>
        public class Rect
        {

            /// <summary>
            /// X coordinate
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y coordinate
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// Rectangle width
            /// </summary>
            [JsonProperty("width")]
            public double Width { get; set; }

            /// <summary>
            /// Rectangle height
            /// </summary>
            [JsonProperty("height")]
            public double Height { get; set; }
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
        public struct DOMBreakpointType : IEnum
        {
            public string Value { get; private set; }

            public DOMBreakpointType(string value)
            {
                Value = value;
            }

            public static DOMBreakpointType SubtreeModified => new DOMBreakpointType("subtree-modified");
            public static DOMBreakpointType AttributeModified => new DOMBreakpointType("attribute-modified");
            public static DOMBreakpointType NodeRemoved => new DOMBreakpointType("node-removed");
        }

        /// <summary>
        /// Object event listener.
        /// </summary>
        public class EventListener
        {

            /// <summary>
            /// `EventListener`'s type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// `EventListener`'s useCapture.
            /// </summary>
            [JsonProperty("useCapture")]
            public bool UseCapture { get; set; }

            /// <summary>
            /// `EventListener`'s passive flag.
            /// </summary>
            [JsonProperty("passive")]
            public bool Passive { get; set; }

            /// <summary>
            /// `EventListener`'s once flag.
            /// </summary>
            [JsonProperty("once")]
            public bool Once { get; set; }

            /// <summary>
            /// Script id of the handler code.
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

            /// <summary>
            /// Event handler function value.
            /// </summary>
            [JsonProperty("handler")]
            public Runtime.RemoteObject Handler { get; set; }

            /// <summary>
            /// Event original handler function value.
            /// </summary>
            [JsonProperty("originalHandler")]
            public Runtime.RemoteObject OriginalHandler { get; set; }

            /// <summary>
            /// Node the listener is added to (if any).
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }
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

            /// <summary>
            /// `Node`'s nodeType.
            /// </summary>
            [JsonProperty("nodeType")]
            public int NodeType { get; set; }

            /// <summary>
            /// `Node`'s nodeName.
            /// </summary>
            [JsonProperty("nodeName")]
            public string NodeName { get; set; }

            /// <summary>
            /// `Node`'s nodeValue.
            /// </summary>
            [JsonProperty("nodeValue")]
            public string NodeValue { get; set; }

            /// <summary>
            /// Only set for textarea elements, contains the text value.
            /// </summary>
            [JsonProperty("textValue")]
            public string TextValue { get; set; }

            /// <summary>
            /// Only set for input elements, contains the input's associated text value.
            /// </summary>
            [JsonProperty("inputValue")]
            public string InputValue { get; set; }

            /// <summary>
            /// Only set for radio and checkbox input elements, indicates if the element has been checked
            /// </summary>
            [JsonProperty("inputChecked")]
            public bool InputChecked { get; set; }

            /// <summary>
            /// Only set for option elements, indicates if the element has been selected
            /// </summary>
            [JsonProperty("optionSelected")]
            public bool OptionSelected { get; set; }

            /// <summary>
            /// `Node`'s id, corresponds to DOM.Node.backendNodeId.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// The indexes of the node's child nodes in the `domNodes` array returned by `getSnapshot`, if
            /// any.
            /// </summary>
            [JsonProperty("childNodeIndexes")]
            public int[] ChildNodeIndexes { get; set; }

            /// <summary>
            /// Attributes of an `Element` node.
            /// </summary>
            [JsonProperty("attributes")]
            public NameValue[] Attributes { get; set; }

            /// <summary>
            /// Indexes of pseudo elements associated with this node in the `domNodes` array returned by
            /// `getSnapshot`, if any.
            /// </summary>
            [JsonProperty("pseudoElementIndexes")]
            public int[] PseudoElementIndexes { get; set; }

            /// <summary>
            /// The index of the node's related layout tree node in the `layoutTreeNodes` array returned by
            /// `getSnapshot`, if any.
            /// </summary>
            [JsonProperty("layoutNodeIndex")]
            public int LayoutNodeIndex { get; set; }

            /// <summary>
            /// Document URL that `Document` or `FrameOwner` node points to.
            /// </summary>
            [JsonProperty("documentURL")]
            public string DocumentURL { get; set; }

            /// <summary>
            /// Base URL that `Document` or `FrameOwner` node uses for URL completion.
            /// </summary>
            [JsonProperty("baseURL")]
            public string BaseURL { get; set; }

            /// <summary>
            /// Only set for documents, contains the document's content language.
            /// </summary>
            [JsonProperty("contentLanguage")]
            public string ContentLanguage { get; set; }

            /// <summary>
            /// Only set for documents, contains the document's character set encoding.
            /// </summary>
            [JsonProperty("documentEncoding")]
            public string DocumentEncoding { get; set; }

            /// <summary>
            /// `DocumentType` node's publicId.
            /// </summary>
            [JsonProperty("publicId")]
            public string PublicId { get; set; }

            /// <summary>
            /// `DocumentType` node's systemId.
            /// </summary>
            [JsonProperty("systemId")]
            public string SystemId { get; set; }

            /// <summary>
            /// Frame ID for frame owner elements and also for the document node.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// The index of a frame owner element's content document in the `domNodes` array returned by
            /// `getSnapshot`, if any.
            /// </summary>
            [JsonProperty("contentDocumentIndex")]
            public int ContentDocumentIndex { get; set; }

            /// <summary>
            /// Type of a pseudo element node.
            /// </summary>
            [JsonProperty("pseudoType")]
            public DOM.PseudoType PseudoType { get; set; }

            /// <summary>
            /// Shadow root type.
            /// </summary>
            [JsonProperty("shadowRootType")]
            public DOM.ShadowRootType ShadowRootType { get; set; }

            /// <summary>
            /// Whether this DOM node responds to mouse clicks. This includes nodes that have had click
            /// event listeners attached via JavaScript as well as anchor tags that naturally navigate when
            /// clicked.
            /// </summary>
            [JsonProperty("isClickable")]
            public bool IsClickable { get; set; }

            /// <summary>
            /// Details of the node's event listeners, if any.
            /// </summary>
            [JsonProperty("eventListeners")]
            public DOMDebugger.EventListener[] EventListeners { get; set; }

            /// <summary>
            /// The selected url for nodes with a srcset attribute.
            /// </summary>
            [JsonProperty("currentSourceURL")]
            public string CurrentSourceURL { get; set; }

            /// <summary>
            /// The url of the script (if any) that generates this node.
            /// </summary>
            [JsonProperty("originURL")]
            public string OriginURL { get; set; }

            /// <summary>
            /// Scroll offsets, set when this node is a Document.
            /// </summary>
            [JsonProperty("scrollOffsetX")]
            public double ScrollOffsetX { get; set; }

            [JsonProperty("scrollOffsetY")]
            public double ScrollOffsetY { get; set; }
        }

        /// <summary>
        /// Details of post layout rendered text positions. The exact layout should not be regarded as
        /// stable and may change between versions.
        /// </summary>
        public class InlineTextBox
        {

            /// <summary>
            /// The bounding box in document coordinates. Note that scroll offset of the document is ignored.
            /// </summary>
            [JsonProperty("boundingBox")]
            public DOM.Rect BoundingBox { get; set; }

            /// <summary>
            /// The starting index in characters, for this post layout textbox substring. Characters that
            /// would be represented as a surrogate pair in UTF-16 have length 2.
            /// </summary>
            [JsonProperty("startCharacterIndex")]
            public int StartCharacterIndex { get; set; }

            /// <summary>
            /// The number of characters in this post layout textbox substring. Characters that would be
            /// represented as a surrogate pair in UTF-16 have length 2.
            /// </summary>
            [JsonProperty("numCharacters")]
            public int NumCharacters { get; set; }
        }

        /// <summary>
        /// Details of an element in the DOM tree with a LayoutObject.
        /// </summary>
        public class LayoutTreeNode
        {

            /// <summary>
            /// The index of the related DOM node in the `domNodes` array returned by `getSnapshot`.
            /// </summary>
            [JsonProperty("domNodeIndex")]
            public int DomNodeIndex { get; set; }

            /// <summary>
            /// The bounding box in document coordinates. Note that scroll offset of the document is ignored.
            /// </summary>
            [JsonProperty("boundingBox")]
            public DOM.Rect BoundingBox { get; set; }

            /// <summary>
            /// Contents of the LayoutText, if any.
            /// </summary>
            [JsonProperty("layoutText")]
            public string LayoutText { get; set; }

            /// <summary>
            /// The post-layout inline text nodes, if any.
            /// </summary>
            [JsonProperty("inlineTextNodes")]
            public InlineTextBox[] InlineTextNodes { get; set; }

            /// <summary>
            /// Index into the `computedStyles` array returned by `getSnapshot`.
            /// </summary>
            [JsonProperty("styleIndex")]
            public int StyleIndex { get; set; }

            /// <summary>
            /// Global paint order index, which is determined by the stacking order of the nodes. Nodes
            /// that are painted together will have the same index. Only provided if includePaintOrder in
            /// getSnapshot was true.
            /// </summary>
            [JsonProperty("paintOrder")]
            public int PaintOrder { get; set; }

            /// <summary>
            /// Set to true to indicate the element begins a new stacking context.
            /// </summary>
            [JsonProperty("isStackingContext")]
            public bool IsStackingContext { get; set; }
        }

        /// <summary>
        /// A subset of the full ComputedStyle as defined by the request whitelist.
        /// </summary>
        public class ComputedStyle
        {

            /// <summary>
            /// Name/value pairs of computed style properties.
            /// </summary>
            [JsonProperty("properties")]
            public NameValue[] Properties { get; set; }
        }

        /// <summary>
        /// A name/value pair.
        /// </summary>
        public class NameValue
        {

            /// <summary>
            /// Attribute/property name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Attribute/property value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Index of the string in the strings table.
        /// </summary>
        public struct StringIndex : IAlias<int>
        {
            public int Value { get; private set; }

            public StringIndex(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Index of the string in the strings table.
        /// </summary>
        public struct ArrayOfStrings : IAlias<StringIndex[]>
        {
            public StringIndex[] Value { get; private set; }

            public ArrayOfStrings(StringIndex[] value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Data that is only present on rare nodes.
        /// </summary>
        public class RareStringData
        {

            [JsonProperty("index")]
            public int[] Index { get; set; }

            [JsonProperty("value")]
            public StringIndex[] Value { get; set; }
        }

        public class RareBooleanData
        {

            [JsonProperty("index")]
            public int[] Index { get; set; }
        }

        public class RareIntegerData
        {

            [JsonProperty("index")]
            public int[] Index { get; set; }

            [JsonProperty("value")]
            public int[] Value { get; set; }
        }

        public struct Rectangle : IAlias<double[]>
        {
            public double[] Value { get; private set; }

            public Rectangle(double[] value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Document snapshot.
        /// </summary>
        public class DocumentSnapshot
        {

            /// <summary>
            /// Document URL that `Document` or `FrameOwner` node points to.
            /// </summary>
            [JsonProperty("documentURL")]
            public StringIndex DocumentURL { get; set; }

            /// <summary>
            /// Base URL that `Document` or `FrameOwner` node uses for URL completion.
            /// </summary>
            [JsonProperty("baseURL")]
            public StringIndex BaseURL { get; set; }

            /// <summary>
            /// Contains the document's content language.
            /// </summary>
            [JsonProperty("contentLanguage")]
            public StringIndex ContentLanguage { get; set; }

            /// <summary>
            /// Contains the document's character set encoding.
            /// </summary>
            [JsonProperty("encodingName")]
            public StringIndex EncodingName { get; set; }

            /// <summary>
            /// `DocumentType` node's publicId.
            /// </summary>
            [JsonProperty("publicId")]
            public StringIndex PublicId { get; set; }

            /// <summary>
            /// `DocumentType` node's systemId.
            /// </summary>
            [JsonProperty("systemId")]
            public StringIndex SystemId { get; set; }

            /// <summary>
            /// Frame ID for frame owner elements and also for the document node.
            /// </summary>
            [JsonProperty("frameId")]
            public StringIndex FrameId { get; set; }

            /// <summary>
            /// A table with dom nodes.
            /// </summary>
            [JsonProperty("nodes")]
            public NodeTreeSnapshot Nodes { get; set; }

            /// <summary>
            /// The nodes in the layout tree.
            /// </summary>
            [JsonProperty("layout")]
            public LayoutTreeSnapshot Layout { get; set; }

            /// <summary>
            /// The post-layout inline text nodes.
            /// </summary>
            [JsonProperty("textBoxes")]
            public TextBoxSnapshot TextBoxes { get; set; }

            /// <summary>
            /// Scroll offsets.
            /// </summary>
            [JsonProperty("scrollOffsetX")]
            public double ScrollOffsetX { get; set; }

            [JsonProperty("scrollOffsetY")]
            public double ScrollOffsetY { get; set; }
        }

        /// <summary>
        /// Table containing nodes.
        /// </summary>
        public class NodeTreeSnapshot
        {

            /// <summary>
            /// Parent node index.
            /// </summary>
            [JsonProperty("parentIndex")]
            public int[] ParentIndex { get; set; }

            /// <summary>
            /// `Node`'s nodeType.
            /// </summary>
            [JsonProperty("nodeType")]
            public int[] NodeType { get; set; }

            /// <summary>
            /// `Node`'s nodeName.
            /// </summary>
            [JsonProperty("nodeName")]
            public StringIndex[] NodeName { get; set; }

            /// <summary>
            /// `Node`'s nodeValue.
            /// </summary>
            [JsonProperty("nodeValue")]
            public StringIndex[] NodeValue { get; set; }

            /// <summary>
            /// `Node`'s id, corresponds to DOM.Node.backendNodeId.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId[] BackendNodeId { get; set; }

            /// <summary>
            /// Attributes of an `Element` node. Flatten name, value pairs.
            /// </summary>
            [JsonProperty("attributes")]
            public ArrayOfStrings[] Attributes { get; set; }

            /// <summary>
            /// Only set for textarea elements, contains the text value.
            /// </summary>
            [JsonProperty("textValue")]
            public RareStringData TextValue { get; set; }

            /// <summary>
            /// Only set for input elements, contains the input's associated text value.
            /// </summary>
            [JsonProperty("inputValue")]
            public RareStringData InputValue { get; set; }

            /// <summary>
            /// Only set for radio and checkbox input elements, indicates if the element has been checked
            /// </summary>
            [JsonProperty("inputChecked")]
            public RareBooleanData InputChecked { get; set; }

            /// <summary>
            /// Only set for option elements, indicates if the element has been selected
            /// </summary>
            [JsonProperty("optionSelected")]
            public RareBooleanData OptionSelected { get; set; }

            /// <summary>
            /// The index of the document in the list of the snapshot documents.
            /// </summary>
            [JsonProperty("contentDocumentIndex")]
            public RareIntegerData ContentDocumentIndex { get; set; }

            /// <summary>
            /// Type of a pseudo element node.
            /// </summary>
            [JsonProperty("pseudoType")]
            public RareStringData PseudoType { get; set; }

            /// <summary>
            /// Whether this DOM node responds to mouse clicks. This includes nodes that have had click
            /// event listeners attached via JavaScript as well as anchor tags that naturally navigate when
            /// clicked.
            /// </summary>
            [JsonProperty("isClickable")]
            public RareBooleanData IsClickable { get; set; }

            /// <summary>
            /// The selected url for nodes with a srcset attribute.
            /// </summary>
            [JsonProperty("currentSourceURL")]
            public RareStringData CurrentSourceURL { get; set; }

            /// <summary>
            /// The url of the script (if any) that generates this node.
            /// </summary>
            [JsonProperty("originURL")]
            public RareStringData OriginURL { get; set; }
        }

        /// <summary>
        /// Details of an element in the DOM tree with a LayoutObject.
        /// </summary>
        public class LayoutTreeSnapshot
        {

            /// <summary>
            /// The index of the related DOM node in the `domNodes` array returned by `getSnapshot`.
            /// </summary>
            [JsonProperty("nodeIndex")]
            public int[] NodeIndex { get; set; }

            /// <summary>
            /// Index into the `computedStyles` array returned by `captureSnapshot`.
            /// </summary>
            [JsonProperty("styles")]
            public ArrayOfStrings[] Styles { get; set; }

            /// <summary>
            /// The absolute position bounding box.
            /// </summary>
            [JsonProperty("bounds")]
            public Rectangle[] Bounds { get; set; }

            /// <summary>
            /// Contents of the LayoutText, if any.
            /// </summary>
            [JsonProperty("text")]
            public StringIndex[] Text { get; set; }

            /// <summary>
            /// Stacking context information.
            /// </summary>
            [JsonProperty("stackingContexts")]
            public RareBooleanData StackingContexts { get; set; }
        }

        /// <summary>
        /// Details of post layout rendered text positions. The exact layout should not be regarded as
        /// stable and may change between versions.
        /// </summary>
        public class TextBoxSnapshot
        {

            /// <summary>
            /// Intex of th elayout tree node that owns this box collection.
            /// </summary>
            [JsonProperty("layoutIndex")]
            public int[] LayoutIndex { get; set; }

            /// <summary>
            /// The absolute position bounding box.
            /// </summary>
            [JsonProperty("bounds")]
            public Rectangle[] Bounds { get; set; }

            /// <summary>
            /// The starting index in characters, for this post layout textbox substring. Characters that
            /// would be represented as a surrogate pair in UTF-16 have length 2.
            /// </summary>
            [JsonProperty("start")]
            public int[] Start { get; set; }

            /// <summary>
            /// The number of characters in this post layout textbox substring. Characters that would be
            /// represented as a surrogate pair in UTF-16 have length 2.
            /// </summary>
            [JsonProperty("length")]
            public int[] Length { get; set; }
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

            /// <summary>
            /// Security origin for the storage.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Whether the storage is local storage (not session storage).
            /// </summary>
            [JsonProperty("isLocalStorage")]
            public bool IsLocalStorage { get; set; }
        }

        /// <summary>
        /// DOM Storage item.
        /// </summary>
        public struct Item : IAlias<string[]>
        {
            public string[] Value { get; private set; }

            public Item(string[] value)
            {
                Value = value;
            }

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
        public struct DatabaseId : IAlias<string>
        {
            public string Value { get; private set; }

            public DatabaseId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Database object.
        /// </summary>
        public class Database
        {

            /// <summary>
            /// Database ID.
            /// </summary>
            [JsonProperty("id")]
            public DatabaseId Id { get; set; }

            /// <summary>
            /// Database domain.
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Database version.
            /// </summary>
            [JsonProperty("version")]
            public string Version { get; set; }
        }

        /// <summary>
        /// Database error.
        /// </summary>
        public class Error
        {

            /// <summary>
            /// Error message.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Error code.
            /// </summary>
            [JsonProperty("code")]
            public int Code { get; set; }
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

            /// <summary>
            /// Orientation type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Orientation angle.
            /// </summary>
            [JsonProperty("angle")]
            public int Angle { get; set; }
        }

        /// <summary>
        /// advance: If the scheduler runs out of immediate work, the virtual time base may fast forward to
        /// allow the next delayed task (if any) to run; pause: The virtual time base may not advance;
        /// pauseIfNetworkFetchesPending: The virtual time base may not advance if there are any pending
        /// resource fetches.
        /// </summary>
        public struct VirtualTimePolicy : IEnum
        {
            public string Value { get; private set; }

            public VirtualTimePolicy(string value)
            {
                Value = value;
            }

            public static VirtualTimePolicy Advance => new VirtualTimePolicy("advance");
            public static VirtualTimePolicy Pause => new VirtualTimePolicy("pause");
            public static VirtualTimePolicy PauseIfNetworkFetchesPending => new VirtualTimePolicy("pauseIfNetworkFetchesPending");
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

            /// <summary>
            /// Image compression format (defaults to png).
            /// </summary>
            [JsonProperty("format")]
            public string Format { get; set; }

            /// <summary>
            /// Compression quality from range [0..100] (jpeg only).
            /// </summary>
            [JsonProperty("quality")]
            public int Quality { get; set; }
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
        public struct StreamHandle : IAlias<string>
        {
            public string Value { get; private set; }

            public StreamHandle(string value)
            {
                Value = value;
            }

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

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Database version (type is not 'integer', as the standard
            /// requires the version number to be 'unsigned long long')
            /// </summary>
            [JsonProperty("version")]
            public double Version { get; set; }

            /// <summary>
            /// Object stores in this database.
            /// </summary>
            [JsonProperty("objectStores")]
            public ObjectStore[] ObjectStores { get; set; }
        }

        /// <summary>
        /// Object store.
        /// </summary>
        public class ObjectStore
        {

            /// <summary>
            /// Object store name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Object store key path.
            /// </summary>
            [JsonProperty("keyPath")]
            public KeyPath KeyPath { get; set; }

            /// <summary>
            /// If true, object store has auto increment flag set.
            /// </summary>
            [JsonProperty("autoIncrement")]
            public bool AutoIncrement { get; set; }

            /// <summary>
            /// Indexes in this object store.
            /// </summary>
            [JsonProperty("indexes")]
            public ObjectStoreIndex[] Indexes { get; set; }
        }

        /// <summary>
        /// Object store index.
        /// </summary>
        public class ObjectStoreIndex
        {

            /// <summary>
            /// Index name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Index key path.
            /// </summary>
            [JsonProperty("keyPath")]
            public KeyPath KeyPath { get; set; }

            /// <summary>
            /// If true, index is unique.
            /// </summary>
            [JsonProperty("unique")]
            public bool Unique { get; set; }

            /// <summary>
            /// If true, index allows multiple entries for a key.
            /// </summary>
            [JsonProperty("multiEntry")]
            public bool MultiEntry { get; set; }
        }

        /// <summary>
        /// Key.
        /// </summary>
        public class Key
        {

            /// <summary>
            /// Key type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Number value.
            /// </summary>
            [JsonProperty("number")]
            public double Number { get; set; }

            /// <summary>
            /// String value.
            /// </summary>
            [JsonProperty("string")]
            public string String { get; set; }

            /// <summary>
            /// Date value.
            /// </summary>
            [JsonProperty("date")]
            public double Date { get; set; }

            /// <summary>
            /// Array value.
            /// </summary>
            [JsonProperty("array")]
            public Key[] Array { get; set; }
        }

        /// <summary>
        /// Key range.
        /// </summary>
        public class KeyRange
        {

            /// <summary>
            /// Lower bound.
            /// </summary>
            [JsonProperty("lower")]
            public Key Lower { get; set; }

            /// <summary>
            /// Upper bound.
            /// </summary>
            [JsonProperty("upper")]
            public Key Upper { get; set; }

            /// <summary>
            /// If true lower bound is open.
            /// </summary>
            [JsonProperty("lowerOpen")]
            public bool LowerOpen { get; set; }

            /// <summary>
            /// If true upper bound is open.
            /// </summary>
            [JsonProperty("upperOpen")]
            public bool UpperOpen { get; set; }
        }

        /// <summary>
        /// Data entry.
        /// </summary>
        public class DataEntry
        {

            /// <summary>
            /// Key object.
            /// </summary>
            [JsonProperty("key")]
            public Runtime.RemoteObject Key { get; set; }

            /// <summary>
            /// Primary key object.
            /// </summary>
            [JsonProperty("primaryKey")]
            public Runtime.RemoteObject PrimaryKey { get; set; }

            /// <summary>
            /// Value object.
            /// </summary>
            [JsonProperty("value")]
            public Runtime.RemoteObject Value { get; set; }
        }

        /// <summary>
        /// Key path.
        /// </summary>
        public class KeyPath
        {

            /// <summary>
            /// Key path type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// String value.
            /// </summary>
            [JsonProperty("string")]
            public string String { get; set; }

            /// <summary>
            /// Array value.
            /// </summary>
            [JsonProperty("array")]
            public string[] Array { get; set; }
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

            /// <summary>
            /// X coordinate of the event relative to the main frame's viewport in CSS pixels.
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y coordinate of the event relative to the main frame's viewport in CSS pixels. 0 refers to
            /// the top of the viewport and Y increases as it proceeds towards the bottom of the viewport.
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// X radius of the touch area (default: 1.0).
            /// </summary>
            [JsonProperty("radiusX")]
            public double RadiusX { get; set; }

            /// <summary>
            /// Y radius of the touch area (default: 1.0).
            /// </summary>
            [JsonProperty("radiusY")]
            public double RadiusY { get; set; }

            /// <summary>
            /// Rotation angle (default: 0.0).
            /// </summary>
            [JsonProperty("rotationAngle")]
            public double RotationAngle { get; set; }

            /// <summary>
            /// Force (default: 1.0).
            /// </summary>
            [JsonProperty("force")]
            public double Force { get; set; }

            /// <summary>
            /// Identifier used to track touch sources between events, must be unique within an event.
            /// </summary>
            [JsonProperty("id")]
            public double Id { get; set; }
        }

        public struct GestureSourceType : IEnum
        {
            public string Value { get; private set; }

            public GestureSourceType(string value)
            {
                Value = value;
            }

            public static GestureSourceType Default => new GestureSourceType("default");
            public static GestureSourceType Touch => new GestureSourceType("touch");
            public static GestureSourceType Mouse => new GestureSourceType("mouse");
        }

        /// <summary>
        /// UTC time in seconds, counted from January 1, 1970.
        /// </summary>
        public struct TimeSinceEpoch : IAlias<double>
        {
            public double Value { get; private set; }

            public TimeSinceEpoch(double value)
            {
                Value = value;
            }

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
        public struct LayerId : IAlias<string>
        {
            public string Value { get; private set; }

            public LayerId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique snapshot identifier.
        /// </summary>
        public struct SnapshotId : IAlias<string>
        {
            public string Value { get; private set; }

            public SnapshotId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Rectangle where scrolling happens on the main thread.
        /// </summary>
        public class ScrollRect
        {

            /// <summary>
            /// Rectangle itself.
            /// </summary>
            [JsonProperty("rect")]
            public DOM.Rect Rect { get; set; }

            /// <summary>
            /// Reason for rectangle to force scrolling on the main thread
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
        }

        /// <summary>
        /// Sticky position constraints.
        /// </summary>
        public class StickyPositionConstraint
        {

            /// <summary>
            /// Layout rectangle of the sticky element before being shifted
            /// </summary>
            [JsonProperty("stickyBoxRect")]
            public DOM.Rect StickyBoxRect { get; set; }

            /// <summary>
            /// Layout rectangle of the containing block of the sticky element
            /// </summary>
            [JsonProperty("containingBlockRect")]
            public DOM.Rect ContainingBlockRect { get; set; }

            /// <summary>
            /// The nearest sticky layer that shifts the sticky box
            /// </summary>
            [JsonProperty("nearestLayerShiftingStickyBox")]
            public LayerId NearestLayerShiftingStickyBox { get; set; }

            /// <summary>
            /// The nearest sticky layer that shifts the containing block
            /// </summary>
            [JsonProperty("nearestLayerShiftingContainingBlock")]
            public LayerId NearestLayerShiftingContainingBlock { get; set; }
        }

        /// <summary>
        /// Serialized fragment of layer picture along with its offset within the layer.
        /// </summary>
        public class PictureTile
        {

            /// <summary>
            /// Offset from owning layer left boundary
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Offset from owning layer top boundary
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// Base64-encoded snapshot data.
            /// </summary>
            [JsonProperty("picture")]
            public string Picture { get; set; }
        }

        /// <summary>
        /// Information about a compositing layer.
        /// </summary>
        public class Layer
        {

            /// <summary>
            /// The unique id for this layer.
            /// </summary>
            [JsonProperty("layerId")]
            public LayerId LayerId { get; set; }

            /// <summary>
            /// The id of parent (not present for root).
            /// </summary>
            [JsonProperty("parentLayerId")]
            public LayerId ParentLayerId { get; set; }

            /// <summary>
            /// The backend id for the node associated with this layer.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// Offset from parent layer, X coordinate.
            /// </summary>
            [JsonProperty("offsetX")]
            public double OffsetX { get; set; }

            /// <summary>
            /// Offset from parent layer, Y coordinate.
            /// </summary>
            [JsonProperty("offsetY")]
            public double OffsetY { get; set; }

            /// <summary>
            /// Layer width.
            /// </summary>
            [JsonProperty("width")]
            public double Width { get; set; }

            /// <summary>
            /// Layer height.
            /// </summary>
            [JsonProperty("height")]
            public double Height { get; set; }

            /// <summary>
            /// Transformation matrix for layer, default is identity matrix
            /// </summary>
            [JsonProperty("transform")]
            public double[] Transform { get; set; }

            /// <summary>
            /// Transform anchor point X, absent if no transform specified
            /// </summary>
            [JsonProperty("anchorX")]
            public double AnchorX { get; set; }

            /// <summary>
            /// Transform anchor point Y, absent if no transform specified
            /// </summary>
            [JsonProperty("anchorY")]
            public double AnchorY { get; set; }

            /// <summary>
            /// Transform anchor point Z, absent if no transform specified
            /// </summary>
            [JsonProperty("anchorZ")]
            public double AnchorZ { get; set; }

            /// <summary>
            /// Indicates how many time this layer has painted.
            /// </summary>
            [JsonProperty("paintCount")]
            public int PaintCount { get; set; }

            /// <summary>
            /// Indicates whether this layer hosts any content, rather than being used for
            /// transform/scrolling purposes only.
            /// </summary>
            [JsonProperty("drawsContent")]
            public bool DrawsContent { get; set; }

            /// <summary>
            /// Set if layer is not visible.
            /// </summary>
            [JsonProperty("invisible")]
            public bool Invisible { get; set; }

            /// <summary>
            /// Rectangles scrolling on main thread only.
            /// </summary>
            [JsonProperty("scrollRects")]
            public ScrollRect[] ScrollRects { get; set; }

            /// <summary>
            /// Sticky position constraint information
            /// </summary>
            [JsonProperty("stickyPositionConstraint")]
            public StickyPositionConstraint StickyPositionConstraint { get; set; }
        }

        /// <summary>
        /// Array of timings, one per paint step.
        /// </summary>
        public struct PaintProfile : IAlias<double[]>
        {
            public double[] Value { get; private set; }

            public PaintProfile(double[] value)
            {
                Value = value;
            }

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

            /// <summary>
            /// Log entry source.
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// Log entry severity.
            /// </summary>
            [JsonProperty("level")]
            public string Level { get; set; }

            /// <summary>
            /// Logged text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Timestamp when this entry was added.
            /// </summary>
            [JsonProperty("timestamp")]
            public Runtime.Timestamp Timestamp { get; set; }

            /// <summary>
            /// URL of the resource if known.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Line number in the resource.
            /// </summary>
            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            /// <summary>
            /// JavaScript stack trace.
            /// </summary>
            [JsonProperty("stackTrace")]
            public Runtime.StackTrace StackTrace { get; set; }

            /// <summary>
            /// Identifier of the network request associated with this entry.
            /// </summary>
            [JsonProperty("networkRequestId")]
            public Network.RequestId NetworkRequestId { get; set; }

            /// <summary>
            /// Identifier of the worker associated with this entry.
            /// </summary>
            [JsonProperty("workerId")]
            public string WorkerId { get; set; }

            /// <summary>
            /// Call arguments.
            /// </summary>
            [JsonProperty("args")]
            public Runtime.RemoteObject[] Args { get; set; }
        }

        /// <summary>
        /// Violation configuration setting.
        /// </summary>
        public class ViolationSetting
        {

            /// <summary>
            /// Violation type.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Time threshold to trigger upon.
            /// </summary>
            [JsonProperty("threshold")]
            public double Threshold { get; set; }
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
        public struct PressureLevel : IEnum
        {
            public string Value { get; private set; }

            public PressureLevel(string value)
            {
                Value = value;
            }

            public static PressureLevel Moderate => new PressureLevel("moderate");
            public static PressureLevel Critical => new PressureLevel("critical");
        }

        /// <summary>
        /// Heap profile sample.
        /// </summary>
        public class SamplingProfileNode
        {

            /// <summary>
            /// Size of the sampled allocation.
            /// </summary>
            [JsonProperty("size")]
            public double Size { get; set; }

            /// <summary>
            /// Total bytes attributed to this sample.
            /// </summary>
            [JsonProperty("total")]
            public double Total { get; set; }

            /// <summary>
            /// Execution stack at the point of allocation.
            /// </summary>
            [JsonProperty("stack")]
            public string[] Stack { get; set; }
        }

        /// <summary>
        /// Array of heap profile samples.
        /// </summary>
        public class SamplingProfile
        {

            [JsonProperty("samples")]
            public SamplingProfileNode[] Samples { get; set; }

            [JsonProperty("modules")]
            public Module[] Modules { get; set; }
        }

        /// <summary>
        /// Executable module information
        /// </summary>
        public class Module
        {

            /// <summary>
            /// Name of the module.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// UUID of the module.
            /// </summary>
            [JsonProperty("uuid")]
            public string Uuid { get; set; }

            /// <summary>
            /// Base address where the module is loaded into memory. Encoded as a decimal
            /// or hexadecimal (0x prefixed) string.
            /// </summary>
            [JsonProperty("baseAddress")]
            public string BaseAddress { get; set; }

            /// <summary>
            /// Size of the module in bytes.
            /// </summary>
            [JsonProperty("size")]
            public double Size { get; set; }
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
        public struct ResourceType : IEnum
        {
            public string Value { get; private set; }

            public ResourceType(string value)
            {
                Value = value;
            }

            public static ResourceType Document => new ResourceType("Document");
            public static ResourceType Stylesheet => new ResourceType("Stylesheet");
            public static ResourceType Image => new ResourceType("Image");
            public static ResourceType Media => new ResourceType("Media");
            public static ResourceType Font => new ResourceType("Font");
            public static ResourceType Script => new ResourceType("Script");
            public static ResourceType TextTrack => new ResourceType("TextTrack");
            public static ResourceType XHR => new ResourceType("XHR");
            public static ResourceType Fetch => new ResourceType("Fetch");
            public static ResourceType EventSource => new ResourceType("EventSource");
            public static ResourceType WebSocket => new ResourceType("WebSocket");
            public static ResourceType Manifest => new ResourceType("Manifest");
            public static ResourceType SignedExchange => new ResourceType("SignedExchange");
            public static ResourceType Ping => new ResourceType("Ping");
            public static ResourceType CSPViolationReport => new ResourceType("CSPViolationReport");
            public static ResourceType Other => new ResourceType("Other");
        }

        /// <summary>
        /// Unique loader identifier.
        /// </summary>
        public struct LoaderId : IAlias<string>
        {
            public string Value { get; private set; }

            public LoaderId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique request identifier.
        /// </summary>
        public struct RequestId : IAlias<string>
        {
            public string Value { get; private set; }

            public RequestId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique intercepted request identifier.
        /// </summary>
        public struct InterceptionId : IAlias<string>
        {
            public string Value { get; private set; }

            public InterceptionId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Network level fetch failure reason.
        /// </summary>
        public struct ErrorReason : IEnum
        {
            public string Value { get; private set; }

            public ErrorReason(string value)
            {
                Value = value;
            }

            public static ErrorReason Failed => new ErrorReason("Failed");
            public static ErrorReason Aborted => new ErrorReason("Aborted");
            public static ErrorReason TimedOut => new ErrorReason("TimedOut");
            public static ErrorReason AccessDenied => new ErrorReason("AccessDenied");
            public static ErrorReason ConnectionClosed => new ErrorReason("ConnectionClosed");
            public static ErrorReason ConnectionReset => new ErrorReason("ConnectionReset");
            public static ErrorReason ConnectionRefused => new ErrorReason("ConnectionRefused");
            public static ErrorReason ConnectionAborted => new ErrorReason("ConnectionAborted");
            public static ErrorReason ConnectionFailed => new ErrorReason("ConnectionFailed");
            public static ErrorReason NameNotResolved => new ErrorReason("NameNotResolved");
            public static ErrorReason InternetDisconnected => new ErrorReason("InternetDisconnected");
            public static ErrorReason AddressUnreachable => new ErrorReason("AddressUnreachable");
            public static ErrorReason BlockedByClient => new ErrorReason("BlockedByClient");
            public static ErrorReason BlockedByResponse => new ErrorReason("BlockedByResponse");
        }

        /// <summary>
        /// UTC time in seconds, counted from January 1, 1970.
        /// </summary>
        public struct TimeSinceEpoch : IAlias<double>
        {
            public double Value { get; private set; }

            public TimeSinceEpoch(double value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Monotonically increasing time in seconds since an arbitrary point in the past.
        /// </summary>
        public struct MonotonicTime : IAlias<double>
        {
            public double Value { get; private set; }

            public MonotonicTime(double value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Request / response headers as keys / values of JSON object.
        /// </summary>
        public class Headers : Dictionary<string, object>
        {
        }

        /// <summary>
        /// The underlying connection technology that the browser is supposedly using.
        /// </summary>
        public struct ConnectionType : IEnum
        {
            public string Value { get; private set; }

            public ConnectionType(string value)
            {
                Value = value;
            }

            public static ConnectionType None => new ConnectionType("none");
            public static ConnectionType Cellular2g => new ConnectionType("cellular2g");
            public static ConnectionType Cellular3g => new ConnectionType("cellular3g");
            public static ConnectionType Cellular4g => new ConnectionType("cellular4g");
            public static ConnectionType Bluetooth => new ConnectionType("bluetooth");
            public static ConnectionType Ethernet => new ConnectionType("ethernet");
            public static ConnectionType Wifi => new ConnectionType("wifi");
            public static ConnectionType Wimax => new ConnectionType("wimax");
            public static ConnectionType Other => new ConnectionType("other");
        }

        /// <summary>
        /// Represents the cookie's 'SameSite' status:
        /// https://tools.ietf.org/html/draft-west-first-party-cookies
        /// </summary>
        public struct CookieSameSite : IEnum
        {
            public string Value { get; private set; }

            public CookieSameSite(string value)
            {
                Value = value;
            }

            public static CookieSameSite Strict => new CookieSameSite("Strict");
            public static CookieSameSite Lax => new CookieSameSite("Lax");
        }

        /// <summary>
        /// Timing information for the request.
        /// </summary>
        public class ResourceTiming
        {

            /// <summary>
            /// Timing's requestTime is a baseline in seconds, while the other numbers are ticks in
            /// milliseconds relatively to this requestTime.
            /// </summary>
            [JsonProperty("requestTime")]
            public double RequestTime { get; set; }

            /// <summary>
            /// Started resolving proxy.
            /// </summary>
            [JsonProperty("proxyStart")]
            public double ProxyStart { get; set; }

            /// <summary>
            /// Finished resolving proxy.
            /// </summary>
            [JsonProperty("proxyEnd")]
            public double ProxyEnd { get; set; }

            /// <summary>
            /// Started DNS address resolve.
            /// </summary>
            [JsonProperty("dnsStart")]
            public double DnsStart { get; set; }

            /// <summary>
            /// Finished DNS address resolve.
            /// </summary>
            [JsonProperty("dnsEnd")]
            public double DnsEnd { get; set; }

            /// <summary>
            /// Started connecting to the remote host.
            /// </summary>
            [JsonProperty("connectStart")]
            public double ConnectStart { get; set; }

            /// <summary>
            /// Connected to the remote host.
            /// </summary>
            [JsonProperty("connectEnd")]
            public double ConnectEnd { get; set; }

            /// <summary>
            /// Started SSL handshake.
            /// </summary>
            [JsonProperty("sslStart")]
            public double SslStart { get; set; }

            /// <summary>
            /// Finished SSL handshake.
            /// </summary>
            [JsonProperty("sslEnd")]
            public double SslEnd { get; set; }

            /// <summary>
            /// Started running ServiceWorker.
            /// </summary>
            [JsonProperty("workerStart")]
            public double WorkerStart { get; set; }

            /// <summary>
            /// Finished Starting ServiceWorker.
            /// </summary>
            [JsonProperty("workerReady")]
            public double WorkerReady { get; set; }

            /// <summary>
            /// Started sending request.
            /// </summary>
            [JsonProperty("sendStart")]
            public double SendStart { get; set; }

            /// <summary>
            /// Finished sending request.
            /// </summary>
            [JsonProperty("sendEnd")]
            public double SendEnd { get; set; }

            /// <summary>
            /// Time the server started pushing request.
            /// </summary>
            [JsonProperty("pushStart")]
            public double PushStart { get; set; }

            /// <summary>
            /// Time the server finished pushing request.
            /// </summary>
            [JsonProperty("pushEnd")]
            public double PushEnd { get; set; }

            /// <summary>
            /// Finished receiving response headers.
            /// </summary>
            [JsonProperty("receiveHeadersEnd")]
            public double ReceiveHeadersEnd { get; set; }
        }

        /// <summary>
        /// Loading priority of a resource request.
        /// </summary>
        public struct ResourcePriority : IEnum
        {
            public string Value { get; private set; }

            public ResourcePriority(string value)
            {
                Value = value;
            }

            public static ResourcePriority VeryLow => new ResourcePriority("VeryLow");
            public static ResourcePriority Low => new ResourcePriority("Low");
            public static ResourcePriority Medium => new ResourcePriority("Medium");
            public static ResourcePriority High => new ResourcePriority("High");
            public static ResourcePriority VeryHigh => new ResourcePriority("VeryHigh");
        }

        /// <summary>
        /// HTTP request data.
        /// </summary>
        public class Request
        {

            /// <summary>
            /// Request URL (without fragment).
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Fragment of the requested URL starting with hash, if present.
            /// </summary>
            [JsonProperty("urlFragment")]
            public string UrlFragment { get; set; }

            /// <summary>
            /// HTTP request method.
            /// </summary>
            [JsonProperty("method")]
            public string Method { get; set; }

            /// <summary>
            /// HTTP request headers.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }

            /// <summary>
            /// HTTP POST request data.
            /// </summary>
            [JsonProperty("postData")]
            public string PostData { get; set; }

            /// <summary>
            /// True when the request has POST data. Note that postData might still be omitted when this flag is true when the data is too long.
            /// </summary>
            [JsonProperty("hasPostData")]
            public bool HasPostData { get; set; }

            /// <summary>
            /// The mixed content type of the request.
            /// </summary>
            [JsonProperty("mixedContentType")]
            public Security.MixedContentType MixedContentType { get; set; }

            /// <summary>
            /// Priority of the resource request at the time request is sent.
            /// </summary>
            [JsonProperty("initialPriority")]
            public ResourcePriority InitialPriority { get; set; }

            /// <summary>
            /// The referrer policy of the request, as defined in https://www.w3.org/TR/referrer-policy/
            /// </summary>
            [JsonProperty("referrerPolicy")]
            public string ReferrerPolicy { get; set; }

            /// <summary>
            /// Whether is loaded via link preload.
            /// </summary>
            [JsonProperty("isLinkPreload")]
            public bool IsLinkPreload { get; set; }
        }

        /// <summary>
        /// Details of a signed certificate timestamp (SCT).
        /// </summary>
        public class SignedCertificateTimestamp
        {

            /// <summary>
            /// Validation status.
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// Origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// Log name / description.
            /// </summary>
            [JsonProperty("logDescription")]
            public string LogDescription { get; set; }

            /// <summary>
            /// Log ID.
            /// </summary>
            [JsonProperty("logId")]
            public string LogId { get; set; }

            /// <summary>
            /// Issuance date.
            /// </summary>
            [JsonProperty("timestamp")]
            public TimeSinceEpoch Timestamp { get; set; }

            /// <summary>
            /// Hash algorithm.
            /// </summary>
            [JsonProperty("hashAlgorithm")]
            public string HashAlgorithm { get; set; }

            /// <summary>
            /// Signature algorithm.
            /// </summary>
            [JsonProperty("signatureAlgorithm")]
            public string SignatureAlgorithm { get; set; }

            /// <summary>
            /// Signature data.
            /// </summary>
            [JsonProperty("signatureData")]
            public string SignatureData { get; set; }
        }

        /// <summary>
        /// Security details about a request.
        /// </summary>
        public class SecurityDetails
        {

            /// <summary>
            /// Protocol name (e.g. "TLS 1.2" or "QUIC").
            /// </summary>
            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            /// <summary>
            /// Key Exchange used by the connection, or the empty string if not applicable.
            /// </summary>
            [JsonProperty("keyExchange")]
            public string KeyExchange { get; set; }

            /// <summary>
            /// (EC)DH group used by the connection, if applicable.
            /// </summary>
            [JsonProperty("keyExchangeGroup")]
            public string KeyExchangeGroup { get; set; }

            /// <summary>
            /// Cipher name.
            /// </summary>
            [JsonProperty("cipher")]
            public string Cipher { get; set; }

            /// <summary>
            /// TLS MAC. Note that AEAD ciphers do not have separate MACs.
            /// </summary>
            [JsonProperty("mac")]
            public string Mac { get; set; }

            /// <summary>
            /// Certificate ID value.
            /// </summary>
            [JsonProperty("certificateId")]
            public Security.CertificateId CertificateId { get; set; }

            /// <summary>
            /// Certificate subject name.
            /// </summary>
            [JsonProperty("subjectName")]
            public string SubjectName { get; set; }

            /// <summary>
            /// Subject Alternative Name (SAN) DNS names and IP addresses.
            /// </summary>
            [JsonProperty("sanList")]
            public string[] SanList { get; set; }

            /// <summary>
            /// Name of the issuing CA.
            /// </summary>
            [JsonProperty("issuer")]
            public string Issuer { get; set; }

            /// <summary>
            /// Certificate valid from date.
            /// </summary>
            [JsonProperty("validFrom")]
            public TimeSinceEpoch ValidFrom { get; set; }

            /// <summary>
            /// Certificate valid to (expiration) date
            /// </summary>
            [JsonProperty("validTo")]
            public TimeSinceEpoch ValidTo { get; set; }

            /// <summary>
            /// List of signed certificate timestamps (SCTs).
            /// </summary>
            [JsonProperty("signedCertificateTimestampList")]
            public SignedCertificateTimestamp[] SignedCertificateTimestampList { get; set; }

            /// <summary>
            /// Whether the request complied with Certificate Transparency policy
            /// </summary>
            [JsonProperty("certificateTransparencyCompliance")]
            public CertificateTransparencyCompliance CertificateTransparencyCompliance { get; set; }
        }

        /// <summary>
        /// Whether the request complied with Certificate Transparency policy.
        /// </summary>
        public struct CertificateTransparencyCompliance : IEnum
        {
            public string Value { get; private set; }

            public CertificateTransparencyCompliance(string value)
            {
                Value = value;
            }

            public static CertificateTransparencyCompliance Unknown => new CertificateTransparencyCompliance("unknown");
            public static CertificateTransparencyCompliance NotCompliant => new CertificateTransparencyCompliance("not-compliant");
            public static CertificateTransparencyCompliance Compliant => new CertificateTransparencyCompliance("compliant");
        }

        /// <summary>
        /// The reason why request was blocked.
        /// </summary>
        public struct BlockedReason : IEnum
        {
            public string Value { get; private set; }

            public BlockedReason(string value)
            {
                Value = value;
            }

            public static BlockedReason Other => new BlockedReason("other");
            public static BlockedReason Csp => new BlockedReason("csp");
            public static BlockedReason MixedContent => new BlockedReason("mixed-content");
            public static BlockedReason Origin => new BlockedReason("origin");
            public static BlockedReason Inspector => new BlockedReason("inspector");
            public static BlockedReason SubresourceFilter => new BlockedReason("subresource-filter");
            public static BlockedReason ContentType => new BlockedReason("content-type");
            public static BlockedReason CollapsedByClient => new BlockedReason("collapsed-by-client");
        }

        /// <summary>
        /// HTTP response data.
        /// </summary>
        public class Response
        {

            /// <summary>
            /// Response URL. This URL can be different from CachedResource.url in case of redirect.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// HTTP response status code.
            /// </summary>
            [JsonProperty("status")]
            public int Status { get; set; }

            /// <summary>
            /// HTTP response status text.
            /// </summary>
            [JsonProperty("statusText")]
            public string StatusText { get; set; }

            /// <summary>
            /// HTTP response headers.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }

            /// <summary>
            /// HTTP response headers text.
            /// </summary>
            [JsonProperty("headersText")]
            public string HeadersText { get; set; }

            /// <summary>
            /// Resource mimeType as determined by the browser.
            /// </summary>
            [JsonProperty("mimeType")]
            public string MimeType { get; set; }

            /// <summary>
            /// Refined HTTP request headers that were actually transmitted over the network.
            /// </summary>
            [JsonProperty("requestHeaders")]
            public Headers RequestHeaders { get; set; }

            /// <summary>
            /// HTTP request headers text.
            /// </summary>
            [JsonProperty("requestHeadersText")]
            public string RequestHeadersText { get; set; }

            /// <summary>
            /// Specifies whether physical connection was actually reused for this request.
            /// </summary>
            [JsonProperty("connectionReused")]
            public bool ConnectionReused { get; set; }

            /// <summary>
            /// Physical connection id that was actually used for this request.
            /// </summary>
            [JsonProperty("connectionId")]
            public double ConnectionId { get; set; }

            /// <summary>
            /// Remote IP address.
            /// </summary>
            [JsonProperty("remoteIPAddress")]
            public string RemoteIPAddress { get; set; }

            /// <summary>
            /// Remote port.
            /// </summary>
            [JsonProperty("remotePort")]
            public int RemotePort { get; set; }

            /// <summary>
            /// Specifies that the request was served from the disk cache.
            /// </summary>
            [JsonProperty("fromDiskCache")]
            public bool FromDiskCache { get; set; }

            /// <summary>
            /// Specifies that the request was served from the ServiceWorker.
            /// </summary>
            [JsonProperty("fromServiceWorker")]
            public bool FromServiceWorker { get; set; }

            /// <summary>
            /// Total number of bytes received for this request so far.
            /// </summary>
            [JsonProperty("encodedDataLength")]
            public double EncodedDataLength { get; set; }

            /// <summary>
            /// Timing information for the given request.
            /// </summary>
            [JsonProperty("timing")]
            public ResourceTiming Timing { get; set; }

            /// <summary>
            /// Protocol used to fetch this request.
            /// </summary>
            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            /// <summary>
            /// Security state of the request resource.
            /// </summary>
            [JsonProperty("securityState")]
            public Security.SecurityState SecurityState { get; set; }

            /// <summary>
            /// Security details for the request.
            /// </summary>
            [JsonProperty("securityDetails")]
            public SecurityDetails SecurityDetails { get; set; }
        }

        /// <summary>
        /// WebSocket request data.
        /// </summary>
        public class WebSocketRequest
        {

            /// <summary>
            /// HTTP request headers.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }
        }

        /// <summary>
        /// WebSocket response data.
        /// </summary>
        public class WebSocketResponse
        {

            /// <summary>
            /// HTTP response status code.
            /// </summary>
            [JsonProperty("status")]
            public int Status { get; set; }

            /// <summary>
            /// HTTP response status text.
            /// </summary>
            [JsonProperty("statusText")]
            public string StatusText { get; set; }

            /// <summary>
            /// HTTP response headers.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }

            /// <summary>
            /// HTTP response headers text.
            /// </summary>
            [JsonProperty("headersText")]
            public string HeadersText { get; set; }

            /// <summary>
            /// HTTP request headers.
            /// </summary>
            [JsonProperty("requestHeaders")]
            public Headers RequestHeaders { get; set; }

            /// <summary>
            /// HTTP request headers text.
            /// </summary>
            [JsonProperty("requestHeadersText")]
            public string RequestHeadersText { get; set; }
        }

        /// <summary>
        /// WebSocket message data. This represents an entire WebSocket message, not just a fragmented frame as the name suggests.
        /// </summary>
        public class WebSocketFrame
        {

            /// <summary>
            /// WebSocket message opcode.
            /// </summary>
            [JsonProperty("opcode")]
            public double Opcode { get; set; }

            /// <summary>
            /// WebSocket message mask.
            /// </summary>
            [JsonProperty("mask")]
            public bool Mask { get; set; }

            /// <summary>
            /// WebSocket message payload data.
            /// If the opcode is 1, this is a text message and payloadData is a UTF-8 string.
            /// If the opcode isn't 1, then payloadData is a base64 encoded string representing binary data.
            /// </summary>
            [JsonProperty("payloadData")]
            public string PayloadData { get; set; }
        }

        /// <summary>
        /// Information about the cached resource.
        /// </summary>
        public class CachedResource
        {

            /// <summary>
            /// Resource URL. This is the url of the original network request.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Type of this resource.
            /// </summary>
            [JsonProperty("type")]
            public ResourceType Type { get; set; }

            /// <summary>
            /// Cached response data.
            /// </summary>
            [JsonProperty("response")]
            public Response Response { get; set; }

            /// <summary>
            /// Cached response body size.
            /// </summary>
            [JsonProperty("bodySize")]
            public double BodySize { get; set; }
        }

        /// <summary>
        /// Information about the request initiator.
        /// </summary>
        public class Initiator
        {

            /// <summary>
            /// Type of this initiator.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Initiator JavaScript stack trace, set for Script only.
            /// </summary>
            [JsonProperty("stack")]
            public Runtime.StackTrace Stack { get; set; }

            /// <summary>
            /// Initiator URL, set for Parser type or for Script type (when script is importing module) or for SignedExchange type.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Initiator line number, set for Parser type or for Script type (when script is importing
            /// module) (0-based).
            /// </summary>
            [JsonProperty("lineNumber")]
            public double LineNumber { get; set; }
        }

        /// <summary>
        /// Cookie object
        /// </summary>
        public class Cookie
        {

            /// <summary>
            /// Cookie name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Cookie value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// Cookie domain.
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// Cookie path.
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }

            /// <summary>
            /// Cookie expiration date as the number of seconds since the UNIX epoch.
            /// </summary>
            [JsonProperty("expires")]
            public double Expires { get; set; }

            /// <summary>
            /// Cookie size.
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }

            /// <summary>
            /// True if cookie is http-only.
            /// </summary>
            [JsonProperty("httpOnly")]
            public bool HttpOnly { get; set; }

            /// <summary>
            /// True if cookie is secure.
            /// </summary>
            [JsonProperty("secure")]
            public bool Secure { get; set; }

            /// <summary>
            /// True in case of session cookie.
            /// </summary>
            [JsonProperty("session")]
            public bool Session { get; set; }

            /// <summary>
            /// Cookie SameSite type.
            /// </summary>
            [JsonProperty("sameSite")]
            public CookieSameSite SameSite { get; set; }
        }

        /// <summary>
        /// Cookie parameter object
        /// </summary>
        public class CookieParam
        {

            /// <summary>
            /// Cookie name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Cookie value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }

            /// <summary>
            /// The request-URI to associate with the setting of the cookie. This value can affect the
            /// default domain and path values of the created cookie.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Cookie domain.
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// Cookie path.
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }

            /// <summary>
            /// True if cookie is secure.
            /// </summary>
            [JsonProperty("secure")]
            public bool Secure { get; set; }

            /// <summary>
            /// True if cookie is http-only.
            /// </summary>
            [JsonProperty("httpOnly")]
            public bool HttpOnly { get; set; }

            /// <summary>
            /// Cookie SameSite type.
            /// </summary>
            [JsonProperty("sameSite")]
            public CookieSameSite SameSite { get; set; }

            /// <summary>
            /// Cookie expiration date, session cookie if not set
            /// </summary>
            [JsonProperty("expires")]
            public TimeSinceEpoch Expires { get; set; }
        }

        /// <summary>
        /// Authorization challenge for HTTP status code 401 or 407.
        /// </summary>
        public class AuthChallenge
        {

            /// <summary>
            /// Source of the authentication challenge.
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// Origin of the challenger.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// The authentication scheme used, such as basic or digest
            /// </summary>
            [JsonProperty("scheme")]
            public string Scheme { get; set; }

            /// <summary>
            /// The realm of the challenge. May be empty.
            /// </summary>
            [JsonProperty("realm")]
            public string Realm { get; set; }
        }

        /// <summary>
        /// Response to an AuthChallenge.
        /// </summary>
        public class AuthChallengeResponse
        {

            /// <summary>
            /// The decision on what to do in response to the authorization challenge.  Default means
            /// deferring to the default behavior of the net stack, which will likely either the Cancel
            /// authentication or display a popup dialog box.
            /// </summary>
            [JsonProperty("response")]
            public string Response { get; set; }

            /// <summary>
            /// The username to provide, possibly empty. Should only be set if response is
            /// ProvideCredentials.
            /// </summary>
            [JsonProperty("username")]
            public string Username { get; set; }

            /// <summary>
            /// The password to provide, possibly empty. Should only be set if response is
            /// ProvideCredentials.
            /// </summary>
            [JsonProperty("password")]
            public string Password { get; set; }
        }

        /// <summary>
        /// Stages of the interception to begin intercepting. Request will intercept before the request is
        /// sent. Response will intercept after the response is received.
        /// </summary>
        public struct InterceptionStage : IEnum
        {
            public string Value { get; private set; }

            public InterceptionStage(string value)
            {
                Value = value;
            }

            public static InterceptionStage Request => new InterceptionStage("Request");
            public static InterceptionStage HeadersReceived => new InterceptionStage("HeadersReceived");
        }

        /// <summary>
        /// Request pattern for interception.
        /// </summary>
        public class RequestPattern
        {

            /// <summary>
            /// Wildcards ('*' -&gt; zero or more, '?' -&gt; exactly one) are allowed. Escape character is
            /// backslash. Omitting is equivalent to "*".
            /// </summary>
            [JsonProperty("urlPattern")]
            public string UrlPattern { get; set; }

            /// <summary>
            /// If set, only requests for matching resource types will be intercepted.
            /// </summary>
            [JsonProperty("resourceType")]
            public ResourceType ResourceType { get; set; }

            /// <summary>
            /// Stage at wich to begin intercepting requests. Default is Request.
            /// </summary>
            [JsonProperty("interceptionStage")]
            public InterceptionStage InterceptionStage { get; set; }
        }

        /// <summary>
        /// Information about a signed exchange signature.
        /// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#rfc.section.3.1
        /// </summary>
        public class SignedExchangeSignature
        {

            /// <summary>
            /// Signed exchange signature label.
            /// </summary>
            [JsonProperty("label")]
            public string Label { get; set; }

            /// <summary>
            /// The hex string of signed exchange signature.
            /// </summary>
            [JsonProperty("signature")]
            public string Signature { get; set; }

            /// <summary>
            /// Signed exchange signature integrity.
            /// </summary>
            [JsonProperty("integrity")]
            public string Integrity { get; set; }

            /// <summary>
            /// Signed exchange signature cert Url.
            /// </summary>
            [JsonProperty("certUrl")]
            public string CertUrl { get; set; }

            /// <summary>
            /// The hex string of signed exchange signature cert sha256.
            /// </summary>
            [JsonProperty("certSha256")]
            public string CertSha256 { get; set; }

            /// <summary>
            /// Signed exchange signature validity Url.
            /// </summary>
            [JsonProperty("validityUrl")]
            public string ValidityUrl { get; set; }

            /// <summary>
            /// Signed exchange signature date.
            /// </summary>
            [JsonProperty("date")]
            public int Date { get; set; }

            /// <summary>
            /// Signed exchange signature expires.
            /// </summary>
            [JsonProperty("expires")]
            public int Expires { get; set; }

            /// <summary>
            /// The encoded certificates.
            /// </summary>
            [JsonProperty("certificates")]
            public string[] Certificates { get; set; }
        }

        /// <summary>
        /// Information about a signed exchange header.
        /// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#cbor-representation
        /// </summary>
        public class SignedExchangeHeader
        {

            /// <summary>
            /// Signed exchange request URL.
            /// </summary>
            [JsonProperty("requestUrl")]
            public string RequestUrl { get; set; }

            /// <summary>
            /// Signed exchange request method.
            /// </summary>
            [JsonProperty("requestMethod")]
            public string RequestMethod { get; set; }

            /// <summary>
            /// Signed exchange response code.
            /// </summary>
            [JsonProperty("responseCode")]
            public int ResponseCode { get; set; }

            /// <summary>
            /// Signed exchange response headers.
            /// </summary>
            [JsonProperty("responseHeaders")]
            public Headers ResponseHeaders { get; set; }

            /// <summary>
            /// Signed exchange response signature.
            /// </summary>
            [JsonProperty("signatures")]
            public SignedExchangeSignature[] Signatures { get; set; }
        }

        /// <summary>
        /// Field type for a signed exchange related error.
        /// </summary>
        public struct SignedExchangeErrorField : IEnum
        {
            public string Value { get; private set; }

            public SignedExchangeErrorField(string value)
            {
                Value = value;
            }

            public static SignedExchangeErrorField SignatureSig => new SignedExchangeErrorField("signatureSig");
            public static SignedExchangeErrorField SignatureIntegrity => new SignedExchangeErrorField("signatureIntegrity");
            public static SignedExchangeErrorField SignatureCertUrl => new SignedExchangeErrorField("signatureCertUrl");
            public static SignedExchangeErrorField SignatureCertSha256 => new SignedExchangeErrorField("signatureCertSha256");
            public static SignedExchangeErrorField SignatureValidityUrl => new SignedExchangeErrorField("signatureValidityUrl");
            public static SignedExchangeErrorField SignatureTimestamps => new SignedExchangeErrorField("signatureTimestamps");
        }

        /// <summary>
        /// Information about a signed exchange response.
        /// </summary>
        public class SignedExchangeError
        {

            /// <summary>
            /// Error message.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// The index of the signature which caused the error.
            /// </summary>
            [JsonProperty("signatureIndex")]
            public int SignatureIndex { get; set; }

            /// <summary>
            /// The field which caused the error.
            /// </summary>
            [JsonProperty("errorField")]
            public SignedExchangeErrorField ErrorField { get; set; }
        }

        /// <summary>
        /// Information about a signed exchange response.
        /// </summary>
        public class SignedExchangeInfo
        {

            /// <summary>
            /// The outer response of signed HTTP exchange which was received from network.
            /// </summary>
            [JsonProperty("outerResponse")]
            public Response OuterResponse { get; set; }

            /// <summary>
            /// Information about the signed exchange header.
            /// </summary>
            [JsonProperty("header")]
            public SignedExchangeHeader Header { get; set; }

            /// <summary>
            /// Security details for the signed exchange header.
            /// </summary>
            [JsonProperty("securityDetails")]
            public SecurityDetails SecurityDetails { get; set; }

            /// <summary>
            /// Errors occurred while handling the signed exchagne.
            /// </summary>
            [JsonProperty("errors")]
            public SignedExchangeError[] Errors { get; set; }
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

            /// <summary>
            /// Whether the node info tooltip should be shown (default: false).
            /// </summary>
            [JsonProperty("showInfo")]
            public bool ShowInfo { get; set; }

            /// <summary>
            /// Whether the node styles in the tooltip (default: false).
            /// </summary>
            [JsonProperty("showStyles")]
            public bool ShowStyles { get; set; }

            /// <summary>
            /// Whether the rulers should be shown (default: false).
            /// </summary>
            [JsonProperty("showRulers")]
            public bool ShowRulers { get; set; }

            /// <summary>
            /// Whether the extension lines from node to the rulers should be shown (default: false).
            /// </summary>
            [JsonProperty("showExtensionLines")]
            public bool ShowExtensionLines { get; set; }

            /// <summary>
            /// The content box highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("contentColor")]
            public DOM.RGBA ContentColor { get; set; }

            /// <summary>
            /// The padding highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("paddingColor")]
            public DOM.RGBA PaddingColor { get; set; }

            /// <summary>
            /// The border highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("borderColor")]
            public DOM.RGBA BorderColor { get; set; }

            /// <summary>
            /// The margin highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("marginColor")]
            public DOM.RGBA MarginColor { get; set; }

            /// <summary>
            /// The event target element highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("eventTargetColor")]
            public DOM.RGBA EventTargetColor { get; set; }

            /// <summary>
            /// The shape outside fill color (default: transparent).
            /// </summary>
            [JsonProperty("shapeColor")]
            public DOM.RGBA ShapeColor { get; set; }

            /// <summary>
            /// The shape margin fill color (default: transparent).
            /// </summary>
            [JsonProperty("shapeMarginColor")]
            public DOM.RGBA ShapeMarginColor { get; set; }

            /// <summary>
            /// Selectors to highlight relevant nodes.
            /// </summary>
            [JsonProperty("selectorList")]
            public string SelectorList { get; set; }

            /// <summary>
            /// The grid layout color (default: transparent).
            /// </summary>
            [JsonProperty("cssGridColor")]
            public DOM.RGBA CssGridColor { get; set; }
        }

        public struct InspectMode : IEnum
        {
            public string Value { get; private set; }

            public InspectMode(string value)
            {
                Value = value;
            }

            public static InspectMode SearchForNode => new InspectMode("searchForNode");
            public static InspectMode SearchForUAShadowDOM => new InspectMode("searchForUAShadowDOM");
            public static InspectMode None => new InspectMode("none");
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
        public struct FrameId : IAlias<string>
        {
            public string Value { get; private set; }

            public FrameId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Information about the Frame on the page.
        /// </summary>
        public class Frame
        {

            /// <summary>
            /// Frame unique identifier.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            /// Parent frame identifier.
            /// </summary>
            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            /// <summary>
            /// Identifier of the loader associated with this frame.
            /// </summary>
            [JsonProperty("loaderId")]
            public Network.LoaderId LoaderId { get; set; }

            /// <summary>
            /// Frame's name as specified in the tag.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Frame document's URL.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Frame document's security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Frame document's mimeType as determined by the browser.
            /// </summary>
            [JsonProperty("mimeType")]
            public string MimeType { get; set; }

            /// <summary>
            /// If the frame failed to load, this contains the URL that could not be loaded.
            /// </summary>
            [JsonProperty("unreachableUrl")]
            public string UnreachableUrl { get; set; }
        }

        /// <summary>
        /// Information about the Resource on the page.
        /// </summary>
        public class FrameResource
        {

            /// <summary>
            /// Resource URL.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Type of this resource.
            /// </summary>
            [JsonProperty("type")]
            public Network.ResourceType Type { get; set; }

            /// <summary>
            /// Resource mimeType as determined by the browser.
            /// </summary>
            [JsonProperty("mimeType")]
            public string MimeType { get; set; }

            /// <summary>
            /// last-modified timestamp as reported by server.
            /// </summary>
            [JsonProperty("lastModified")]
            public Network.TimeSinceEpoch LastModified { get; set; }

            /// <summary>
            /// Resource content size.
            /// </summary>
            [JsonProperty("contentSize")]
            public double ContentSize { get; set; }

            /// <summary>
            /// True if the resource failed to load.
            /// </summary>
            [JsonProperty("failed")]
            public bool Failed { get; set; }

            /// <summary>
            /// True if the resource was canceled during loading.
            /// </summary>
            [JsonProperty("canceled")]
            public bool Canceled { get; set; }
        }

        /// <summary>
        /// Information about the Frame hierarchy along with their cached resources.
        /// </summary>
        public class FrameResourceTree
        {

            /// <summary>
            /// Frame information for this tree item.
            /// </summary>
            [JsonProperty("frame")]
            public Frame Frame { get; set; }

            /// <summary>
            /// Child frames.
            /// </summary>
            [JsonProperty("childFrames")]
            public FrameResourceTree[] ChildFrames { get; set; }

            /// <summary>
            /// Information about frame resources.
            /// </summary>
            [JsonProperty("resources")]
            public FrameResource[] Resources { get; set; }
        }

        /// <summary>
        /// Information about the Frame hierarchy.
        /// </summary>
        public class FrameTree
        {

            /// <summary>
            /// Frame information for this tree item.
            /// </summary>
            [JsonProperty("frame")]
            public Frame Frame { get; set; }

            /// <summary>
            /// Child frames.
            /// </summary>
            [JsonProperty("childFrames")]
            public FrameTree[] ChildFrames { get; set; }
        }

        /// <summary>
        /// Unique script identifier.
        /// </summary>
        public struct ScriptIdentifier : IAlias<string>
        {
            public string Value { get; private set; }

            public ScriptIdentifier(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Transition type.
        /// </summary>
        public struct TransitionType : IEnum
        {
            public string Value { get; private set; }

            public TransitionType(string value)
            {
                Value = value;
            }

            public static TransitionType Link => new TransitionType("link");
            public static TransitionType Typed => new TransitionType("typed");
            public static TransitionType AddressBar => new TransitionType("address_bar");
            public static TransitionType AutoBookmark => new TransitionType("auto_bookmark");
            public static TransitionType AutoSubframe => new TransitionType("auto_subframe");
            public static TransitionType ManualSubframe => new TransitionType("manual_subframe");
            public static TransitionType Generated => new TransitionType("generated");
            public static TransitionType AutoToplevel => new TransitionType("auto_toplevel");
            public static TransitionType FormSubmit => new TransitionType("form_submit");
            public static TransitionType Reload => new TransitionType("reload");
            public static TransitionType Keyword => new TransitionType("keyword");
            public static TransitionType KeywordGenerated => new TransitionType("keyword_generated");
            public static TransitionType Other => new TransitionType("other");
        }

        /// <summary>
        /// Navigation history entry.
        /// </summary>
        public class NavigationEntry
        {

            /// <summary>
            /// Unique id of the navigation history entry.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// URL of the navigation history entry.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// URL that the user typed in the url bar.
            /// </summary>
            [JsonProperty("userTypedURL")]
            public string UserTypedURL { get; set; }

            /// <summary>
            /// Title of the navigation history entry.
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// Transition type.
            /// </summary>
            [JsonProperty("transitionType")]
            public TransitionType TransitionType { get; set; }
        }

        /// <summary>
        /// Screencast frame metadata.
        /// </summary>
        public class ScreencastFrameMetadata
        {

            /// <summary>
            /// Top offset in DIP.
            /// </summary>
            [JsonProperty("offsetTop")]
            public double OffsetTop { get; set; }

            /// <summary>
            /// Page scale factor.
            /// </summary>
            [JsonProperty("pageScaleFactor")]
            public double PageScaleFactor { get; set; }

            /// <summary>
            /// Device screen width in DIP.
            /// </summary>
            [JsonProperty("deviceWidth")]
            public double DeviceWidth { get; set; }

            /// <summary>
            /// Device screen height in DIP.
            /// </summary>
            [JsonProperty("deviceHeight")]
            public double DeviceHeight { get; set; }

            /// <summary>
            /// Position of horizontal scroll in CSS pixels.
            /// </summary>
            [JsonProperty("scrollOffsetX")]
            public double ScrollOffsetX { get; set; }

            /// <summary>
            /// Position of vertical scroll in CSS pixels.
            /// </summary>
            [JsonProperty("scrollOffsetY")]
            public double ScrollOffsetY { get; set; }

            /// <summary>
            /// Frame swap timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public Network.TimeSinceEpoch Timestamp { get; set; }
        }

        /// <summary>
        /// Javascript dialog type.
        /// </summary>
        public struct DialogType : IEnum
        {
            public string Value { get; private set; }

            public DialogType(string value)
            {
                Value = value;
            }

            public static DialogType Alert => new DialogType("alert");
            public static DialogType Confirm => new DialogType("confirm");
            public static DialogType Prompt => new DialogType("prompt");
            public static DialogType Beforeunload => new DialogType("beforeunload");
        }

        /// <summary>
        /// Error while paring app manifest.
        /// </summary>
        public class AppManifestError
        {

            /// <summary>
            /// Error message.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// If criticial, this is a non-recoverable parse error.
            /// </summary>
            [JsonProperty("critical")]
            public int Critical { get; set; }

            /// <summary>
            /// Error line.
            /// </summary>
            [JsonProperty("line")]
            public int Line { get; set; }

            /// <summary>
            /// Error column.
            /// </summary>
            [JsonProperty("column")]
            public int Column { get; set; }
        }

        /// <summary>
        /// Layout viewport position and dimensions.
        /// </summary>
        public class LayoutViewport
        {

            /// <summary>
            /// Horizontal offset relative to the document (CSS pixels).
            /// </summary>
            [JsonProperty("pageX")]
            public int PageX { get; set; }

            /// <summary>
            /// Vertical offset relative to the document (CSS pixels).
            /// </summary>
            [JsonProperty("pageY")]
            public int PageY { get; set; }

            /// <summary>
            /// Width (CSS pixels), excludes scrollbar if present.
            /// </summary>
            [JsonProperty("clientWidth")]
            public int ClientWidth { get; set; }

            /// <summary>
            /// Height (CSS pixels), excludes scrollbar if present.
            /// </summary>
            [JsonProperty("clientHeight")]
            public int ClientHeight { get; set; }
        }

        /// <summary>
        /// Visual viewport position, dimensions, and scale.
        /// </summary>
        public class VisualViewport
        {

            /// <summary>
            /// Horizontal offset relative to the layout viewport (CSS pixels).
            /// </summary>
            [JsonProperty("offsetX")]
            public double OffsetX { get; set; }

            /// <summary>
            /// Vertical offset relative to the layout viewport (CSS pixels).
            /// </summary>
            [JsonProperty("offsetY")]
            public double OffsetY { get; set; }

            /// <summary>
            /// Horizontal offset relative to the document (CSS pixels).
            /// </summary>
            [JsonProperty("pageX")]
            public double PageX { get; set; }

            /// <summary>
            /// Vertical offset relative to the document (CSS pixels).
            /// </summary>
            [JsonProperty("pageY")]
            public double PageY { get; set; }

            /// <summary>
            /// Width (CSS pixels), excludes scrollbar if present.
            /// </summary>
            [JsonProperty("clientWidth")]
            public double ClientWidth { get; set; }

            /// <summary>
            /// Height (CSS pixels), excludes scrollbar if present.
            /// </summary>
            [JsonProperty("clientHeight")]
            public double ClientHeight { get; set; }

            /// <summary>
            /// Scale relative to the ideal viewport (size at width=device-width).
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }

            /// <summary>
            /// Page zoom factor (CSS to device independent pixels ratio).
            /// </summary>
            [JsonProperty("zoom")]
            public double Zoom { get; set; }
        }

        /// <summary>
        /// Viewport for capturing screenshot.
        /// </summary>
        public class Viewport
        {

            /// <summary>
            /// X offset in device independent pixels (dip).
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y offset in device independent pixels (dip).
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// Rectangle width in device independent pixels (dip).
            /// </summary>
            [JsonProperty("width")]
            public double Width { get; set; }

            /// <summary>
            /// Rectangle height in device independent pixels (dip).
            /// </summary>
            [JsonProperty("height")]
            public double Height { get; set; }

            /// <summary>
            /// Page scale factor.
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }
        }

        /// <summary>
        /// Generic font families collection.
        /// </summary>
        public class FontFamilies
        {

            /// <summary>
            /// The standard font-family.
            /// </summary>
            [JsonProperty("standard")]
            public string Standard { get; set; }

            /// <summary>
            /// The fixed font-family.
            /// </summary>
            [JsonProperty("fixed")]
            public string Fixed { get; set; }

            /// <summary>
            /// The serif font-family.
            /// </summary>
            [JsonProperty("serif")]
            public string Serif { get; set; }

            /// <summary>
            /// The sansSerif font-family.
            /// </summary>
            [JsonProperty("sansSerif")]
            public string SansSerif { get; set; }

            /// <summary>
            /// The cursive font-family.
            /// </summary>
            [JsonProperty("cursive")]
            public string Cursive { get; set; }

            /// <summary>
            /// The fantasy font-family.
            /// </summary>
            [JsonProperty("fantasy")]
            public string Fantasy { get; set; }

            /// <summary>
            /// The pictograph font-family.
            /// </summary>
            [JsonProperty("pictograph")]
            public string Pictograph { get; set; }
        }

        /// <summary>
        /// Default font sizes.
        /// </summary>
        public class FontSizes
        {

            /// <summary>
            /// Default standard font size.
            /// </summary>
            [JsonProperty("standard")]
            public int Standard { get; set; }

            /// <summary>
            /// Default fixed font size.
            /// </summary>
            [JsonProperty("fixed")]
            public int Fixed { get; set; }
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

            /// <summary>
            /// Metric name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Metric value.
            /// </summary>
            [JsonProperty("value")]
            public double Value { get; set; }
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
        public struct CertificateId : IAlias<int>
        {
            public int Value { get; private set; }

            public CertificateId(int value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// A description of mixed content (HTTP resources on HTTPS pages), as defined by
        /// https://www.w3.org/TR/mixed-content/#categories
        /// </summary>
        public struct MixedContentType : IEnum
        {
            public string Value { get; private set; }

            public MixedContentType(string value)
            {
                Value = value;
            }

            public static MixedContentType Blockable => new MixedContentType("blockable");
            public static MixedContentType OptionallyBlockable => new MixedContentType("optionally-blockable");
            public static MixedContentType None => new MixedContentType("none");
        }

        /// <summary>
        /// The security level of a page or resource.
        /// </summary>
        public struct SecurityState : IEnum
        {
            public string Value { get; private set; }

            public SecurityState(string value)
            {
                Value = value;
            }

            public static SecurityState Unknown => new SecurityState("unknown");
            public static SecurityState Neutral => new SecurityState("neutral");
            public static SecurityState Insecure => new SecurityState("insecure");
            public static SecurityState Secure => new SecurityState("secure");
            public static SecurityState Info => new SecurityState("info");
        }

        /// <summary>
        /// An explanation of an factor contributing to the security state.
        /// </summary>
        public class SecurityStateExplanation
        {

            /// <summary>
            /// Security state representing the severity of the factor being explained.
            /// </summary>
            [JsonProperty("securityState")]
            public SecurityState SecurityState { get; set; }

            /// <summary>
            /// Title describing the type of factor.
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// Short phrase describing the type of factor.
            /// </summary>
            [JsonProperty("summary")]
            public string Summary { get; set; }

            /// <summary>
            /// Full text explanation of the factor.
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }

            /// <summary>
            /// The type of mixed content described by the explanation.
            /// </summary>
            [JsonProperty("mixedContentType")]
            public MixedContentType MixedContentType { get; set; }

            /// <summary>
            /// Page certificate.
            /// </summary>
            [JsonProperty("certificate")]
            public string[] Certificate { get; set; }

            /// <summary>
            /// Recommendations to fix any issues.
            /// </summary>
            [JsonProperty("recommendations")]
            public string[] Recommendations { get; set; }
        }

        /// <summary>
        /// Information about insecure content on the page.
        /// </summary>
        public class InsecureContentStatus
        {

            /// <summary>
            /// True if the page was loaded over HTTPS and ran mixed (HTTP) content such as scripts.
            /// </summary>
            [JsonProperty("ranMixedContent")]
            public bool RanMixedContent { get; set; }

            /// <summary>
            /// True if the page was loaded over HTTPS and displayed mixed (HTTP) content such as images.
            /// </summary>
            [JsonProperty("displayedMixedContent")]
            public bool DisplayedMixedContent { get; set; }

            /// <summary>
            /// True if the page was loaded over HTTPS and contained a form targeting an insecure url.
            /// </summary>
            [JsonProperty("containedMixedForm")]
            public bool ContainedMixedForm { get; set; }

            /// <summary>
            /// True if the page was loaded over HTTPS without certificate errors, and ran content such as
            /// scripts that were loaded with certificate errors.
            /// </summary>
            [JsonProperty("ranContentWithCertErrors")]
            public bool RanContentWithCertErrors { get; set; }

            /// <summary>
            /// True if the page was loaded over HTTPS without certificate errors, and displayed content
            /// such as images that were loaded with certificate errors.
            /// </summary>
            [JsonProperty("displayedContentWithCertErrors")]
            public bool DisplayedContentWithCertErrors { get; set; }

            /// <summary>
            /// Security state representing a page that ran insecure content.
            /// </summary>
            [JsonProperty("ranInsecureContentStyle")]
            public SecurityState RanInsecureContentStyle { get; set; }

            /// <summary>
            /// Security state representing a page that displayed insecure content.
            /// </summary>
            [JsonProperty("displayedInsecureContentStyle")]
            public SecurityState DisplayedInsecureContentStyle { get; set; }
        }

        /// <summary>
        /// The action to take when a certificate error occurs. continue will continue processing the
        /// request and cancel will cancel the request.
        /// </summary>
        public struct CertificateErrorAction : IEnum
        {
            public string Value { get; private set; }

            public CertificateErrorAction(string value)
            {
                Value = value;
            }

            public static CertificateErrorAction Continue => new CertificateErrorAction("continue");
            public static CertificateErrorAction Cancel => new CertificateErrorAction("cancel");
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

            [JsonProperty("registrationId")]
            public string RegistrationId { get; set; }

            [JsonProperty("scopeURL")]
            public string ScopeURL { get; set; }

            [JsonProperty("isDeleted")]
            public bool IsDeleted { get; set; }
        }

        public struct ServiceWorkerVersionRunningStatus : IEnum
        {
            public string Value { get; private set; }

            public ServiceWorkerVersionRunningStatus(string value)
            {
                Value = value;
            }

            public static ServiceWorkerVersionRunningStatus Stopped => new ServiceWorkerVersionRunningStatus("stopped");
            public static ServiceWorkerVersionRunningStatus Starting => new ServiceWorkerVersionRunningStatus("starting");
            public static ServiceWorkerVersionRunningStatus Running => new ServiceWorkerVersionRunningStatus("running");
            public static ServiceWorkerVersionRunningStatus Stopping => new ServiceWorkerVersionRunningStatus("stopping");
        }

        public struct ServiceWorkerVersionStatus : IEnum
        {
            public string Value { get; private set; }

            public ServiceWorkerVersionStatus(string value)
            {
                Value = value;
            }

            public static ServiceWorkerVersionStatus New => new ServiceWorkerVersionStatus("new");
            public static ServiceWorkerVersionStatus Installing => new ServiceWorkerVersionStatus("installing");
            public static ServiceWorkerVersionStatus Installed => new ServiceWorkerVersionStatus("installed");
            public static ServiceWorkerVersionStatus Activating => new ServiceWorkerVersionStatus("activating");
            public static ServiceWorkerVersionStatus Activated => new ServiceWorkerVersionStatus("activated");
            public static ServiceWorkerVersionStatus Redundant => new ServiceWorkerVersionStatus("redundant");
        }

        /// <summary>
        /// ServiceWorker version.
        /// </summary>
        public class ServiceWorkerVersion
        {

            [JsonProperty("versionId")]
            public string VersionId { get; set; }

            [JsonProperty("registrationId")]
            public string RegistrationId { get; set; }

            [JsonProperty("scriptURL")]
            public string ScriptURL { get; set; }

            [JsonProperty("runningStatus")]
            public ServiceWorkerVersionRunningStatus RunningStatus { get; set; }

            [JsonProperty("status")]
            public ServiceWorkerVersionStatus Status { get; set; }

            /// <summary>
            /// The Last-Modified header value of the main script.
            /// </summary>
            [JsonProperty("scriptLastModified")]
            public double ScriptLastModified { get; set; }

            /// <summary>
            /// The time at which the response headers of the main script were received from the server.
            /// For cached script it is the last time the cache entry was validated.
            /// </summary>
            [JsonProperty("scriptResponseTime")]
            public double ScriptResponseTime { get; set; }

            [JsonProperty("controlledClients")]
            public Target.TargetID[] ControlledClients { get; set; }

            [JsonProperty("targetId")]
            public Target.TargetID TargetId { get; set; }
        }

        /// <summary>
        /// ServiceWorker error message.
        /// </summary>
        public class ServiceWorkerErrorMessage
        {

            [JsonProperty("errorMessage")]
            public string ErrorMessage { get; set; }

            [JsonProperty("registrationId")]
            public string RegistrationId { get; set; }

            [JsonProperty("versionId")]
            public string VersionId { get; set; }

            [JsonProperty("sourceURL")]
            public string SourceURL { get; set; }

            [JsonProperty("lineNumber")]
            public int LineNumber { get; set; }

            [JsonProperty("columnNumber")]
            public int ColumnNumber { get; set; }
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
        public struct StorageType : IEnum
        {
            public string Value { get; private set; }

            public StorageType(string value)
            {
                Value = value;
            }

            public static StorageType Appcache => new StorageType("appcache");
            public static StorageType Cookies => new StorageType("cookies");
            public static StorageType FileSystems => new StorageType("file_systems");
            public static StorageType Indexeddb => new StorageType("indexeddb");
            public static StorageType LocalStorage => new StorageType("local_storage");
            public static StorageType ShaderCache => new StorageType("shader_cache");
            public static StorageType Websql => new StorageType("websql");
            public static StorageType ServiceWorkers => new StorageType("service_workers");
            public static StorageType CacheStorage => new StorageType("cache_storage");
            public static StorageType All => new StorageType("all");
            public static StorageType Other => new StorageType("other");
        }

        /// <summary>
        /// Usage for a storage type.
        /// </summary>
        public class UsageForType
        {

            /// <summary>
            /// Name of storage type.
            /// </summary>
            [JsonProperty("storageType")]
            public StorageType StorageType { get; set; }

            /// <summary>
            /// Storage usage (bytes).
            /// </summary>
            [JsonProperty("usage")]
            public double Usage { get; set; }
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

            /// <summary>
            /// PCI ID of the GPU vendor, if available; 0 otherwise.
            /// </summary>
            [JsonProperty("vendorId")]
            public double VendorId { get; set; }

            /// <summary>
            /// PCI ID of the GPU device, if available; 0 otherwise.
            /// </summary>
            [JsonProperty("deviceId")]
            public double DeviceId { get; set; }

            /// <summary>
            /// String description of the GPU vendor, if the PCI ID is not available.
            /// </summary>
            [JsonProperty("vendorString")]
            public string VendorString { get; set; }

            /// <summary>
            /// String description of the GPU device, if the PCI ID is not available.
            /// </summary>
            [JsonProperty("deviceString")]
            public string DeviceString { get; set; }
        }

        /// <summary>
        /// Provides information about the GPU(s) on the system.
        /// </summary>
        public class GPUInfo
        {

            /// <summary>
            /// The graphics devices on the system. Element 0 is the primary GPU.
            /// </summary>
            [JsonProperty("devices")]
            public GPUDevice[] Devices { get; set; }

            /// <summary>
            /// An optional dictionary of additional GPU related attributes.
            /// </summary>
            [JsonProperty("auxAttributes")]
            public object AuxAttributes { get; set; }

            /// <summary>
            /// An optional dictionary of graphics features and their status.
            /// </summary>
            [JsonProperty("featureStatus")]
            public object FeatureStatus { get; set; }

            /// <summary>
            /// An optional array of GPU driver bug workarounds.
            /// </summary>
            [JsonProperty("driverBugWorkarounds")]
            public string[] DriverBugWorkarounds { get; set; }
        }

        /// <summary>
        /// Represents process info.
        /// </summary>
        public class ProcessInfo
        {

            /// <summary>
            /// Specifies process type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Specifies process id.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Specifies cumulative CPU usage in seconds across all threads of the
            /// process since the process start.
            /// </summary>
            [JsonProperty("cpuTime")]
            public double CpuTime { get; set; }
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

        public struct TargetID : IAlias<string>
        {
            public string Value { get; private set; }

            public TargetID(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Unique identifier of attached debugging session.
        /// </summary>
        public struct SessionID : IAlias<string>
        {
            public string Value { get; private set; }

            public SessionID(string value)
            {
                Value = value;
            }

        }

        public struct BrowserContextID : IAlias<string>
        {
            public string Value { get; private set; }

            public BrowserContextID(string value)
            {
                Value = value;
            }

        }

        public class TargetInfo
        {

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Whether the target has an attached client.
            /// </summary>
            [JsonProperty("attached")]
            public bool Attached { get; set; }

            /// <summary>
            /// Opener target Id
            /// </summary>
            [JsonProperty("openerId")]
            public TargetID OpenerId { get; set; }

            [JsonProperty("browserContextId")]
            public BrowserContextID BrowserContextId { get; set; }
        }

        public class RemoteLocation
        {

            [JsonProperty("host")]
            public string Host { get; set; }

            [JsonProperty("port")]
            public int Port { get; set; }
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
        public class MemoryDumpConfig : Dictionary<string, object>
        {
        }

        public class TraceConfig
        {

            /// <summary>
            /// Controls how the trace buffer stores data.
            /// </summary>
            [JsonProperty("recordMode")]
            public string RecordMode { get; set; }

            /// <summary>
            /// Turns on JavaScript stack sampling.
            /// </summary>
            [JsonProperty("enableSampling")]
            public bool EnableSampling { get; set; }

            /// <summary>
            /// Turns on system tracing.
            /// </summary>
            [JsonProperty("enableSystrace")]
            public bool EnableSystrace { get; set; }

            /// <summary>
            /// Turns on argument filter.
            /// </summary>
            [JsonProperty("enableArgumentFilter")]
            public bool EnableArgumentFilter { get; set; }

            /// <summary>
            /// Included category filters.
            /// </summary>
            [JsonProperty("includedCategories")]
            public string[] IncludedCategories { get; set; }

            /// <summary>
            /// Excluded category filters.
            /// </summary>
            [JsonProperty("excludedCategories")]
            public string[] ExcludedCategories { get; set; }

            /// <summary>
            /// Configuration to synthesize the delays in tracing.
            /// </summary>
            [JsonProperty("syntheticDelays")]
            public string[] SyntheticDelays { get; set; }

            /// <summary>
            /// Configuration for memory dump triggers. Used only when "memory-infra" category is enabled.
            /// </summary>
            [JsonProperty("memoryDumpConfig")]
            public MemoryDumpConfig MemoryDumpConfig { get; set; }
        }

        /// <summary>
        /// Compression type to use for traces returned via streams.
        /// </summary>
        public struct StreamCompression : IEnum
        {
            public string Value { get; private set; }

            public StreamCompression(string value)
            {
                Value = value;
            }

            public static StreamCompression None => new StreamCompression("none");
            public static StreamCompression Gzip => new StreamCompression("gzip");
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
        public struct RequestId : IAlias<string>
        {
            public string Value { get; private set; }

            public RequestId(string value)
            {
                Value = value;
            }

        }

        /// <summary>
        /// Stages of the request to handle. Request will intercept before the request is
        /// sent. Response will intercept after the response is received (but before response
        /// body is received.
        /// </summary>
        public struct RequestStage : IEnum
        {
            public string Value { get; private set; }

            public RequestStage(string value)
            {
                Value = value;
            }

            public static RequestStage Request => new RequestStage("Request");
            public static RequestStage Response => new RequestStage("Response");
        }

        public class RequestPattern
        {

            /// <summary>
            /// Wildcards ('*' -&gt; zero or more, '?' -&gt; exactly one) are allowed. Escape character is
            /// backslash. Omitting is equivalent to "*".
            /// </summary>
            [JsonProperty("urlPattern")]
            public string UrlPattern { get; set; }

            /// <summary>
            /// If set, only requests for matching resource types will be intercepted.
            /// </summary>
            [JsonProperty("resourceType")]
            public Network.ResourceType ResourceType { get; set; }

            /// <summary>
            /// Stage at wich to begin intercepting requests. Default is Request.
            /// </summary>
            [JsonProperty("requestStage")]
            public RequestStage RequestStage { get; set; }
        }

        /// <summary>
        /// Response HTTP header entry
        /// </summary>
        public class HeaderEntry
        {

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Authorization challenge for HTTP status code 401 or 407.
        /// </summary>
        public class AuthChallenge
        {

            /// <summary>
            /// Source of the authentication challenge.
            /// </summary>
            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// Origin of the challenger.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// The authentication scheme used, such as basic or digest
            /// </summary>
            [JsonProperty("scheme")]
            public string Scheme { get; set; }

            /// <summary>
            /// The realm of the challenge. May be empty.
            /// </summary>
            [JsonProperty("realm")]
            public string Realm { get; set; }
        }

        /// <summary>
        /// Response to an AuthChallenge.
        /// </summary>
        public class AuthChallengeResponse
        {

            /// <summary>
            /// The decision on what to do in response to the authorization challenge.  Default means
            /// deferring to the default behavior of the net stack, which will likely either the Cancel
            /// authentication or display a popup dialog box.
            /// </summary>
            [JsonProperty("response")]
            public string Response { get; set; }

            /// <summary>
            /// The username to provide, possibly empty. Should only be set if response is
            /// ProvideCredentials.
            /// </summary>
            [JsonProperty("username")]
            public string Username { get; set; }

            /// <summary>
            /// The password to provide, possibly empty. Should only be set if response is
            /// ProvideCredentials.
            /// </summary>
            [JsonProperty("password")]
            public string Password { get; set; }
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
