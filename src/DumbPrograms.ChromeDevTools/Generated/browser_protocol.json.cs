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

            /// <summary>
            /// Identifier of the node to get the partial accessibility tree for.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node to get the partial accessibility tree for.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper to get the partial accessibility tree for.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }

            /// <summary>
            /// Whether to fetch this nodes ancestors, siblings and children. Defaults to true.
            /// </summary>
            [JsonProperty("fetchRelatives")]
            public bool FetchRelatives { get; set; }
        }

        public class GetPartialAXTreeResponse
        {

            /// <summary>
            /// The `Accessibility.AXNode` for this DOM node, if it exists, plus its ancestors, siblings and
            /// children, if requested.
            /// </summary>
            [JsonProperty("nodes")]
            public AXNode[] Nodes { get; set; }
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

            [JsonProperty("nodes")]
            public AXNode[] Nodes { get; set; }
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

            /// <summary>
            /// Id of animation.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class GetCurrentTimeResponse
        {

            /// <summary>
            /// Current time of the page.
            /// </summary>
            [JsonProperty("currentTime")]
            public double CurrentTime { get; set; }
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

            /// <summary>
            /// Playback rate for animations on page.
            /// </summary>
            [JsonProperty("playbackRate")]
            public double PlaybackRate { get; set; }
        }

        /// <summary>
        /// Releases a set of animations to no longer be manipulated.
        /// </summary>
        public class ReleaseAnimationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.releaseAnimations";

            /// <summary>
            /// List of animation ids to seek.
            /// </summary>
            [JsonProperty("animations")]
            public string[] Animations { get; set; }
        }

        /// <summary>
        /// Gets the remote object of the Animation.
        /// </summary>
        public class ResolveAnimationCommand : ICommand<ResolveAnimationResponse>
        {
            string ICommand.Name { get; } = "Animation.resolveAnimation";

            /// <summary>
            /// Animation id.
            /// </summary>
            [JsonProperty("animationId")]
            public string AnimationId { get; set; }
        }

        public class ResolveAnimationResponse
        {

            /// <summary>
            /// Corresponding remote object.
            /// </summary>
            [JsonProperty("remoteObject")]
            public Runtime.RemoteObject RemoteObject { get; set; }
        }

        /// <summary>
        /// Seek a set of animations to a particular time within each animation.
        /// </summary>
        public class SeekAnimationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.seekAnimations";

            /// <summary>
            /// List of animation ids to seek.
            /// </summary>
            [JsonProperty("animations")]
            public string[] Animations { get; set; }

            /// <summary>
            /// Set the current time of each animation.
            /// </summary>
            [JsonProperty("currentTime")]
            public double CurrentTime { get; set; }
        }

        /// <summary>
        /// Sets the paused state of a set of animations.
        /// </summary>
        public class SetPausedCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setPaused";

            /// <summary>
            /// Animations to set the pause state of.
            /// </summary>
            [JsonProperty("animations")]
            public string[] Animations { get; set; }

            /// <summary>
            /// Paused state to set to.
            /// </summary>
            [JsonProperty("paused")]
            public bool Paused { get; set; }
        }

        /// <summary>
        /// Sets the playback rate of the document timeline.
        /// </summary>
        public class SetPlaybackRateCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setPlaybackRate";

            /// <summary>
            /// Playback rate for animations on page
            /// </summary>
            [JsonProperty("playbackRate")]
            public double PlaybackRate { get; set; }
        }

        /// <summary>
        /// Sets the timing of an animation node.
        /// </summary>
        public class SetTimingCommand : ICommand
        {
            string ICommand.Name { get; } = "Animation.setTiming";

            /// <summary>
            /// Animation id.
            /// </summary>
            [JsonProperty("animationId")]
            public string AnimationId { get; set; }

            /// <summary>
            /// Duration of the animation.
            /// </summary>
            [JsonProperty("duration")]
            public double Duration { get; set; }

            /// <summary>
            /// Delay of the animation.
            /// </summary>
            [JsonProperty("delay")]
            public double Delay { get; set; }
        }

        /// <summary>
        /// Event for when an animation has been cancelled.
        /// </summary>
        public class AnimationCanceledEvent : ICommand
        {
            string ICommand.Name { get; } = "Animation.animationCanceled";

            /// <summary>
            /// Id of the animation that was cancelled.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        /// <summary>
        /// Event for each animation that has been created.
        /// </summary>
        public class AnimationCreatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Animation.animationCreated";

            /// <summary>
            /// Id of the animation that was created.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        /// <summary>
        /// Event for animation that has been started.
        /// </summary>
        public class AnimationStartedEvent : ICommand
        {
            string ICommand.Name { get; } = "Animation.animationStarted";

            /// <summary>
            /// Animation that was started.
            /// </summary>
            [JsonProperty("animation")]
            public Animation Animation { get; set; }
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

            /// <summary>
            /// Identifier of the frame containing document whose application cache is retrieved.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }
        }

        public class GetApplicationCacheForFrameResponse
        {

            /// <summary>
            /// Relevant application cache data for the document in given frame.
            /// </summary>
            [JsonProperty("applicationCache")]
            public ApplicationCache ApplicationCache { get; set; }
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

            /// <summary>
            /// Array of frame identifiers with manifest urls for each frame containing a document
            /// associated with some application cache.
            /// </summary>
            [JsonProperty("frameIds")]
            public FrameWithManifest[] FrameIds { get; set; }
        }

        /// <summary>
        /// Returns manifest URL for document in the given frame.
        /// </summary>
        public class GetManifestForFrameCommand : ICommand<GetManifestForFrameResponse>
        {
            string ICommand.Name { get; } = "ApplicationCache.getManifestForFrame";

            /// <summary>
            /// Identifier of the frame containing document whose manifest is retrieved.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }
        }

        public class GetManifestForFrameResponse
        {

            /// <summary>
            /// Manifest URL for document in the given frame.
            /// </summary>
            [JsonProperty("manifestURL")]
            public string ManifestURL { get; set; }
        }

        public class ApplicationCacheStatusUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "ApplicationCache.applicationCacheStatusUpdated";

            /// <summary>
            /// Identifier of the frame containing document whose application cache updated status.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// Manifest URL.
            /// </summary>
            [JsonProperty("manifestURL")]
            public string ManifestURL { get; set; }

            /// <summary>
            /// Updated application cache status.
            /// </summary>
            [JsonProperty("status")]
            public int Status { get; set; }
        }

        public class NetworkStateUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "ApplicationCache.networkStateUpdated";

            [JsonProperty("isNowOnline")]
            public bool IsNowOnline { get; set; }
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

            /// <summary>
            /// Identifier of the network request to get content for.
            /// </summary>
            [JsonProperty("requestId")]
            public Network.RequestId RequestId { get; set; }

            /// <summary>
            /// The encoding to use.
            /// </summary>
            [JsonProperty("encoding")]
            public string Encoding { get; set; }

            /// <summary>
            /// The quality of the encoding (0-1). (defaults to 1)
            /// </summary>
            [JsonProperty("quality")]
            public double Quality { get; set; }

            /// <summary>
            /// Whether to only return the size information (defaults to false).
            /// </summary>
            [JsonProperty("sizeOnly")]
            public bool SizeOnly { get; set; }
        }

        public class GetEncodedResponseResponse
        {

            /// <summary>
            /// The encoded body as a base64 string. Omitted if sizeOnly is true.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }

            /// <summary>
            /// Size before re-encoding.
            /// </summary>
            [JsonProperty("originalSize")]
            public int OriginalSize { get; set; }

            /// <summary>
            /// Size after re-encoding.
            /// </summary>
            [JsonProperty("encodedSize")]
            public int EncodedSize { get; set; }
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

            [JsonProperty("origin")]
            public string Origin { get; set; }

            [JsonProperty("permissions")]
            public PermissionType[] Permissions { get; set; }

            /// <summary>
            /// BrowserContext to override permissions. When omitted, default browser context is used.
            /// </summary>
            [JsonProperty("browserContextId")]
            public Target.BrowserContextID BrowserContextId { get; set; }
        }

        /// <summary>
        /// Reset all permission management for all origins.
        /// </summary>
        public class ResetPermissionsCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.resetPermissions";

            /// <summary>
            /// BrowserContext to reset permissions. When omitted, default browser context is used.
            /// </summary>
            [JsonProperty("browserContextId")]
            public Target.BrowserContextID BrowserContextId { get; set; }
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

            /// <summary>
            /// Protocol version.
            /// </summary>
            [JsonProperty("protocolVersion")]
            public string ProtocolVersion { get; set; }

            /// <summary>
            /// Product name.
            /// </summary>
            [JsonProperty("product")]
            public string Product { get; set; }

            /// <summary>
            /// Product revision.
            /// </summary>
            [JsonProperty("revision")]
            public string Revision { get; set; }

            /// <summary>
            /// User-Agent.
            /// </summary>
            [JsonProperty("userAgent")]
            public string UserAgent { get; set; }

            /// <summary>
            /// V8 version.
            /// </summary>
            [JsonProperty("jsVersion")]
            public string JsVersion { get; set; }
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

            /// <summary>
            /// Commandline parameters
            /// </summary>
            [JsonProperty("arguments")]
            public string[] Arguments { get; set; }
        }

        /// <summary>
        /// Get Chrome histograms.
        /// </summary>
        public class GetHistogramsCommand : ICommand<GetHistogramsResponse>
        {
            string ICommand.Name { get; } = "Browser.getHistograms";

            /// <summary>
            /// Requested substring in name. Only histograms which have query as a
            /// substring in their name are extracted. An empty or absent query returns
            /// all histograms.
            /// </summary>
            [JsonProperty("query")]
            public string Query { get; set; }

            /// <summary>
            /// If true, retrieve delta since last call.
            /// </summary>
            [JsonProperty("delta")]
            public bool Delta { get; set; }
        }

        public class GetHistogramsResponse
        {

            /// <summary>
            /// Histograms.
            /// </summary>
            [JsonProperty("histograms")]
            public Histogram[] Histograms { get; set; }
        }

        /// <summary>
        /// Get a Chrome histogram by name.
        /// </summary>
        public class GetHistogramCommand : ICommand<GetHistogramResponse>
        {
            string ICommand.Name { get; } = "Browser.getHistogram";

            /// <summary>
            /// Requested histogram name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// If true, retrieve delta since last call.
            /// </summary>
            [JsonProperty("delta")]
            public bool Delta { get; set; }
        }

        public class GetHistogramResponse
        {

            /// <summary>
            /// Histogram.
            /// </summary>
            [JsonProperty("histogram")]
            public Histogram Histogram { get; set; }
        }

        /// <summary>
        /// Get position and size of the browser window.
        /// </summary>
        public class GetWindowBoundsCommand : ICommand<GetWindowBoundsResponse>
        {
            string ICommand.Name { get; } = "Browser.getWindowBounds";

            /// <summary>
            /// Browser window id.
            /// </summary>
            [JsonProperty("windowId")]
            public WindowID WindowId { get; set; }
        }

        public class GetWindowBoundsResponse
        {

            /// <summary>
            /// Bounds information of the window. When window state is 'minimized', the restored window
            /// position and size are returned.
            /// </summary>
            [JsonProperty("bounds")]
            public Bounds Bounds { get; set; }
        }

        /// <summary>
        /// Get the browser window that contains the devtools target.
        /// </summary>
        public class GetWindowForTargetCommand : ICommand<GetWindowForTargetResponse>
        {
            string ICommand.Name { get; } = "Browser.getWindowForTarget";

            /// <summary>
            /// Devtools agent host id. If called as a part of the session, associated targetId is used.
            /// </summary>
            [JsonProperty("targetId")]
            public Target.TargetID TargetId { get; set; }
        }

        public class GetWindowForTargetResponse
        {

            /// <summary>
            /// Browser window id.
            /// </summary>
            [JsonProperty("windowId")]
            public WindowID WindowId { get; set; }

            /// <summary>
            /// Bounds information of the window. When window state is 'minimized', the restored window
            /// position and size are returned.
            /// </summary>
            [JsonProperty("bounds")]
            public Bounds Bounds { get; set; }
        }

        /// <summary>
        /// Set position and/or size of the browser window.
        /// </summary>
        public class SetWindowBoundsCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.setWindowBounds";

            /// <summary>
            /// Browser window id.
            /// </summary>
            [JsonProperty("windowId")]
            public WindowID WindowId { get; set; }

            /// <summary>
            /// New window bounds. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined
            /// with 'left', 'top', 'width' or 'height'. Leaves unspecified fields unchanged.
            /// </summary>
            [JsonProperty("bounds")]
            public Bounds Bounds { get; set; }
        }

        /// <summary>
        /// Set dock tile details, platform-specific.
        /// </summary>
        public class SetDockTileCommand : ICommand
        {
            string ICommand.Name { get; } = "Browser.setDockTile";

            [JsonProperty("badgeLabel")]
            public string BadgeLabel { get; set; }

            /// <summary>
            /// Png encoded image.
            /// </summary>
            [JsonProperty("image")]
            public string Image { get; set; }
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

            /// <summary>
            /// The css style sheet identifier where a new rule should be inserted.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            /// <summary>
            /// The text of a new rule.
            /// </summary>
            [JsonProperty("ruleText")]
            public string RuleText { get; set; }

            /// <summary>
            /// Text position of a new rule in the target style sheet.
            /// </summary>
            [JsonProperty("location")]
            public SourceRange Location { get; set; }
        }

        public class AddRuleResponse
        {

            /// <summary>
            /// The newly created rule.
            /// </summary>
            [JsonProperty("rule")]
            public CSSRule Rule { get; set; }
        }

        /// <summary>
        /// Returns all class names from specified stylesheet.
        /// </summary>
        public class CollectClassNamesCommand : ICommand<CollectClassNamesResponse>
        {
            string ICommand.Name { get; } = "CSS.collectClassNames";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }
        }

        public class CollectClassNamesResponse
        {

            /// <summary>
            /// Class name list.
            /// </summary>
            [JsonProperty("classNames")]
            public string[] ClassNames { get; set; }
        }

        /// <summary>
        /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
        /// </summary>
        public class CreateStyleSheetCommand : ICommand<CreateStyleSheetResponse>
        {
            string ICommand.Name { get; } = "CSS.createStyleSheet";

            /// <summary>
            /// Identifier of the frame where "via-inspector" stylesheet should be created.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }
        }

        public class CreateStyleSheetResponse
        {

            /// <summary>
            /// Identifier of the created "via-inspector" stylesheet.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }
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

            /// <summary>
            /// The element id for which to force the pseudo state.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            /// <summary>
            /// Element pseudo classes to force when computing the element's style.
            /// </summary>
            [JsonProperty("forcedPseudoClasses")]
            public string[] ForcedPseudoClasses { get; set; }
        }

        public class GetBackgroundColorsCommand : ICommand<GetBackgroundColorsResponse>
        {
            string ICommand.Name { get; } = "CSS.getBackgroundColors";

            /// <summary>
            /// Id of the node to get background colors for.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetBackgroundColorsResponse
        {

            /// <summary>
            /// The range of background colors behind this element, if it contains any visible text. If no
            /// visible text is present, this will be undefined. In the case of a flat background color,
            /// this will consist of simply that color. In the case of a gradient, this will consist of each
            /// of the color stops. For anything more complicated, this will be an empty array. Images will
            /// be ignored (as if the image had failed to load).
            /// </summary>
            [JsonProperty("backgroundColors")]
            public string[] BackgroundColors { get; set; }

            /// <summary>
            /// The computed font size for this node, as a CSS computed value string (e.g. '12px').
            /// </summary>
            [JsonProperty("computedFontSize")]
            public string ComputedFontSize { get; set; }

            /// <summary>
            /// The computed font weight for this node, as a CSS computed value string (e.g. 'normal' or
            /// '100').
            /// </summary>
            [JsonProperty("computedFontWeight")]
            public string ComputedFontWeight { get; set; }
        }

        /// <summary>
        /// Returns the computed style for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetComputedStyleForNodeCommand : ICommand<GetComputedStyleForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getComputedStyleForNode";

            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetComputedStyleForNodeResponse
        {

            /// <summary>
            /// Computed style for the specified DOM node.
            /// </summary>
            [JsonProperty("computedStyle")]
            public CSSComputedStyleProperty[] ComputedStyle { get; set; }
        }

        /// <summary>
        /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
        /// attributes) for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetInlineStylesForNodeCommand : ICommand<GetInlineStylesForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getInlineStylesForNode";

            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetInlineStylesForNodeResponse
        {

            /// <summary>
            /// Inline style for the specified DOM node.
            /// </summary>
            [JsonProperty("inlineStyle")]
            public CSSStyle InlineStyle { get; set; }

            /// <summary>
            /// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
            /// </summary>
            [JsonProperty("attributesStyle")]
            public CSSStyle AttributesStyle { get; set; }
        }

        /// <summary>
        /// Returns requested styles for a DOM node identified by `nodeId`.
        /// </summary>
        public class GetMatchedStylesForNodeCommand : ICommand<GetMatchedStylesForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getMatchedStylesForNode";

            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetMatchedStylesForNodeResponse
        {

            /// <summary>
            /// Inline style for the specified DOM node.
            /// </summary>
            [JsonProperty("inlineStyle")]
            public CSSStyle InlineStyle { get; set; }

            /// <summary>
            /// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
            /// </summary>
            [JsonProperty("attributesStyle")]
            public CSSStyle AttributesStyle { get; set; }

            /// <summary>
            /// CSS rules matching this node, from all applicable stylesheets.
            /// </summary>
            [JsonProperty("matchedCSSRules")]
            public RuleMatch[] MatchedCSSRules { get; set; }

            /// <summary>
            /// Pseudo style matches for this node.
            /// </summary>
            [JsonProperty("pseudoElements")]
            public PseudoElementMatches[] PseudoElements { get; set; }

            /// <summary>
            /// A chain of inherited styles (from the immediate node parent up to the DOM tree root).
            /// </summary>
            [JsonProperty("inherited")]
            public InheritedStyleEntry[] Inherited { get; set; }

            /// <summary>
            /// A list of CSS keyframed animations matching this node.
            /// </summary>
            [JsonProperty("cssKeyframesRules")]
            public CSSKeyframesRule[] CssKeyframesRules { get; set; }
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

            [JsonProperty("medias")]
            public CSSMedia[] Medias { get; set; }
        }

        /// <summary>
        /// Requests information about platform fonts which we used to render child TextNodes in the given
        /// node.
        /// </summary>
        public class GetPlatformFontsForNodeCommand : ICommand<GetPlatformFontsForNodeResponse>
        {
            string ICommand.Name { get; } = "CSS.getPlatformFontsForNode";

            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetPlatformFontsForNodeResponse
        {

            /// <summary>
            /// Usage statistics for every employed platform font.
            /// </summary>
            [JsonProperty("fonts")]
            public PlatformFontUsage[] Fonts { get; set; }
        }

        /// <summary>
        /// Returns the current textual content for a stylesheet.
        /// </summary>
        public class GetStyleSheetTextCommand : ICommand<GetStyleSheetTextResponse>
        {
            string ICommand.Name { get; } = "CSS.getStyleSheetText";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }
        }

        public class GetStyleSheetTextResponse
        {

            /// <summary>
            /// The stylesheet text.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        /// <summary>
        /// Find a rule with the given active property for the given node and set the new value for this
        /// property
        /// </summary>
        public class SetEffectivePropertyValueForNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "CSS.setEffectivePropertyValueForNode";

            /// <summary>
            /// The element id for which to set property.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            [JsonProperty("propertyName")]
            public string PropertyName { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Modifies the keyframe rule key text.
        /// </summary>
        public class SetKeyframeKeyCommand : ICommand<SetKeyframeKeyResponse>
        {
            string ICommand.Name { get; } = "CSS.setKeyframeKey";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            [JsonProperty("range")]
            public SourceRange Range { get; set; }

            [JsonProperty("keyText")]
            public string KeyText { get; set; }
        }

        public class SetKeyframeKeyResponse
        {

            /// <summary>
            /// The resulting key text after modification.
            /// </summary>
            [JsonProperty("keyText")]
            public Value KeyText { get; set; }
        }

        /// <summary>
        /// Modifies the rule selector.
        /// </summary>
        public class SetMediaTextCommand : ICommand<SetMediaTextResponse>
        {
            string ICommand.Name { get; } = "CSS.setMediaText";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            [JsonProperty("range")]
            public SourceRange Range { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public class SetMediaTextResponse
        {

            /// <summary>
            /// The resulting CSS media rule after modification.
            /// </summary>
            [JsonProperty("media")]
            public CSSMedia Media { get; set; }
        }

        /// <summary>
        /// Modifies the rule selector.
        /// </summary>
        public class SetRuleSelectorCommand : ICommand<SetRuleSelectorResponse>
        {
            string ICommand.Name { get; } = "CSS.setRuleSelector";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            [JsonProperty("range")]
            public SourceRange Range { get; set; }

            [JsonProperty("selector")]
            public string Selector { get; set; }
        }

        public class SetRuleSelectorResponse
        {

            /// <summary>
            /// The resulting selector list after modification.
            /// </summary>
            [JsonProperty("selectorList")]
            public SelectorList SelectorList { get; set; }
        }

        /// <summary>
        /// Sets the new stylesheet text.
        /// </summary>
        public class SetStyleSheetTextCommand : ICommand<SetStyleSheetTextResponse>
        {
            string ICommand.Name { get; } = "CSS.setStyleSheetText";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public class SetStyleSheetTextResponse
        {

            /// <summary>
            /// URL of source map associated with script (if any).
            /// </summary>
            [JsonProperty("sourceMapURL")]
            public string SourceMapURL { get; set; }
        }

        /// <summary>
        /// Applies specified style edits one after another in the given order.
        /// </summary>
        public class SetStyleTextsCommand : ICommand<SetStyleTextsResponse>
        {
            string ICommand.Name { get; } = "CSS.setStyleTexts";

            [JsonProperty("edits")]
            public StyleDeclarationEdit[] Edits { get; set; }
        }

        public class SetStyleTextsResponse
        {

            /// <summary>
            /// The resulting styles after modification.
            /// </summary>
            [JsonProperty("styles")]
            public CSSStyle[] Styles { get; set; }
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

            [JsonProperty("ruleUsage")]
            public RuleUsage[] RuleUsage { get; set; }
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

            [JsonProperty("coverage")]
            public RuleUsage[] Coverage { get; set; }
        }

        /// <summary>
        /// Fires whenever a web font is updated.  A non-empty font parameter indicates a successfully loaded
        /// web font
        /// </summary>
        public class FontsUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "CSS.fontsUpdated";

            /// <summary>
            /// The web font that has loaded.
            /// </summary>
            [JsonProperty("font")]
            public FontFace Font { get; set; }
        }

        /// <summary>
        /// Fires whenever a MediaQuery result changes (for example, after a browser window has been
        /// resized.) The current implementation considers only viewport-dependent media features.
        /// </summary>
        public class MediaQueryResultChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "CSS.mediaQueryResultChanged";
        }

        /// <summary>
        /// Fired whenever an active document stylesheet is added.
        /// </summary>
        public class StyleSheetAddedEvent : ICommand
        {
            string ICommand.Name { get; } = "CSS.styleSheetAdded";

            /// <summary>
            /// Added stylesheet metainfo.
            /// </summary>
            [JsonProperty("header")]
            public CSSStyleSheetHeader Header { get; set; }
        }

        /// <summary>
        /// Fired whenever a stylesheet is changed as a result of the client operation.
        /// </summary>
        public class StyleSheetChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "CSS.styleSheetChanged";

            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }
        }

        /// <summary>
        /// Fired whenever an active document stylesheet is removed.
        /// </summary>
        public class StyleSheetRemovedEvent : ICommand
        {
            string ICommand.Name { get; } = "CSS.styleSheetRemoved";

            /// <summary>
            /// Identifier of the removed stylesheet.
            /// </summary>
            [JsonProperty("styleSheetId")]
            public StyleSheetId StyleSheetId { get; set; }
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

            /// <summary>
            /// Id of cache for deletion.
            /// </summary>
            [JsonProperty("cacheId")]
            public CacheId CacheId { get; set; }
        }

        /// <summary>
        /// Deletes a cache entry.
        /// </summary>
        public class DeleteEntryCommand : ICommand
        {
            string ICommand.Name { get; } = "CacheStorage.deleteEntry";

            /// <summary>
            /// Id of cache where the entry will be deleted.
            /// </summary>
            [JsonProperty("cacheId")]
            public CacheId CacheId { get; set; }

            /// <summary>
            /// URL spec of the request.
            /// </summary>
            [JsonProperty("request")]
            public string Request { get; set; }
        }

        /// <summary>
        /// Requests cache names.
        /// </summary>
        public class RequestCacheNamesCommand : ICommand<RequestCacheNamesResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestCacheNames";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }
        }

        public class RequestCacheNamesResponse
        {

            /// <summary>
            /// Caches for the security origin.
            /// </summary>
            [JsonProperty("caches")]
            public Cache[] Caches { get; set; }
        }

        /// <summary>
        /// Fetches cache entry.
        /// </summary>
        public class RequestCachedResponseCommand : ICommand<RequestCachedResponseResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestCachedResponse";

            /// <summary>
            /// Id of cache that contains the entry.
            /// </summary>
            [JsonProperty("cacheId")]
            public CacheId CacheId { get; set; }

            /// <summary>
            /// URL spec of the request.
            /// </summary>
            [JsonProperty("requestURL")]
            public string RequestURL { get; set; }
        }

        public class RequestCachedResponseResponse
        {

            /// <summary>
            /// Response read from the cache.
            /// </summary>
            [JsonProperty("response")]
            public CachedResponse Response { get; set; }
        }

        /// <summary>
        /// Requests data from cache.
        /// </summary>
        public class RequestEntriesCommand : ICommand<RequestEntriesResponse>
        {
            string ICommand.Name { get; } = "CacheStorage.requestEntries";

            /// <summary>
            /// ID of cache to get entries from.
            /// </summary>
            [JsonProperty("cacheId")]
            public CacheId CacheId { get; set; }

            /// <summary>
            /// Number of records to skip.
            /// </summary>
            [JsonProperty("skipCount")]
            public int SkipCount { get; set; }

            /// <summary>
            /// Number of records to fetch.
            /// </summary>
            [JsonProperty("pageSize")]
            public int PageSize { get; set; }

            /// <summary>
            /// If present, only return the entries containing this substring in the path
            /// </summary>
            [JsonProperty("pathFilter")]
            public string PathFilter { get; set; }
        }

        public class RequestEntriesResponse
        {

            /// <summary>
            /// Array of object store data entries.
            /// </summary>
            [JsonProperty("cacheDataEntries")]
            public DataEntry[] CacheDataEntries { get; set; }

            /// <summary>
            /// If true, there are more entries to fetch in the given range.
            /// </summary>
            [JsonProperty("hasMore")]
            public bool HasMore { get; set; }
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

            [JsonProperty("presentationUrl")]
            public string PresentationUrl { get; set; }
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

            [JsonProperty("sinkName")]
            public string SinkName { get; set; }
        }

        /// <summary>
        /// Starts mirroring the tab to the sink.
        /// </summary>
        public class StartTabMirroringCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.startTabMirroring";

            [JsonProperty("sinkName")]
            public string SinkName { get; set; }
        }

        /// <summary>
        /// Stops the active Cast session on the sink.
        /// </summary>
        public class StopCastingCommand : ICommand
        {
            string ICommand.Name { get; } = "Cast.stopCasting";

            [JsonProperty("sinkName")]
            public string SinkName { get; set; }
        }

        /// <summary>
        /// This is fired whenever the list of available sinks changes. A sink is a
        /// device or a software surface that you can cast to.
        /// </summary>
        public class SinksUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Cast.sinksUpdated";

            [JsonProperty("sinkNames")]
            public string[] SinkNames { get; set; }
        }

        /// <summary>
        /// This is fired whenever the outstanding issue/error message changes.
        /// |issueMessage| is empty if there is no issue.
        /// </summary>
        public class IssueUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Cast.issueUpdated";

            [JsonProperty("issueMessage")]
            public string IssueMessage { get; set; }
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

            /// <summary>
            /// Id of the node to collect class names.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        public class CollectClassNamesFromSubtreeResponse
        {

            /// <summary>
            /// Class name list.
            /// </summary>
            [JsonProperty("classNames")]
            public string[] ClassNames { get; set; }
        }

        /// <summary>
        /// Creates a deep copy of the specified node and places it into the target container before the
        /// given anchor.
        /// </summary>
        public class CopyToCommand : ICommand<CopyToResponse>
        {
            string ICommand.Name { get; } = "DOM.copyTo";

            /// <summary>
            /// Id of the node to copy.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Id of the element to drop the copy into.
            /// </summary>
            [JsonProperty("targetNodeId")]
            public NodeId TargetNodeId { get; set; }

            /// <summary>
            /// Drop the copy before this node (if absent, the copy becomes the last child of
            /// `targetNodeId`).
            /// </summary>
            [JsonProperty("insertBeforeNodeId")]
            public NodeId InsertBeforeNodeId { get; set; }
        }

        public class CopyToResponse
        {

            /// <summary>
            /// Id of the node clone.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Describes node given its id, does not require domain to be enabled. Does not start tracking any
        /// objects, can be used for automation.
        /// </summary>
        public class DescribeNodeCommand : ICommand<DescribeNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.describeNode";

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }

            /// <summary>
            /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
            /// entire subtree or provide an integer larger than 0.
            /// </summary>
            [JsonProperty("depth")]
            public int Depth { get; set; }

            /// <summary>
            /// Whether or not iframes and shadow roots should be traversed when returning the subtree
            /// (default is false).
            /// </summary>
            [JsonProperty("pierce")]
            public bool Pierce { get; set; }
        }

        public class DescribeNodeResponse
        {

            /// <summary>
            /// Node description.
            /// </summary>
            [JsonProperty("node")]
            public Node Node { get; set; }
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

            /// <summary>
            /// Unique search session identifier.
            /// </summary>
            [JsonProperty("searchId")]
            public string SearchId { get; set; }
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

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        /// <summary>
        /// Returns attributes for the specified node.
        /// </summary>
        public class GetAttributesCommand : ICommand<GetAttributesResponse>
        {
            string ICommand.Name { get; } = "DOM.getAttributes";

            /// <summary>
            /// Id of the node to retrieve attibutes for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        public class GetAttributesResponse
        {

            /// <summary>
            /// An interleaved array of node attribute names and values.
            /// </summary>
            [JsonProperty("attributes")]
            public string[] Attributes { get; set; }
        }

        /// <summary>
        /// Returns boxes for the given node.
        /// </summary>
        public class GetBoxModelCommand : ICommand<GetBoxModelResponse>
        {
            string ICommand.Name { get; } = "DOM.getBoxModel";

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class GetBoxModelResponse
        {

            /// <summary>
            /// Box model for the node.
            /// </summary>
            [JsonProperty("model")]
            public BoxModel Model { get; set; }
        }

        /// <summary>
        /// Returns quads that describe node position on the page. This method
        /// might return multiple quads for inline nodes.
        /// </summary>
        public class GetContentQuadsCommand : ICommand<GetContentQuadsResponse>
        {
            string ICommand.Name { get; } = "DOM.getContentQuads";

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class GetContentQuadsResponse
        {

            /// <summary>
            /// Quads that describe node layout relative to viewport.
            /// </summary>
            [JsonProperty("quads")]
            public Quad[] Quads { get; set; }
        }

        /// <summary>
        /// Returns the root DOM node (and optionally the subtree) to the caller.
        /// </summary>
        public class GetDocumentCommand : ICommand<GetDocumentResponse>
        {
            string ICommand.Name { get; } = "DOM.getDocument";

            /// <summary>
            /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
            /// entire subtree or provide an integer larger than 0.
            /// </summary>
            [JsonProperty("depth")]
            public int Depth { get; set; }

            /// <summary>
            /// Whether or not iframes and shadow roots should be traversed when returning the subtree
            /// (default is false).
            /// </summary>
            [JsonProperty("pierce")]
            public bool Pierce { get; set; }
        }

        public class GetDocumentResponse
        {

            /// <summary>
            /// Resulting node.
            /// </summary>
            [JsonProperty("root")]
            public Node Root { get; set; }
        }

        /// <summary>
        /// Returns the root DOM node (and optionally the subtree) to the caller.
        /// </summary>
        public class GetFlattenedDocumentCommand : ICommand<GetFlattenedDocumentResponse>
        {
            string ICommand.Name { get; } = "DOM.getFlattenedDocument";

            /// <summary>
            /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
            /// entire subtree or provide an integer larger than 0.
            /// </summary>
            [JsonProperty("depth")]
            public int Depth { get; set; }

            /// <summary>
            /// Whether or not iframes and shadow roots should be traversed when returning the subtree
            /// (default is false).
            /// </summary>
            [JsonProperty("pierce")]
            public bool Pierce { get; set; }
        }

        public class GetFlattenedDocumentResponse
        {

            /// <summary>
            /// Resulting node.
            /// </summary>
            [JsonProperty("nodes")]
            public Node[] Nodes { get; set; }
        }

        /// <summary>
        /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
        /// either returned or not.
        /// </summary>
        public class GetNodeForLocationCommand : ICommand<GetNodeForLocationResponse>
        {
            string ICommand.Name { get; } = "DOM.getNodeForLocation";

            /// <summary>
            /// X coordinate.
            /// </summary>
            [JsonProperty("x")]
            public int X { get; set; }

            /// <summary>
            /// Y coordinate.
            /// </summary>
            [JsonProperty("y")]
            public int Y { get; set; }

            /// <summary>
            /// False to skip to the nearest non-UA shadow root ancestor (default: false).
            /// </summary>
            [JsonProperty("includeUserAgentShadowDOM")]
            public bool IncludeUserAgentShadowDOM { get; set; }
        }

        public class GetNodeForLocationResponse
        {

            /// <summary>
            /// Resulting node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// Id of the node at given coordinates, only when enabled.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Returns node's HTML markup.
        /// </summary>
        public class GetOuterHTMLCommand : ICommand<GetOuterHTMLResponse>
        {
            string ICommand.Name { get; } = "DOM.getOuterHTML";

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class GetOuterHTMLResponse
        {

            /// <summary>
            /// Outer HTML markup.
            /// </summary>
            [JsonProperty("outerHTML")]
            public string OuterHTML { get; set; }
        }

        /// <summary>
        /// Returns the id of the nearest ancestor that is a relayout boundary.
        /// </summary>
        public class GetRelayoutBoundaryCommand : ICommand<GetRelayoutBoundaryResponse>
        {
            string ICommand.Name { get; } = "DOM.getRelayoutBoundary";

            /// <summary>
            /// Id of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        public class GetRelayoutBoundaryResponse
        {

            /// <summary>
            /// Relayout boundary node id for the given node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
        /// identifier.
        /// </summary>
        public class GetSearchResultsCommand : ICommand<GetSearchResultsResponse>
        {
            string ICommand.Name { get; } = "DOM.getSearchResults";

            /// <summary>
            /// Unique search session identifier.
            /// </summary>
            [JsonProperty("searchId")]
            public string SearchId { get; set; }

            /// <summary>
            /// Start index of the search result to be returned.
            /// </summary>
            [JsonProperty("fromIndex")]
            public int FromIndex { get; set; }

            /// <summary>
            /// End index of the search result to be returned.
            /// </summary>
            [JsonProperty("toIndex")]
            public int ToIndex { get; set; }
        }

        public class GetSearchResultsResponse
        {

            /// <summary>
            /// Ids of the search result nodes.
            /// </summary>
            [JsonProperty("nodeIds")]
            public NodeId[] NodeIds { get; set; }
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

            /// <summary>
            /// Id of the node to move.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Id of the element to drop the moved node into.
            /// </summary>
            [JsonProperty("targetNodeId")]
            public NodeId TargetNodeId { get; set; }

            /// <summary>
            /// Drop node before this one (if absent, the moved node becomes the last child of
            /// `targetNodeId`).
            /// </summary>
            [JsonProperty("insertBeforeNodeId")]
            public NodeId InsertBeforeNodeId { get; set; }
        }

        public class MoveToResponse
        {

            /// <summary>
            /// New id of the moved node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
        /// `cancelSearch` to end this search session.
        /// </summary>
        public class PerformSearchCommand : ICommand<PerformSearchResponse>
        {
            string ICommand.Name { get; } = "DOM.performSearch";

            /// <summary>
            /// Plain text or query selector or XPath search query.
            /// </summary>
            [JsonProperty("query")]
            public string Query { get; set; }

            /// <summary>
            /// True to search in user agent shadow DOM.
            /// </summary>
            [JsonProperty("includeUserAgentShadowDOM")]
            public bool IncludeUserAgentShadowDOM { get; set; }
        }

        public class PerformSearchResponse
        {

            /// <summary>
            /// Unique search session identifier.
            /// </summary>
            [JsonProperty("searchId")]
            public string SearchId { get; set; }

            /// <summary>
            /// Number of search results.
            /// </summary>
            [JsonProperty("resultCount")]
            public int ResultCount { get; set; }
        }

        /// <summary>
        /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
        /// </summary>
        public class PushNodeByPathToFrontendCommand : ICommand<PushNodeByPathToFrontendResponse>
        {
            string ICommand.Name { get; } = "DOM.pushNodeByPathToFrontend";

            /// <summary>
            /// Path to node in the proprietary format.
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }
        }

        public class PushNodeByPathToFrontendResponse
        {

            /// <summary>
            /// Id of the node for given path.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Requests that a batch of nodes is sent to the caller given their backend node ids.
        /// </summary>
        public class PushNodesByBackendIdsToFrontendCommand : ICommand<PushNodesByBackendIdsToFrontendResponse>
        {
            string ICommand.Name { get; } = "DOM.pushNodesByBackendIdsToFrontend";

            /// <summary>
            /// The array of backend node ids.
            /// </summary>
            [JsonProperty("backendNodeIds")]
            public BackendNodeId[] BackendNodeIds { get; set; }
        }

        public class PushNodesByBackendIdsToFrontendResponse
        {

            /// <summary>
            /// The array of ids of pushed nodes that correspond to the backend ids specified in
            /// backendNodeIds.
            /// </summary>
            [JsonProperty("nodeIds")]
            public NodeId[] NodeIds { get; set; }
        }

        /// <summary>
        /// Executes `querySelector` on a given node.
        /// </summary>
        public class QuerySelectorCommand : ICommand<QuerySelectorResponse>
        {
            string ICommand.Name { get; } = "DOM.querySelector";

            /// <summary>
            /// Id of the node to query upon.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Selector string.
            /// </summary>
            [JsonProperty("selector")]
            public string Selector { get; set; }
        }

        public class QuerySelectorResponse
        {

            /// <summary>
            /// Query selector result.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Executes `querySelectorAll` on a given node.
        /// </summary>
        public class QuerySelectorAllCommand : ICommand<QuerySelectorAllResponse>
        {
            string ICommand.Name { get; } = "DOM.querySelectorAll";

            /// <summary>
            /// Id of the node to query upon.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Selector string.
            /// </summary>
            [JsonProperty("selector")]
            public string Selector { get; set; }
        }

        public class QuerySelectorAllResponse
        {

            /// <summary>
            /// Query selector result.
            /// </summary>
            [JsonProperty("nodeIds")]
            public NodeId[] NodeIds { get; set; }
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

            /// <summary>
            /// Id of the element to remove attribute from.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Name of the attribute to remove.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        /// <summary>
        /// Removes node with given id.
        /// </summary>
        public class RemoveNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.removeNode";

            /// <summary>
            /// Id of the node to remove.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Requests that children of the node with given id are returned to the caller in form of
        /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
        /// the specified depth.
        /// </summary>
        public class RequestChildNodesCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.requestChildNodes";

            /// <summary>
            /// Id of the node to get children for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
            /// entire subtree or provide an integer larger than 0.
            /// </summary>
            [JsonProperty("depth")]
            public int Depth { get; set; }

            /// <summary>
            /// Whether or not iframes and shadow roots should be traversed when returning the sub-tree
            /// (default is false).
            /// </summary>
            [JsonProperty("pierce")]
            public bool Pierce { get; set; }
        }

        /// <summary>
        /// Requests that the node is sent to the caller given the JavaScript node object reference. All
        /// nodes that form the path from the node to the root are also sent to the client as a series of
        /// `setChildNodes` notifications.
        /// </summary>
        public class RequestNodeCommand : ICommand<RequestNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.requestNode";

            /// <summary>
            /// JavaScript object id to convert into node.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class RequestNodeResponse
        {

            /// <summary>
            /// Node id for given object.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
        /// </summary>
        public class ResolveNodeCommand : ICommand<ResolveNodeResponse>
        {
            string ICommand.Name { get; } = "DOM.resolveNode";

            /// <summary>
            /// Id of the node to resolve.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Backend identifier of the node to resolve.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// Symbolic group name that can be used to release multiple objects.
            /// </summary>
            [JsonProperty("objectGroup")]
            public string ObjectGroup { get; set; }
        }

        public class ResolveNodeResponse
        {

            /// <summary>
            /// JavaScript object wrapper for given node.
            /// </summary>
            [JsonProperty("object")]
            public Runtime.RemoteObject Object { get; set; }
        }

        /// <summary>
        /// Sets attribute for an element with given id.
        /// </summary>
        public class SetAttributeValueCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setAttributeValue";

            /// <summary>
            /// Id of the element to set attribute for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Attribute name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Attribute value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Sets attributes on element with given id. This method is useful when user edits some existing
        /// attribute value and types in several attribute name/value pairs.
        /// </summary>
        public class SetAttributesAsTextCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setAttributesAsText";

            /// <summary>
            /// Id of the element to set attributes for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Text with a number of attributes. Will parse this text using HTML parser.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Attribute name to replace with new attributes derived from text in case text parsed
            /// successfully.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        /// <summary>
        /// Sets files for the given file input element.
        /// </summary>
        public class SetFileInputFilesCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setFileInputFiles";

            /// <summary>
            /// Array of file paths to set.
            /// </summary>
            [JsonProperty("files")]
            public string[] Files { get; set; }

            /// <summary>
            /// Identifier of the node.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        /// <summary>
        /// Returns file information for the given
        /// File wrapper.
        /// </summary>
        public class GetFileInfoCommand : ICommand<GetFileInfoResponse>
        {
            string ICommand.Name { get; } = "DOM.getFileInfo";

            /// <summary>
            /// JavaScript object id of the node wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class GetFileInfoResponse
        {

            [JsonProperty("path")]
            public string Path { get; set; }
        }

        /// <summary>
        /// Enables console to refer to the node with given id via $x (see Command Line API for more details
        /// $x functions).
        /// </summary>
        public class SetInspectedNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setInspectedNode";

            /// <summary>
            /// DOM node id to be accessible by means of $x command line API.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Sets node name for a node with given id.
        /// </summary>
        public class SetNodeNameCommand : ICommand<SetNodeNameResponse>
        {
            string ICommand.Name { get; } = "DOM.setNodeName";

            /// <summary>
            /// Id of the node to set name for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// New node's name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class SetNodeNameResponse
        {

            /// <summary>
            /// New node's id.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Sets node value for a node with given id.
        /// </summary>
        public class SetNodeValueCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setNodeValue";

            /// <summary>
            /// Id of the node to set value for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// New node's value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Sets node HTML markup, returns new node id.
        /// </summary>
        public class SetOuterHTMLCommand : ICommand
        {
            string ICommand.Name { get; } = "DOM.setOuterHTML";

            /// <summary>
            /// Id of the node to set markup for.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Outer HTML markup to set.
            /// </summary>
            [JsonProperty("outerHTML")]
            public string OuterHTML { get; set; }
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

            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }
        }

        public class GetFrameOwnerResponse
        {

            /// <summary>
            /// Resulting node.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// Id of the node at given coordinates, only when enabled.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Fired when `Element`'s attribute is modified.
        /// </summary>
        public class AttributeModifiedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.attributeModified";

            /// <summary>
            /// Id of the node that has changed.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// Attribute name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// Attribute value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// Fired when `Element`'s attribute is removed.
        /// </summary>
        public class AttributeRemovedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.attributeRemoved";

            /// <summary>
            /// Id of the node that has changed.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// A ttribute name.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        /// <summary>
        /// Mirrors `DOMCharacterDataModified` event.
        /// </summary>
        public class CharacterDataModifiedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.characterDataModified";

            /// <summary>
            /// Id of the node that has changed.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// New text value.
            /// </summary>
            [JsonProperty("characterData")]
            public string CharacterData { get; set; }
        }

        /// <summary>
        /// Fired when `Container`'s child node count has changed.
        /// </summary>
        public class ChildNodeCountUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.childNodeCountUpdated";

            /// <summary>
            /// Id of the node that has changed.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }

            /// <summary>
            /// New node count.
            /// </summary>
            [JsonProperty("childNodeCount")]
            public int ChildNodeCount { get; set; }
        }

        /// <summary>
        /// Mirrors `DOMNodeInserted` event.
        /// </summary>
        public class ChildNodeInsertedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.childNodeInserted";

            /// <summary>
            /// Id of the node that has changed.
            /// </summary>
            [JsonProperty("parentNodeId")]
            public NodeId ParentNodeId { get; set; }

            /// <summary>
            /// If of the previous siblint.
            /// </summary>
            [JsonProperty("previousNodeId")]
            public NodeId PreviousNodeId { get; set; }

            /// <summary>
            /// Inserted node data.
            /// </summary>
            [JsonProperty("node")]
            public Node Node { get; set; }
        }

        /// <summary>
        /// Mirrors `DOMNodeRemoved` event.
        /// </summary>
        public class ChildNodeRemovedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.childNodeRemoved";

            /// <summary>
            /// Parent id.
            /// </summary>
            [JsonProperty("parentNodeId")]
            public NodeId ParentNodeId { get; set; }

            /// <summary>
            /// Id of the node that has been removed.
            /// </summary>
            [JsonProperty("nodeId")]
            public NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Called when distrubution is changed.
        /// </summary>
        public class DistributedNodesUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.distributedNodesUpdated";

            /// <summary>
            /// Insertion point where distrubuted nodes were updated.
            /// </summary>
            [JsonProperty("insertionPointId")]
            public NodeId InsertionPointId { get; set; }

            /// <summary>
            /// Distributed nodes for given insertion point.
            /// </summary>
            [JsonProperty("distributedNodes")]
            public BackendNode[] DistributedNodes { get; set; }
        }

        /// <summary>
        /// Fired when `Document` has been totally updated. Node ids are no longer valid.
        /// </summary>
        public class DocumentUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.documentUpdated";
        }

        /// <summary>
        /// Fired when `Element`'s inline style is modified via a CSS property modification.
        /// </summary>
        public class InlineStyleInvalidatedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.inlineStyleInvalidated";

            /// <summary>
            /// Ids of the nodes for which the inline styles have been invalidated.
            /// </summary>
            [JsonProperty("nodeIds")]
            public NodeId[] NodeIds { get; set; }
        }

        /// <summary>
        /// Called when a pseudo element is added to an element.
        /// </summary>
        public class PseudoElementAddedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.pseudoElementAdded";

            /// <summary>
            /// Pseudo element's parent element id.
            /// </summary>
            [JsonProperty("parentId")]
            public NodeId ParentId { get; set; }

            /// <summary>
            /// The added pseudo element.
            /// </summary>
            [JsonProperty("pseudoElement")]
            public Node PseudoElement { get; set; }
        }

        /// <summary>
        /// Called when a pseudo element is removed from an element.
        /// </summary>
        public class PseudoElementRemovedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.pseudoElementRemoved";

            /// <summary>
            /// Pseudo element's parent element id.
            /// </summary>
            [JsonProperty("parentId")]
            public NodeId ParentId { get; set; }

            /// <summary>
            /// The removed pseudo element id.
            /// </summary>
            [JsonProperty("pseudoElementId")]
            public NodeId PseudoElementId { get; set; }
        }

        /// <summary>
        /// Fired when backend wants to provide client with the missing DOM structure. This happens upon
        /// most of the calls requesting node ids.
        /// </summary>
        public class SetChildNodesEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.setChildNodes";

            /// <summary>
            /// Parent node id to populate with children.
            /// </summary>
            [JsonProperty("parentId")]
            public NodeId ParentId { get; set; }

            /// <summary>
            /// Child nodes array.
            /// </summary>
            [JsonProperty("nodes")]
            public Node[] Nodes { get; set; }
        }

        /// <summary>
        /// Called when shadow root is popped from the element.
        /// </summary>
        public class ShadowRootPoppedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.shadowRootPopped";

            /// <summary>
            /// Host element id.
            /// </summary>
            [JsonProperty("hostId")]
            public NodeId HostId { get; set; }

            /// <summary>
            /// Shadow root id.
            /// </summary>
            [JsonProperty("rootId")]
            public NodeId RootId { get; set; }
        }

        /// <summary>
        /// Called when shadow root is pushed into the element.
        /// </summary>
        public class ShadowRootPushedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOM.shadowRootPushed";

            /// <summary>
            /// Host element id.
            /// </summary>
            [JsonProperty("hostId")]
            public NodeId HostId { get; set; }

            /// <summary>
            /// Shadow root.
            /// </summary>
            [JsonProperty("root")]
            public Node Root { get; set; }
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

            /// <summary>
            /// Identifier of the object to return listeners for.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }

            /// <summary>
            /// The maximum depth at which Node children should be retrieved, defaults to 1. Use -1 for the
            /// entire subtree or provide an integer larger than 0.
            /// </summary>
            [JsonProperty("depth")]
            public int Depth { get; set; }

            /// <summary>
            /// Whether or not iframes and shadow roots should be traversed when returning the subtree
            /// (default is false). Reports listeners for all contexts if pierce is enabled.
            /// </summary>
            [JsonProperty("pierce")]
            public bool Pierce { get; set; }
        }

        public class GetEventListenersResponse
        {

            /// <summary>
            /// Array of relevant listeners.
            /// </summary>
            [JsonProperty("listeners")]
            public EventListener[] Listeners { get; set; }
        }

        /// <summary>
        /// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
        /// </summary>
        public class RemoveDOMBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeDOMBreakpoint";

            /// <summary>
            /// Identifier of the node to remove breakpoint from.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            /// <summary>
            /// Type of the breakpoint to remove.
            /// </summary>
            [JsonProperty("type")]
            public DOMBreakpointType Type { get; set; }
        }

        /// <summary>
        /// Removes breakpoint on particular DOM event.
        /// </summary>
        public class RemoveEventListenerBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeEventListenerBreakpoint";

            /// <summary>
            /// Event name.
            /// </summary>
            [JsonProperty("eventName")]
            public string EventName { get; set; }

            /// <summary>
            /// EventTarget interface name.
            /// </summary>
            [JsonProperty("targetName")]
            public string TargetName { get; set; }
        }

        /// <summary>
        /// Removes breakpoint on particular native event.
        /// </summary>
        public class RemoveInstrumentationBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeInstrumentationBreakpoint";

            /// <summary>
            /// Instrumentation name to stop on.
            /// </summary>
            [JsonProperty("eventName")]
            public string EventName { get; set; }
        }

        /// <summary>
        /// Removes breakpoint from XMLHttpRequest.
        /// </summary>
        public class RemoveXHRBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.removeXHRBreakpoint";

            /// <summary>
            /// Resource URL substring.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// Sets breakpoint on particular operation with DOM.
        /// </summary>
        public class SetDOMBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setDOMBreakpoint";

            /// <summary>
            /// Identifier of the node to set breakpoint on.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            /// <summary>
            /// Type of the operation to stop upon.
            /// </summary>
            [JsonProperty("type")]
            public DOMBreakpointType Type { get; set; }
        }

        /// <summary>
        /// Sets breakpoint on particular DOM event.
        /// </summary>
        public class SetEventListenerBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setEventListenerBreakpoint";

            /// <summary>
            /// DOM Event name to stop on (any DOM event will do).
            /// </summary>
            [JsonProperty("eventName")]
            public string EventName { get; set; }

            /// <summary>
            /// EventTarget interface name to stop on. If equal to `"*"` or not provided, will stop on any
            /// EventTarget.
            /// </summary>
            [JsonProperty("targetName")]
            public string TargetName { get; set; }
        }

        /// <summary>
        /// Sets breakpoint on particular native event.
        /// </summary>
        public class SetInstrumentationBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setInstrumentationBreakpoint";

            /// <summary>
            /// Instrumentation name to stop on.
            /// </summary>
            [JsonProperty("eventName")]
            public string EventName { get; set; }
        }

        /// <summary>
        /// Sets breakpoint on XMLHttpRequest.
        /// </summary>
        public class SetXHRBreakpointCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMDebugger.setXHRBreakpoint";

            /// <summary>
            /// Resource URL substring. All XHRs having this substring in the URL will get stopped upon.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
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

            /// <summary>
            /// Whitelist of computed styles to return.
            /// </summary>
            [JsonProperty("computedStyleWhitelist")]
            public string[] ComputedStyleWhitelist { get; set; }

            /// <summary>
            /// Whether or not to retrieve details of DOM listeners (default false).
            /// </summary>
            [JsonProperty("includeEventListeners")]
            public bool IncludeEventListeners { get; set; }

            /// <summary>
            /// Whether to determine and include the paint order index of LayoutTreeNodes (default false).
            /// </summary>
            [JsonProperty("includePaintOrder")]
            public bool IncludePaintOrder { get; set; }

            /// <summary>
            /// Whether to include UA shadow tree in the snapshot (default false).
            /// </summary>
            [JsonProperty("includeUserAgentShadowTree")]
            public bool IncludeUserAgentShadowTree { get; set; }
        }

        public class GetSnapshotResponse
        {

            /// <summary>
            /// The nodes in the DOM tree. The DOMNode at index 0 corresponds to the root document.
            /// </summary>
            [JsonProperty("domNodes")]
            public DOMNode[] DomNodes { get; set; }

            /// <summary>
            /// The nodes in the layout tree.
            /// </summary>
            [JsonProperty("layoutTreeNodes")]
            public LayoutTreeNode[] LayoutTreeNodes { get; set; }

            /// <summary>
            /// Whitelisted ComputedStyle properties for each node in the layout tree.
            /// </summary>
            [JsonProperty("computedStyles")]
            public ComputedStyle[] ComputedStyles { get; set; }
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

            /// <summary>
            /// Whitelist of computed styles to return.
            /// </summary>
            [JsonProperty("computedStyles")]
            public string[] ComputedStyles { get; set; }
        }

        public class CaptureSnapshotResponse
        {

            /// <summary>
            /// The nodes in the DOM tree. The DOMNode at index 0 corresponds to the root document.
            /// </summary>
            [JsonProperty("documents")]
            public DocumentSnapshot[] Documents { get; set; }

            /// <summary>
            /// Shared string table that all string properties refer to with indexes.
            /// </summary>
            [JsonProperty("strings")]
            public string[] Strings { get; set; }
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

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }
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

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }
        }

        public class GetDOMStorageItemsResponse
        {

            [JsonProperty("entries")]
            public Item[] Entries { get; set; }
        }

        public class RemoveDOMStorageItemCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.removeDOMStorageItem";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }
        }

        public class SetDOMStorageItemCommand : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.setDOMStorageItem";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        public class DomStorageItemAddedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.domStorageItemAdded";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("newValue")]
            public string NewValue { get; set; }
        }

        public class DomStorageItemRemovedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.domStorageItemRemoved";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }
        }

        public class DomStorageItemUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.domStorageItemUpdated";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("oldValue")]
            public string OldValue { get; set; }

            [JsonProperty("newValue")]
            public string NewValue { get; set; }
        }

        public class DomStorageItemsClearedEvent : ICommand
        {
            string ICommand.Name { get; } = "DOMStorage.domStorageItemsCleared";

            [JsonProperty("storageId")]
            public StorageId StorageId { get; set; }
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

            [JsonProperty("databaseId")]
            public DatabaseId DatabaseId { get; set; }

            [JsonProperty("query")]
            public string Query { get; set; }
        }

        public class ExecuteSQLResponse
        {

            [JsonProperty("columnNames")]
            public string[] ColumnNames { get; set; }

            [JsonProperty("values")]
            public object[] Values { get; set; }

            [JsonProperty("sqlError")]
            public Error SqlError { get; set; }
        }

        public class GetDatabaseTableNamesCommand : ICommand<GetDatabaseTableNamesResponse>
        {
            string ICommand.Name { get; } = "Database.getDatabaseTableNames";

            [JsonProperty("databaseId")]
            public DatabaseId DatabaseId { get; set; }
        }

        public class GetDatabaseTableNamesResponse
        {

            [JsonProperty("tableNames")]
            public string[] TableNames { get; set; }
        }

        public class AddDatabaseEvent : ICommand
        {
            string ICommand.Name { get; } = "Database.addDatabase";

            [JsonProperty("database")]
            public Database Database { get; set; }
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

            /// <summary>
            /// Mock alpha
            /// </summary>
            [JsonProperty("alpha")]
            public double Alpha { get; set; }

            /// <summary>
            /// Mock beta
            /// </summary>
            [JsonProperty("beta")]
            public double Beta { get; set; }

            /// <summary>
            /// Mock gamma
            /// </summary>
            [JsonProperty("gamma")]
            public double Gamma { get; set; }
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

            /// <summary>
            /// True if emulation is supported.
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }
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

            /// <summary>
            /// Whether to enable to disable focus emulation.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Enables CPU throttling to emulate slow CPUs.
        /// </summary>
        public class SetCPUThrottlingRateCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setCPUThrottlingRate";

            /// <summary>
            /// Throttling rate as a slowdown factor (1 is no throttle, 2 is 2x slowdown, etc).
            /// </summary>
            [JsonProperty("rate")]
            public double Rate { get; set; }
        }

        /// <summary>
        /// Sets or clears an override of the default background color of the frame. This override is used
        /// if the content does not specify one.
        /// </summary>
        public class SetDefaultBackgroundColorOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDefaultBackgroundColorOverride";

            /// <summary>
            /// RGBA of the default background color. If not specified, any existing override will be
            /// cleared.
            /// </summary>
            [JsonProperty("color")]
            public DOM.RGBA Color { get; set; }
        }

        /// <summary>
        /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
        /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
        /// query results).
        /// </summary>
        public class SetDeviceMetricsOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDeviceMetricsOverride";

            /// <summary>
            /// Overriding width value in pixels (minimum 0, maximum 10000000). 0 disables the override.
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Overriding height value in pixels (minimum 0, maximum 10000000). 0 disables the override.
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// Overriding device scale factor value. 0 disables the override.
            /// </summary>
            [JsonProperty("deviceScaleFactor")]
            public double DeviceScaleFactor { get; set; }

            /// <summary>
            /// Whether to emulate mobile device. This includes viewport meta tag, overlay scrollbars, text
            /// autosizing and more.
            /// </summary>
            [JsonProperty("mobile")]
            public bool Mobile { get; set; }

            /// <summary>
            /// Scale to apply to resulting view image.
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }

            /// <summary>
            /// Overriding screen width value in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("screenWidth")]
            public int ScreenWidth { get; set; }

            /// <summary>
            /// Overriding screen height value in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("screenHeight")]
            public int ScreenHeight { get; set; }

            /// <summary>
            /// Overriding view X position on screen in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("positionX")]
            public int PositionX { get; set; }

            /// <summary>
            /// Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("positionY")]
            public int PositionY { get; set; }

            /// <summary>
            /// Do not set visible view size, rely upon explicit setVisibleSize call.
            /// </summary>
            [JsonProperty("dontSetVisibleSize")]
            public bool DontSetVisibleSize { get; set; }

            /// <summary>
            /// Screen orientation override.
            /// </summary>
            [JsonProperty("screenOrientation")]
            public ScreenOrientation ScreenOrientation { get; set; }

            /// <summary>
            /// If set, the visible area of the page will be overridden to this viewport. This viewport
            /// change is not observed by the page, e.g. viewport-relative elements do not change positions.
            /// </summary>
            [JsonProperty("viewport")]
            public Page.Viewport Viewport { get; set; }
        }

        public class SetScrollbarsHiddenCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setScrollbarsHidden";

            /// <summary>
            /// Whether scrollbars should be always hidden.
            /// </summary>
            [JsonProperty("hidden")]
            public bool Hidden { get; set; }
        }

        public class SetDocumentCookieDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setDocumentCookieDisabled";

            /// <summary>
            /// Whether document.coookie API should be disabled.
            /// </summary>
            [JsonProperty("disabled")]
            public bool Disabled { get; set; }
        }

        public class SetEmitTouchEventsForMouseCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setEmitTouchEventsForMouse";

            /// <summary>
            /// Whether touch emulation based on mouse input should be enabled.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            /// <summary>
            /// Touch/gesture events configuration. Default: current platform.
            /// </summary>
            [JsonProperty("configuration")]
            public string Configuration { get; set; }
        }

        /// <summary>
        /// Emulates the given media for CSS media queries.
        /// </summary>
        public class SetEmulatedMediaCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setEmulatedMedia";

            /// <summary>
            /// Media type to emulate. Empty string disables the override.
            /// </summary>
            [JsonProperty("media")]
            public string Media { get; set; }
        }

        /// <summary>
        /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
        /// unavailable.
        /// </summary>
        public class SetGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setGeolocationOverride";

            /// <summary>
            /// Mock latitude
            /// </summary>
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            /// <summary>
            /// Mock longitude
            /// </summary>
            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            /// <summary>
            /// Mock accuracy
            /// </summary>
            [JsonProperty("accuracy")]
            public double Accuracy { get; set; }
        }

        /// <summary>
        /// Overrides value returned by the javascript navigator object.
        /// </summary>
        [Obsolete]
        public class SetNavigatorOverridesCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setNavigatorOverrides";

            /// <summary>
            /// The platform navigator.platform should return.
            /// </summary>
            [JsonProperty("platform")]
            public string Platform { get; set; }
        }

        /// <summary>
        /// Sets a specified page scale factor.
        /// </summary>
        public class SetPageScaleFactorCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setPageScaleFactor";

            /// <summary>
            /// Page scale factor.
            /// </summary>
            [JsonProperty("pageScaleFactor")]
            public double PageScaleFactor { get; set; }
        }

        /// <summary>
        /// Switches script execution in the page.
        /// </summary>
        public class SetScriptExecutionDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setScriptExecutionDisabled";

            /// <summary>
            /// Whether script execution should be disabled in the page.
            /// </summary>
            [JsonProperty("value")]
            public bool Value { get; set; }
        }

        /// <summary>
        /// Enables touch on platforms which do not support them.
        /// </summary>
        public class SetTouchEmulationEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setTouchEmulationEnabled";

            /// <summary>
            /// Whether the touch event emulation should be enabled.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            /// <summary>
            /// Maximum touch points supported. Defaults to one.
            /// </summary>
            [JsonProperty("maxTouchPoints")]
            public int MaxTouchPoints { get; set; }
        }

        /// <summary>
        /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
        /// the current virtual time policy.  Note this supersedes any previous time budget.
        /// </summary>
        public class SetVirtualTimePolicyCommand : ICommand<SetVirtualTimePolicyResponse>
        {
            string ICommand.Name { get; } = "Emulation.setVirtualTimePolicy";

            [JsonProperty("policy")]
            public VirtualTimePolicy Policy { get; set; }

            /// <summary>
            /// If set, after this many virtual milliseconds have elapsed virtual time will be paused and a
            /// virtualTimeBudgetExpired event is sent.
            /// </summary>
            [JsonProperty("budget")]
            public double Budget { get; set; }

            /// <summary>
            /// If set this specifies the maximum number of tasks that can be run before virtual is forced
            /// forwards to prevent deadlock.
            /// </summary>
            [JsonProperty("maxVirtualTimeTaskStarvationCount")]
            public int MaxVirtualTimeTaskStarvationCount { get; set; }

            /// <summary>
            /// If set the virtual time policy change should be deferred until any frame starts navigating.
            /// Note any previous deferred policy change is superseded.
            /// </summary>
            [JsonProperty("waitForNavigation")]
            public bool WaitForNavigation { get; set; }

            /// <summary>
            /// If set, base::Time::Now will be overriden to initially return this value.
            /// </summary>
            [JsonProperty("initialVirtualTime")]
            public Network.TimeSinceEpoch InitialVirtualTime { get; set; }
        }

        public class SetVirtualTimePolicyResponse
        {

            /// <summary>
            /// Absolute timestamp at which virtual time was first enabled (up time in milliseconds).
            /// </summary>
            [JsonProperty("virtualTimeTicksBase")]
            public double VirtualTimeTicksBase { get; set; }
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

            /// <summary>
            /// Frame width (DIP).
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Frame height (DIP).
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }
        }

        /// <summary>
        /// Allows overriding user agent with the given string.
        /// </summary>
        public class SetUserAgentOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Emulation.setUserAgentOverride";

            /// <summary>
            /// User agent to use.
            /// </summary>
            [JsonProperty("userAgent")]
            public string UserAgent { get; set; }

            /// <summary>
            /// Browser langugage to emulate.
            /// </summary>
            [JsonProperty("acceptLanguage")]
            public string AcceptLanguage { get; set; }

            /// <summary>
            /// The platform navigator.platform should return.
            /// </summary>
            [JsonProperty("platform")]
            public string Platform { get; set; }
        }

        /// <summary>
        /// Notification sent after the virtual time has advanced.
        /// </summary>
        public class VirtualTimeAdvancedEvent : ICommand
        {
            string ICommand.Name { get; } = "Emulation.virtualTimeAdvanced";

            /// <summary>
            /// The amount of virtual time that has elapsed in milliseconds since virtual time was first
            /// enabled.
            /// </summary>
            [JsonProperty("virtualTimeElapsed")]
            public double VirtualTimeElapsed { get; set; }
        }

        /// <summary>
        /// Notification sent after the virtual time budget for the current VirtualTimePolicy has run out.
        /// </summary>
        public class VirtualTimeBudgetExpiredEvent : ICommand
        {
            string ICommand.Name { get; } = "Emulation.virtualTimeBudgetExpired";
        }

        /// <summary>
        /// Notification sent after the virtual time has paused.
        /// </summary>
        public class VirtualTimePausedEvent : ICommand
        {
            string ICommand.Name { get; } = "Emulation.virtualTimePaused";

            /// <summary>
            /// The amount of virtual time that has elapsed in milliseconds since virtual time was first
            /// enabled.
            /// </summary>
            [JsonProperty("virtualTimeElapsed")]
            public double VirtualTimeElapsed { get; set; }
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

            /// <summary>
            /// Timestamp of this BeginFrame in Renderer TimeTicks (milliseconds of uptime). If not set,
            /// the current time will be used.
            /// </summary>
            [JsonProperty("frameTimeTicks")]
            public double FrameTimeTicks { get; set; }

            /// <summary>
            /// The interval between BeginFrames that is reported to the compositor, in milliseconds.
            /// Defaults to a 60 frames/second interval, i.e. about 16.666 milliseconds.
            /// </summary>
            [JsonProperty("interval")]
            public double Interval { get; set; }

            /// <summary>
            /// Whether updates should not be committed and drawn onto the display. False by default. If
            /// true, only side effects of the BeginFrame will be run, such as layout and animations, but
            /// any visual updates may not be visible on the display or in screenshots.
            /// </summary>
            [JsonProperty("noDisplayUpdates")]
            public bool NoDisplayUpdates { get; set; }

            /// <summary>
            /// If set, a screenshot of the frame will be captured and returned in the response. Otherwise,
            /// no screenshot will be captured. Note that capturing a screenshot can fail, for example,
            /// during renderer initialization. In such a case, no screenshot data will be returned.
            /// </summary>
            [JsonProperty("screenshot")]
            public ScreenshotParams Screenshot { get; set; }
        }

        public class BeginFrameResponse
        {

            /// <summary>
            /// Whether the BeginFrame resulted in damage and, thus, a new frame was committed to the
            /// display. Reported for diagnostic uses, may be removed in the future.
            /// </summary>
            [JsonProperty("hasDamage")]
            public bool HasDamage { get; set; }

            /// <summary>
            /// Base64-encoded image data of the screenshot, if one was requested and successfully taken.
            /// </summary>
            [JsonProperty("screenshotData")]
            public string ScreenshotData { get; set; }
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

        /// <summary>
        /// Issued when the target starts or stops needing BeginFrames.
        /// </summary>
        public class NeedsBeginFramesChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "HeadlessExperimental.needsBeginFramesChanged";

            /// <summary>
            /// True if BeginFrames are needed, false otherwise.
            /// </summary>
            [JsonProperty("needsBeginFrames")]
            public bool NeedsBeginFrames { get; set; }
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

            /// <summary>
            /// Handle of the stream to close.
            /// </summary>
            [JsonProperty("handle")]
            public StreamHandle Handle { get; set; }
        }

        /// <summary>
        /// Read a chunk of the stream
        /// </summary>
        public class ReadCommand : ICommand<ReadResponse>
        {
            string ICommand.Name { get; } = "IO.read";

            /// <summary>
            /// Handle of the stream to read.
            /// </summary>
            [JsonProperty("handle")]
            public StreamHandle Handle { get; set; }

            /// <summary>
            /// Seek to the specified offset before reading (if not specificed, proceed with offset
            /// following the last read). Some types of streams may only support sequential reads.
            /// </summary>
            [JsonProperty("offset")]
            public int Offset { get; set; }

            /// <summary>
            /// Maximum number of bytes to read (left upon the agent discretion if not specified).
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }
        }

        public class ReadResponse
        {

            /// <summary>
            /// Set if the data is base64-encoded
            /// </summary>
            [JsonProperty("base64Encoded")]
            public bool Base64Encoded { get; set; }

            /// <summary>
            /// Data that were read.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }

            /// <summary>
            /// Set if the end-of-file condition occured while reading.
            /// </summary>
            [JsonProperty("eof")]
            public bool Eof { get; set; }
        }

        /// <summary>
        /// Return UUID of Blob object specified by a remote object id.
        /// </summary>
        public class ResolveBlobCommand : ICommand<ResolveBlobResponse>
        {
            string ICommand.Name { get; } = "IO.resolveBlob";

            /// <summary>
            /// Object id of a Blob object wrapper.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        public class ResolveBlobResponse
        {

            /// <summary>
            /// UUID of the specified Blob.
            /// </summary>
            [JsonProperty("uuid")]
            public string Uuid { get; set; }
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

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }

            /// <summary>
            /// Object store name.
            /// </summary>
            [JsonProperty("objectStoreName")]
            public string ObjectStoreName { get; set; }
        }

        /// <summary>
        /// Deletes a database.
        /// </summary>
        public class DeleteDatabaseCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.deleteDatabase";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }
        }

        /// <summary>
        /// Delete a range of entries from an object store
        /// </summary>
        public class DeleteObjectStoreEntriesCommand : ICommand
        {
            string ICommand.Name { get; } = "IndexedDB.deleteObjectStoreEntries";

            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }

            [JsonProperty("objectStoreName")]
            public string ObjectStoreName { get; set; }

            /// <summary>
            /// Range of entry keys to delete
            /// </summary>
            [JsonProperty("keyRange")]
            public KeyRange KeyRange { get; set; }
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

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }

            /// <summary>
            /// Object store name.
            /// </summary>
            [JsonProperty("objectStoreName")]
            public string ObjectStoreName { get; set; }

            /// <summary>
            /// Index name, empty string for object store data requests.
            /// </summary>
            [JsonProperty("indexName")]
            public string IndexName { get; set; }

            /// <summary>
            /// Number of records to skip.
            /// </summary>
            [JsonProperty("skipCount")]
            public int SkipCount { get; set; }

            /// <summary>
            /// Number of records to fetch.
            /// </summary>
            [JsonProperty("pageSize")]
            public int PageSize { get; set; }

            /// <summary>
            /// Key range.
            /// </summary>
            [JsonProperty("keyRange")]
            public KeyRange KeyRange { get; set; }
        }

        public class RequestDataResponse
        {

            /// <summary>
            /// Array of object store data entries.
            /// </summary>
            [JsonProperty("objectStoreDataEntries")]
            public DataEntry[] ObjectStoreDataEntries { get; set; }

            /// <summary>
            /// If true, there are more entries to fetch in the given range.
            /// </summary>
            [JsonProperty("hasMore")]
            public bool HasMore { get; set; }
        }

        /// <summary>
        /// Requests database with given name in given frame.
        /// </summary>
        public class RequestDatabaseCommand : ICommand<RequestDatabaseResponse>
        {
            string ICommand.Name { get; } = "IndexedDB.requestDatabase";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }

            /// <summary>
            /// Database name.
            /// </summary>
            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }
        }

        public class RequestDatabaseResponse
        {

            /// <summary>
            /// Database with an array of object stores.
            /// </summary>
            [JsonProperty("databaseWithObjectStores")]
            public DatabaseWithObjectStores DatabaseWithObjectStores { get; set; }
        }

        /// <summary>
        /// Requests database names for given security origin.
        /// </summary>
        public class RequestDatabaseNamesCommand : ICommand<RequestDatabaseNamesResponse>
        {
            string ICommand.Name { get; } = "IndexedDB.requestDatabaseNames";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("securityOrigin")]
            public string SecurityOrigin { get; set; }
        }

        public class RequestDatabaseNamesResponse
        {

            /// <summary>
            /// Database names for origin.
            /// </summary>
            [JsonProperty("databaseNames")]
            public string[] DatabaseNames { get; set; }
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

            /// <summary>
            /// Type of the key event.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Bit field representing pressed modifier keys. Alt=1, Ctrl=2, Meta/Command=4, Shift=8
            /// (default: 0).
            /// </summary>
            [JsonProperty("modifiers")]
            public int Modifiers { get; set; }

            /// <summary>
            /// Time at which the event occurred.
            /// </summary>
            [JsonProperty("timestamp")]
            public TimeSinceEpoch Timestamp { get; set; }

            /// <summary>
            /// Text as generated by processing a virtual key code with a keyboard layout. Not needed for
            /// for `keyUp` and `rawKeyDown` events (default: "")
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Text that would have been generated by the keyboard if no modifiers were pressed (except for
            /// shift). Useful for shortcut (accelerator) key handling (default: "").
            /// </summary>
            [JsonProperty("unmodifiedText")]
            public string UnmodifiedText { get; set; }

            /// <summary>
            /// Unique key identifier (e.g., 'U+0041') (default: "").
            /// </summary>
            [JsonProperty("keyIdentifier")]
            public string KeyIdentifier { get; set; }

            /// <summary>
            /// Unique DOM defined string value for each physical key (e.g., 'KeyA') (default: "").
            /// </summary>
            [JsonProperty("code")]
            public string Code { get; set; }

            /// <summary>
            /// Unique DOM defined string value describing the meaning of the key in the context of active
            /// modifiers, keyboard layout, etc (e.g., 'AltGr') (default: "").
            /// </summary>
            [JsonProperty("key")]
            public string Key { get; set; }

            /// <summary>
            /// Windows virtual key code (default: 0).
            /// </summary>
            [JsonProperty("windowsVirtualKeyCode")]
            public int WindowsVirtualKeyCode { get; set; }

            /// <summary>
            /// Native virtual key code (default: 0).
            /// </summary>
            [JsonProperty("nativeVirtualKeyCode")]
            public int NativeVirtualKeyCode { get; set; }

            /// <summary>
            /// Whether the event was generated from auto repeat (default: false).
            /// </summary>
            [JsonProperty("autoRepeat")]
            public bool AutoRepeat { get; set; }

            /// <summary>
            /// Whether the event was generated from the keypad (default: false).
            /// </summary>
            [JsonProperty("isKeypad")]
            public bool IsKeypad { get; set; }

            /// <summary>
            /// Whether the event was a system key event (default: false).
            /// </summary>
            [JsonProperty("isSystemKey")]
            public bool IsSystemKey { get; set; }

            /// <summary>
            /// Whether the event was from the left or right side of the keyboard. 1=Left, 2=Right (default:
            /// 0).
            /// </summary>
            [JsonProperty("location")]
            public int Location { get; set; }
        }

        /// <summary>
        /// This method emulates inserting text that doesn't come from a key press,
        /// for example an emoji keyboard or an IME.
        /// </summary>
        public class InsertTextCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.insertText";

            /// <summary>
            /// The text to insert.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        /// <summary>
        /// Dispatches a mouse event to the page.
        /// </summary>
        public class DispatchMouseEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.dispatchMouseEvent";

            /// <summary>
            /// Type of the mouse event.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

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
            /// Bit field representing pressed modifier keys. Alt=1, Ctrl=2, Meta/Command=4, Shift=8
            /// (default: 0).
            /// </summary>
            [JsonProperty("modifiers")]
            public int Modifiers { get; set; }

            /// <summary>
            /// Time at which the event occurred.
            /// </summary>
            [JsonProperty("timestamp")]
            public TimeSinceEpoch Timestamp { get; set; }

            /// <summary>
            /// Mouse button (default: "none").
            /// </summary>
            [JsonProperty("button")]
            public string Button { get; set; }

            /// <summary>
            /// A number indicating which buttons are pressed on the mouse when a mouse event is triggered.
            /// Left=1, Right=2, Middle=4, Back=8, Forward=16, None=0.
            /// </summary>
            [JsonProperty("buttons")]
            public int Buttons { get; set; }

            /// <summary>
            /// Number of times the mouse button was clicked (default: 0).
            /// </summary>
            [JsonProperty("clickCount")]
            public int ClickCount { get; set; }

            /// <summary>
            /// X delta in CSS pixels for mouse wheel event (default: 0).
            /// </summary>
            [JsonProperty("deltaX")]
            public double DeltaX { get; set; }

            /// <summary>
            /// Y delta in CSS pixels for mouse wheel event (default: 0).
            /// </summary>
            [JsonProperty("deltaY")]
            public double DeltaY { get; set; }

            /// <summary>
            /// Pointer type (default: "mouse").
            /// </summary>
            [JsonProperty("pointerType")]
            public string PointerType { get; set; }
        }

        /// <summary>
        /// Dispatches a touch event to the page.
        /// </summary>
        public class DispatchTouchEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.dispatchTouchEvent";

            /// <summary>
            /// Type of the touch event. TouchEnd and TouchCancel must not contain any touch points, while
            /// TouchStart and TouchMove must contains at least one.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Active touch points on the touch device. One event per any changed point (compared to
            /// previous touch event in a sequence) is generated, emulating pressing/moving/releasing points
            /// one by one.
            /// </summary>
            [JsonProperty("touchPoints")]
            public TouchPoint[] TouchPoints { get; set; }

            /// <summary>
            /// Bit field representing pressed modifier keys. Alt=1, Ctrl=2, Meta/Command=4, Shift=8
            /// (default: 0).
            /// </summary>
            [JsonProperty("modifiers")]
            public int Modifiers { get; set; }

            /// <summary>
            /// Time at which the event occurred.
            /// </summary>
            [JsonProperty("timestamp")]
            public TimeSinceEpoch Timestamp { get; set; }
        }

        /// <summary>
        /// Emulates touch event from the mouse event parameters.
        /// </summary>
        public class EmulateTouchFromMouseEventCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.emulateTouchFromMouseEvent";

            /// <summary>
            /// Type of the mouse event.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// X coordinate of the mouse pointer in DIP.
            /// </summary>
            [JsonProperty("x")]
            public int X { get; set; }

            /// <summary>
            /// Y coordinate of the mouse pointer in DIP.
            /// </summary>
            [JsonProperty("y")]
            public int Y { get; set; }

            /// <summary>
            /// Mouse button.
            /// </summary>
            [JsonProperty("button")]
            public string Button { get; set; }

            /// <summary>
            /// Time at which the event occurred (default: current time).
            /// </summary>
            [JsonProperty("timestamp")]
            public TimeSinceEpoch Timestamp { get; set; }

            /// <summary>
            /// X delta in DIP for mouse wheel event (default: 0).
            /// </summary>
            [JsonProperty("deltaX")]
            public double DeltaX { get; set; }

            /// <summary>
            /// Y delta in DIP for mouse wheel event (default: 0).
            /// </summary>
            [JsonProperty("deltaY")]
            public double DeltaY { get; set; }

            /// <summary>
            /// Bit field representing pressed modifier keys. Alt=1, Ctrl=2, Meta/Command=4, Shift=8
            /// (default: 0).
            /// </summary>
            [JsonProperty("modifiers")]
            public int Modifiers { get; set; }

            /// <summary>
            /// Number of times the mouse button was clicked (default: 0).
            /// </summary>
            [JsonProperty("clickCount")]
            public int ClickCount { get; set; }
        }

        /// <summary>
        /// Ignores input events (useful while auditing page).
        /// </summary>
        public class SetIgnoreInputEventsCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.setIgnoreInputEvents";

            /// <summary>
            /// Ignores input events processing when set to true.
            /// </summary>
            [JsonProperty("ignore")]
            public bool Ignore { get; set; }
        }

        /// <summary>
        /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizePinchGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizePinchGesture";

            /// <summary>
            /// X coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// Relative scale factor after zooming (&gt;1.0 zooms in, &lt;1.0 zooms out).
            /// </summary>
            [JsonProperty("scaleFactor")]
            public double ScaleFactor { get; set; }

            /// <summary>
            /// Relative pointer speed in pixels per second (default: 800).
            /// </summary>
            [JsonProperty("relativeSpeed")]
            public int RelativeSpeed { get; set; }

            /// <summary>
            /// Which type of input events to be generated (default: 'default', which queries the platform
            /// for the preferred input type).
            /// </summary>
            [JsonProperty("gestureSourceType")]
            public GestureSourceType GestureSourceType { get; set; }
        }

        /// <summary>
        /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizeScrollGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizeScrollGesture";

            /// <summary>
            /// X coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// The distance to scroll along the X axis (positive to scroll left).
            /// </summary>
            [JsonProperty("xDistance")]
            public double XDistance { get; set; }

            /// <summary>
            /// The distance to scroll along the Y axis (positive to scroll up).
            /// </summary>
            [JsonProperty("yDistance")]
            public double YDistance { get; set; }

            /// <summary>
            /// The number of additional pixels to scroll back along the X axis, in addition to the given
            /// distance.
            /// </summary>
            [JsonProperty("xOverscroll")]
            public double XOverscroll { get; set; }

            /// <summary>
            /// The number of additional pixels to scroll back along the Y axis, in addition to the given
            /// distance.
            /// </summary>
            [JsonProperty("yOverscroll")]
            public double YOverscroll { get; set; }

            /// <summary>
            /// Prevent fling (default: true).
            /// </summary>
            [JsonProperty("preventFling")]
            public bool PreventFling { get; set; }

            /// <summary>
            /// Swipe speed in pixels per second (default: 800).
            /// </summary>
            [JsonProperty("speed")]
            public int Speed { get; set; }

            /// <summary>
            /// Which type of input events to be generated (default: 'default', which queries the platform
            /// for the preferred input type).
            /// </summary>
            [JsonProperty("gestureSourceType")]
            public GestureSourceType GestureSourceType { get; set; }

            /// <summary>
            /// The number of times to repeat the gesture (default: 0).
            /// </summary>
            [JsonProperty("repeatCount")]
            public int RepeatCount { get; set; }

            /// <summary>
            /// The number of milliseconds delay between each repeat. (default: 250).
            /// </summary>
            [JsonProperty("repeatDelayMs")]
            public int RepeatDelayMs { get; set; }

            /// <summary>
            /// The name of the interaction markers to generate, if not empty (default: "").
            /// </summary>
            [JsonProperty("interactionMarkerName")]
            public string InteractionMarkerName { get; set; }
        }

        /// <summary>
        /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
        /// </summary>
        public class SynthesizeTapGestureCommand : ICommand
        {
            string ICommand.Name { get; } = "Input.synthesizeTapGesture";

            /// <summary>
            /// X coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("x")]
            public double X { get; set; }

            /// <summary>
            /// Y coordinate of the start of the gesture in CSS pixels.
            /// </summary>
            [JsonProperty("y")]
            public double Y { get; set; }

            /// <summary>
            /// Duration between touchdown and touchup events in ms (default: 50).
            /// </summary>
            [JsonProperty("duration")]
            public int Duration { get; set; }

            /// <summary>
            /// Number of times to perform the tap (e.g. 2 for double tap, default: 1).
            /// </summary>
            [JsonProperty("tapCount")]
            public int TapCount { get; set; }

            /// <summary>
            /// Which type of input events to be generated (default: 'default', which queries the platform
            /// for the preferred input type).
            /// </summary>
            [JsonProperty("gestureSourceType")]
            public GestureSourceType GestureSourceType { get; set; }
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

        /// <summary>
        /// Fired when remote debugging connection is about to be terminated. Contains detach reason.
        /// </summary>
        public class DetachedEvent : ICommand
        {
            string ICommand.Name { get; } = "Inspector.detached";

            /// <summary>
            /// The reason why connection has been terminated.
            /// </summary>
            [JsonProperty("reason")]
            public string Reason { get; set; }
        }

        /// <summary>
        /// Fired when debugging target has crashed
        /// </summary>
        public class TargetCrashedEvent : ICommand
        {
            string ICommand.Name { get; } = "Inspector.targetCrashed";
        }

        /// <summary>
        /// Fired when debugging target has reloaded after crash
        /// </summary>
        public class TargetReloadedAfterCrashEvent : ICommand
        {
            string ICommand.Name { get; } = "Inspector.targetReloadedAfterCrash";
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

            /// <summary>
            /// The id of the layer for which we want to get the reasons it was composited.
            /// </summary>
            [JsonProperty("layerId")]
            public LayerId LayerId { get; set; }
        }

        public class CompositingReasonsResponse
        {

            /// <summary>
            /// A list of strings specifying reasons for the given layer to become composited.
            /// </summary>
            [JsonProperty("compositingReasons")]
            public string[] CompositingReasons { get; set; }
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

            /// <summary>
            /// An array of tiles composing the snapshot.
            /// </summary>
            [JsonProperty("tiles")]
            public PictureTile[] Tiles { get; set; }
        }

        public class LoadSnapshotResponse
        {

            /// <summary>
            /// The id of the snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }
        }

        /// <summary>
        /// Returns the layer snapshot identifier.
        /// </summary>
        public class MakeSnapshotCommand : ICommand<MakeSnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.makeSnapshot";

            /// <summary>
            /// The id of the layer.
            /// </summary>
            [JsonProperty("layerId")]
            public LayerId LayerId { get; set; }
        }

        public class MakeSnapshotResponse
        {

            /// <summary>
            /// The id of the layer snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }
        }

        public class ProfileSnapshotCommand : ICommand<ProfileSnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.profileSnapshot";

            /// <summary>
            /// The id of the layer snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }

            /// <summary>
            /// The maximum number of times to replay the snapshot (1, if not specified).
            /// </summary>
            [JsonProperty("minRepeatCount")]
            public int MinRepeatCount { get; set; }

            /// <summary>
            /// The minimum duration (in seconds) to replay the snapshot.
            /// </summary>
            [JsonProperty("minDuration")]
            public double MinDuration { get; set; }

            /// <summary>
            /// The clip rectangle to apply when replaying the snapshot.
            /// </summary>
            [JsonProperty("clipRect")]
            public DOM.Rect ClipRect { get; set; }
        }

        public class ProfileSnapshotResponse
        {

            /// <summary>
            /// The array of paint profiles, one per run.
            /// </summary>
            [JsonProperty("timings")]
            public PaintProfile[] Timings { get; set; }
        }

        /// <summary>
        /// Releases layer snapshot captured by the back-end.
        /// </summary>
        public class ReleaseSnapshotCommand : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.releaseSnapshot";

            /// <summary>
            /// The id of the layer snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }
        }

        /// <summary>
        /// Replays the layer snapshot and returns the resulting bitmap.
        /// </summary>
        public class ReplaySnapshotCommand : ICommand<ReplaySnapshotResponse>
        {
            string ICommand.Name { get; } = "LayerTree.replaySnapshot";

            /// <summary>
            /// The id of the layer snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }

            /// <summary>
            /// The first step to replay from (replay from the very start if not specified).
            /// </summary>
            [JsonProperty("fromStep")]
            public int FromStep { get; set; }

            /// <summary>
            /// The last step to replay to (replay till the end if not specified).
            /// </summary>
            [JsonProperty("toStep")]
            public int ToStep { get; set; }

            /// <summary>
            /// The scale to apply while replaying (defaults to 1).
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }
        }

        public class ReplaySnapshotResponse
        {

            /// <summary>
            /// A data: URL for resulting image.
            /// </summary>
            [JsonProperty("dataURL")]
            public string DataURL { get; set; }
        }

        /// <summary>
        /// Replays the layer snapshot and returns canvas log.
        /// </summary>
        public class SnapshotCommandLogCommand : ICommand<SnapshotCommandLogResponse>
        {
            string ICommand.Name { get; } = "LayerTree.snapshotCommandLog";

            /// <summary>
            /// The id of the layer snapshot.
            /// </summary>
            [JsonProperty("snapshotId")]
            public SnapshotId SnapshotId { get; set; }
        }

        public class SnapshotCommandLogResponse
        {

            /// <summary>
            /// The array of canvas function calls.
            /// </summary>
            [JsonProperty("commandLog")]
            public object[] CommandLog { get; set; }
        }

        public class LayerPaintedEvent : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.layerPainted";

            /// <summary>
            /// The id of the painted layer.
            /// </summary>
            [JsonProperty("layerId")]
            public LayerId LayerId { get; set; }

            /// <summary>
            /// Clip rectangle.
            /// </summary>
            [JsonProperty("clip")]
            public DOM.Rect Clip { get; set; }
        }

        public class LayerTreeDidChangeEvent : ICommand
        {
            string ICommand.Name { get; } = "LayerTree.layerTreeDidChange";

            /// <summary>
            /// Layer tree, absent if not in the comspositing mode.
            /// </summary>
            [JsonProperty("layers")]
            public Layer[] Layers { get; set; }
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

            /// <summary>
            /// Configuration for violations.
            /// </summary>
            [JsonProperty("config")]
            public ViolationSetting[] Config { get; set; }
        }

        /// <summary>
        /// Stop violation reporting.
        /// </summary>
        public class StopViolationsReportCommand : ICommand
        {
            string ICommand.Name { get; } = "Log.stopViolationsReport";
        }

        /// <summary>
        /// Issued when new message was logged.
        /// </summary>
        public class EntryAddedEvent : ICommand
        {
            string ICommand.Name { get; } = "Log.entryAdded";

            /// <summary>
            /// The entry.
            /// </summary>
            [JsonProperty("entry")]
            public LogEntry Entry { get; set; }
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

            [JsonProperty("documents")]
            public int Documents { get; set; }

            [JsonProperty("nodes")]
            public int Nodes { get; set; }

            [JsonProperty("jsEventListeners")]
            public int JsEventListeners { get; set; }
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

            /// <summary>
            /// If true, memory pressure notifications will be suppressed.
            /// </summary>
            [JsonProperty("suppressed")]
            public bool Suppressed { get; set; }
        }

        /// <summary>
        /// Simulate a memory pressure notification in all processes.
        /// </summary>
        public class SimulatePressureNotificationCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.simulatePressureNotification";

            /// <summary>
            /// Memory pressure level of the notification.
            /// </summary>
            [JsonProperty("level")]
            public PressureLevel Level { get; set; }
        }

        /// <summary>
        /// Start collecting native memory profile.
        /// </summary>
        public class StartSamplingCommand : ICommand
        {
            string ICommand.Name { get; } = "Memory.startSampling";

            /// <summary>
            /// Average number of bytes between samples.
            /// </summary>
            [JsonProperty("samplingInterval")]
            public int SamplingInterval { get; set; }

            /// <summary>
            /// Do not randomize intervals between samples.
            /// </summary>
            [JsonProperty("suppressRandomness")]
            public bool SuppressRandomness { get; set; }
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

            [JsonProperty("profile")]
            public SamplingProfile Profile { get; set; }
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

            [JsonProperty("profile")]
            public SamplingProfile Profile { get; set; }
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

            [JsonProperty("profile")]
            public SamplingProfile Profile { get; set; }
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

            /// <summary>
            /// True if browser cache can be cleared.
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }
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

            /// <summary>
            /// True if browser cookies can be cleared.
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }
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

            /// <summary>
            /// True if emulation of network conditions is supported.
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }
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

            [JsonProperty("interceptionId")]
            public InterceptionId InterceptionId { get; set; }

            /// <summary>
            /// If set this causes the request to fail with the given reason. Passing `Aborted` for requests
            /// marked with `isNavigationRequest` also cancels the navigation. Must not be set in response
            /// to an authChallenge.
            /// </summary>
            [JsonProperty("errorReason")]
            public ErrorReason ErrorReason { get; set; }

            /// <summary>
            /// If set the requests completes using with the provided base64 encoded raw response, including
            /// HTTP status line and headers etc... Must not be set in response to an authChallenge.
            /// </summary>
            [JsonProperty("rawResponse")]
            public string RawResponse { get; set; }

            /// <summary>
            /// If set the request url will be modified in a way that's not observable by page. Must not be
            /// set in response to an authChallenge.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// If set this allows the request method to be overridden. Must not be set in response to an
            /// authChallenge.
            /// </summary>
            [JsonProperty("method")]
            public string Method { get; set; }

            /// <summary>
            /// If set this allows postData to be set. Must not be set in response to an authChallenge.
            /// </summary>
            [JsonProperty("postData")]
            public string PostData { get; set; }

            /// <summary>
            /// If set this allows the request headers to be changed. Must not be set in response to an
            /// authChallenge.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }

            /// <summary>
            /// Response to a requestIntercepted with an authChallenge. Must not be set otherwise.
            /// </summary>
            [JsonProperty("authChallengeResponse")]
            public AuthChallengeResponse AuthChallengeResponse { get; set; }
        }

        /// <summary>
        /// Deletes browser cookies with matching name and url or domain/path pair.
        /// </summary>
        public class DeleteCookiesCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.deleteCookies";

            /// <summary>
            /// Name of the cookies to remove.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// If specified, deletes all the cookies with the given name where domain and path match
            /// provided URL.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// If specified, deletes only cookies with the exact domain.
            /// </summary>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// If specified, deletes only cookies with the exact path.
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }
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

            /// <summary>
            /// True to emulate internet disconnection.
            /// </summary>
            [JsonProperty("offline")]
            public bool Offline { get; set; }

            /// <summary>
            /// Minimum latency from request sent to response headers received (ms).
            /// </summary>
            [JsonProperty("latency")]
            public double Latency { get; set; }

            /// <summary>
            /// Maximal aggregated download throughput (bytes/sec). -1 disables download throttling.
            /// </summary>
            [JsonProperty("downloadThroughput")]
            public double DownloadThroughput { get; set; }

            /// <summary>
            /// Maximal aggregated upload throughput (bytes/sec).  -1 disables upload throttling.
            /// </summary>
            [JsonProperty("uploadThroughput")]
            public double UploadThroughput { get; set; }

            /// <summary>
            /// Connection type if known.
            /// </summary>
            [JsonProperty("connectionType")]
            public ConnectionType ConnectionType { get; set; }
        }

        /// <summary>
        /// Enables network tracking, network events will now be delivered to the client.
        /// </summary>
        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.enable";

            /// <summary>
            /// Buffer size in bytes to use when preserving network payloads (XHRs, etc).
            /// </summary>
            [JsonProperty("maxTotalBufferSize")]
            public int MaxTotalBufferSize { get; set; }

            /// <summary>
            /// Per-resource buffer size in bytes to use when preserving network payloads (XHRs, etc).
            /// </summary>
            [JsonProperty("maxResourceBufferSize")]
            public int MaxResourceBufferSize { get; set; }

            /// <summary>
            /// Longest post body size (in bytes) that would be included in requestWillBeSent notification
            /// </summary>
            [JsonProperty("maxPostDataSize")]
            public int MaxPostDataSize { get; set; }
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

            /// <summary>
            /// Array of cookie objects.
            /// </summary>
            [JsonProperty("cookies")]
            public Cookie[] Cookies { get; set; }
        }

        /// <summary>
        /// Returns the DER-encoded certificate.
        /// </summary>
        public class GetCertificateCommand : ICommand<GetCertificateResponse>
        {
            string ICommand.Name { get; } = "Network.getCertificate";

            /// <summary>
            /// Origin to get certificate for.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        public class GetCertificateResponse
        {

            [JsonProperty("tableNames")]
            public string[] TableNames { get; set; }
        }

        /// <summary>
        /// Returns all browser cookies for the current URL. Depending on the backend support, will return
        /// detailed cookie information in the `cookies` field.
        /// </summary>
        public class GetCookiesCommand : ICommand<GetCookiesResponse>
        {
            string ICommand.Name { get; } = "Network.getCookies";

            /// <summary>
            /// The list of URLs for which applicable cookies will be fetched
            /// </summary>
            [JsonProperty("urls")]
            public string[] Urls { get; set; }
        }

        public class GetCookiesResponse
        {

            /// <summary>
            /// Array of cookie objects.
            /// </summary>
            [JsonProperty("cookies")]
            public Cookie[] Cookies { get; set; }
        }

        /// <summary>
        /// Returns content served for the given request.
        /// </summary>
        public class GetResponseBodyCommand : ICommand<GetResponseBodyResponse>
        {
            string ICommand.Name { get; } = "Network.getResponseBody";

            /// <summary>
            /// Identifier of the network request to get content for.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        public class GetResponseBodyResponse
        {

            /// <summary>
            /// Response body.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }

            /// <summary>
            /// True, if content was sent as base64.
            /// </summary>
            [JsonProperty("base64Encoded")]
            public bool Base64Encoded { get; set; }
        }

        /// <summary>
        /// Returns post data sent with the request. Returns an error when no data was sent with the request.
        /// </summary>
        public class GetRequestPostDataCommand : ICommand<GetRequestPostDataResponse>
        {
            string ICommand.Name { get; } = "Network.getRequestPostData";

            /// <summary>
            /// Identifier of the network request to get content for.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        public class GetRequestPostDataResponse
        {

            /// <summary>
            /// Request body string, omitting files from multipart requests
            /// </summary>
            [JsonProperty("postData")]
            public string PostData { get; set; }
        }

        /// <summary>
        /// Returns content served for the given currently intercepted request.
        /// </summary>
        public class GetResponseBodyForInterceptionCommand : ICommand<GetResponseBodyForInterceptionResponse>
        {
            string ICommand.Name { get; } = "Network.getResponseBodyForInterception";

            /// <summary>
            /// Identifier for the intercepted request to get body for.
            /// </summary>
            [JsonProperty("interceptionId")]
            public InterceptionId InterceptionId { get; set; }
        }

        public class GetResponseBodyForInterceptionResponse
        {

            /// <summary>
            /// Response body.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }

            /// <summary>
            /// True, if content was sent as base64.
            /// </summary>
            [JsonProperty("base64Encoded")]
            public bool Base64Encoded { get; set; }
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

            [JsonProperty("interceptionId")]
            public InterceptionId InterceptionId { get; set; }
        }

        public class TakeResponseBodyForInterceptionAsStreamResponse
        {

            [JsonProperty("stream")]
            public IO.StreamHandle Stream { get; set; }
        }

        /// <summary>
        /// This method sends a new XMLHttpRequest which is identical to the original one. The following
        /// parameters should be identical: method, url, async, request body, extra headers, withCredentials
        /// attribute, user, password.
        /// </summary>
        public class ReplayXHRCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.replayXHR";

            /// <summary>
            /// Identifier of XHR to replay.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        /// <summary>
        /// Searches for given string in response content.
        /// </summary>
        public class SearchInResponseBodyCommand : ICommand<SearchInResponseBodyResponse>
        {
            string ICommand.Name { get; } = "Network.searchInResponseBody";

            /// <summary>
            /// Identifier of the network response to search.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// String to search for.
            /// </summary>
            [JsonProperty("query")]
            public string Query { get; set; }

            /// <summary>
            /// If true, search is case sensitive.
            /// </summary>
            [JsonProperty("caseSensitive")]
            public bool CaseSensitive { get; set; }

            /// <summary>
            /// If true, treats string parameter as regex.
            /// </summary>
            [JsonProperty("isRegex")]
            public bool IsRegex { get; set; }
        }

        public class SearchInResponseBodyResponse
        {

            /// <summary>
            /// List of search matches.
            /// </summary>
            [JsonProperty("result")]
            public Debugger.SearchMatch[] Result { get; set; }
        }

        /// <summary>
        /// Blocks URLs from loading.
        /// </summary>
        public class SetBlockedURLsCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setBlockedURLs";

            /// <summary>
            /// URL patterns to block. Wildcards ('*') are allowed.
            /// </summary>
            [JsonProperty("urls")]
            public string[] Urls { get; set; }
        }

        /// <summary>
        /// Toggles ignoring of service worker for each request.
        /// </summary>
        public class SetBypassServiceWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setBypassServiceWorker";

            /// <summary>
            /// Bypass service worker and load from network.
            /// </summary>
            [JsonProperty("bypass")]
            public bool Bypass { get; set; }
        }

        /// <summary>
        /// Toggles ignoring cache for each request. If `true`, cache will not be used.
        /// </summary>
        public class SetCacheDisabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setCacheDisabled";

            /// <summary>
            /// Cache disabled state.
            /// </summary>
            [JsonProperty("cacheDisabled")]
            public bool CacheDisabled { get; set; }
        }

        /// <summary>
        /// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
        /// </summary>
        public class SetCookieCommand : ICommand<SetCookieResponse>
        {
            string ICommand.Name { get; } = "Network.setCookie";

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

        public class SetCookieResponse
        {

            /// <summary>
            /// True if successfully set cookie.
            /// </summary>
            [JsonProperty("success")]
            public bool Success { get; set; }
        }

        /// <summary>
        /// Sets given cookies.
        /// </summary>
        public class SetCookiesCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setCookies";

            /// <summary>
            /// Cookies to be set.
            /// </summary>
            [JsonProperty("cookies")]
            public CookieParam[] Cookies { get; set; }
        }

        /// <summary>
        /// For testing.
        /// </summary>
        public class SetDataSizeLimitsForTestCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setDataSizeLimitsForTest";

            /// <summary>
            /// Maximum total buffer size.
            /// </summary>
            [JsonProperty("maxTotalSize")]
            public int MaxTotalSize { get; set; }

            /// <summary>
            /// Maximum per-resource size.
            /// </summary>
            [JsonProperty("maxResourceSize")]
            public int MaxResourceSize { get; set; }
        }

        /// <summary>
        /// Specifies whether to always send extra HTTP headers with the requests from this page.
        /// </summary>
        public class SetExtraHTTPHeadersCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setExtraHTTPHeaders";

            /// <summary>
            /// Map with extra HTTP headers.
            /// </summary>
            [JsonProperty("headers")]
            public Headers Headers { get; set; }
        }

        /// <summary>
        /// Sets the requests to intercept that match a the provided patterns and optionally resource types.
        /// </summary>
        public class SetRequestInterceptionCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setRequestInterception";

            /// <summary>
            /// Requests matching any of these patterns will be forwarded and wait for the corresponding
            /// continueInterceptedRequest call.
            /// </summary>
            [JsonProperty("patterns")]
            public RequestPattern[] Patterns { get; set; }
        }

        /// <summary>
        /// Allows overriding user agent with the given string.
        /// </summary>
        public class SetUserAgentOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Network.setUserAgentOverride";

            /// <summary>
            /// User agent to use.
            /// </summary>
            [JsonProperty("userAgent")]
            public string UserAgent { get; set; }

            /// <summary>
            /// Browser langugage to emulate.
            /// </summary>
            [JsonProperty("acceptLanguage")]
            public string AcceptLanguage { get; set; }

            /// <summary>
            /// The platform navigator.platform should return.
            /// </summary>
            [JsonProperty("platform")]
            public string Platform { get; set; }
        }

        /// <summary>
        /// Fired when data chunk was received over the network.
        /// </summary>
        public class DataReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.dataReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Data chunk length.
            /// </summary>
            [JsonProperty("dataLength")]
            public int DataLength { get; set; }

            /// <summary>
            /// Actual bytes received (might be less than dataLength for compressed encodings).
            /// </summary>
            [JsonProperty("encodedDataLength")]
            public int EncodedDataLength { get; set; }
        }

        /// <summary>
        /// Fired when EventSource message is received.
        /// </summary>
        public class EventSourceMessageReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.eventSourceMessageReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Message type.
            /// </summary>
            [JsonProperty("eventName")]
            public string EventName { get; set; }

            /// <summary>
            /// Message identifier.
            /// </summary>
            [JsonProperty("eventId")]
            public string EventId { get; set; }

            /// <summary>
            /// Message content.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
        }

        /// <summary>
        /// Fired when HTTP request has failed to load.
        /// </summary>
        public class LoadingFailedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.loadingFailed";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Resource type.
            /// </summary>
            [JsonProperty("type")]
            public ResourceType Type { get; set; }

            /// <summary>
            /// User friendly error message.
            /// </summary>
            [JsonProperty("errorText")]
            public string ErrorText { get; set; }

            /// <summary>
            /// True if loading was canceled.
            /// </summary>
            [JsonProperty("canceled")]
            public bool Canceled { get; set; }

            /// <summary>
            /// The reason why loading was blocked, if any.
            /// </summary>
            [JsonProperty("blockedReason")]
            public BlockedReason BlockedReason { get; set; }
        }

        /// <summary>
        /// Fired when HTTP request has finished loading.
        /// </summary>
        public class LoadingFinishedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.loadingFinished";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Total number of bytes received for this request.
            /// </summary>
            [JsonProperty("encodedDataLength")]
            public double EncodedDataLength { get; set; }

            /// <summary>
            /// Set when 1) response was blocked by Cross-Origin Read Blocking and also
            /// 2) this needs to be reported to the DevTools console.
            /// </summary>
            [JsonProperty("shouldReportCorbBlocking")]
            public bool ShouldReportCorbBlocking { get; set; }
        }

        /// <summary>
        /// Details of an intercepted HTTP request, which must be either allowed, blocked, modified or
        /// mocked.
        /// </summary>
        public class RequestInterceptedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.requestIntercepted";

            /// <summary>
            /// Each request the page makes will have a unique id, however if any redirects are encountered
            /// while processing that fetch, they will be reported with the same id as the original fetch.
            /// Likewise if HTTP authentication is needed then the same fetch id will be used.
            /// </summary>
            [JsonProperty("interceptionId")]
            public InterceptionId InterceptionId { get; set; }

            [JsonProperty("request")]
            public Request Request { get; set; }

            /// <summary>
            /// The id of the frame that initiated the request.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// How the requested resource will be used.
            /// </summary>
            [JsonProperty("resourceType")]
            public ResourceType ResourceType { get; set; }

            /// <summary>
            /// Whether this is a navigation request, which can abort the navigation completely.
            /// </summary>
            [JsonProperty("isNavigationRequest")]
            public bool IsNavigationRequest { get; set; }

            /// <summary>
            /// Set if the request is a navigation that will result in a download.
            /// Only present after response is received from the server (i.e. HeadersReceived stage).
            /// </summary>
            [JsonProperty("isDownload")]
            public bool IsDownload { get; set; }

            /// <summary>
            /// Redirect location, only sent if a redirect was intercepted.
            /// </summary>
            [JsonProperty("redirectUrl")]
            public string RedirectUrl { get; set; }

            /// <summary>
            /// Details of the Authorization Challenge encountered. If this is set then
            /// continueInterceptedRequest must contain an authChallengeResponse.
            /// </summary>
            [JsonProperty("authChallenge")]
            public AuthChallenge AuthChallenge { get; set; }

            /// <summary>
            /// Response error if intercepted at response stage or if redirect occurred while intercepting
            /// request.
            /// </summary>
            [JsonProperty("responseErrorReason")]
            public ErrorReason ResponseErrorReason { get; set; }

            /// <summary>
            /// Response code if intercepted at response stage or if redirect occurred while intercepting
            /// request or auth retry occurred.
            /// </summary>
            [JsonProperty("responseStatusCode")]
            public int ResponseStatusCode { get; set; }

            /// <summary>
            /// Response headers if intercepted at the response stage or if redirect occurred while
            /// intercepting request or auth retry occurred.
            /// </summary>
            [JsonProperty("responseHeaders")]
            public Headers ResponseHeaders { get; set; }
        }

        /// <summary>
        /// Fired if request ended up loading from cache.
        /// </summary>
        public class RequestServedFromCacheEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.requestServedFromCache";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        /// <summary>
        /// Fired when page is about to send HTTP request.
        /// </summary>
        public class RequestWillBeSentEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.requestWillBeSent";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Loader identifier. Empty string if the request is fetched from worker.
            /// </summary>
            [JsonProperty("loaderId")]
            public LoaderId LoaderId { get; set; }

            /// <summary>
            /// URL of the document this request is loaded for.
            /// </summary>
            [JsonProperty("documentURL")]
            public string DocumentURL { get; set; }

            /// <summary>
            /// Request data.
            /// </summary>
            [JsonProperty("request")]
            public Request Request { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("wallTime")]
            public TimeSinceEpoch WallTime { get; set; }

            /// <summary>
            /// Request initiator.
            /// </summary>
            [JsonProperty("initiator")]
            public Initiator Initiator { get; set; }

            /// <summary>
            /// Redirect response data.
            /// </summary>
            [JsonProperty("redirectResponse")]
            public Response RedirectResponse { get; set; }

            /// <summary>
            /// Type of this resource.
            /// </summary>
            [JsonProperty("type")]
            public ResourceType Type { get; set; }

            /// <summary>
            /// Frame identifier.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// Whether the request is initiated by a user gesture. Defaults to false.
            /// </summary>
            [JsonProperty("hasUserGesture")]
            public bool HasUserGesture { get; set; }
        }

        /// <summary>
        /// Fired when resource loading priority is changed
        /// </summary>
        public class ResourceChangedPriorityEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.resourceChangedPriority";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// New priority
            /// </summary>
            [JsonProperty("newPriority")]
            public ResourcePriority NewPriority { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }
        }

        /// <summary>
        /// Fired when a signed exchange was received over the network
        /// </summary>
        public class SignedExchangeReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.signedExchangeReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Information about the signed exchange response.
            /// </summary>
            [JsonProperty("info")]
            public SignedExchangeInfo Info { get; set; }
        }

        /// <summary>
        /// Fired when HTTP response is available.
        /// </summary>
        public class ResponseReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.responseReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Loader identifier. Empty string if the request is fetched from worker.
            /// </summary>
            [JsonProperty("loaderId")]
            public LoaderId LoaderId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// Resource type.
            /// </summary>
            [JsonProperty("type")]
            public ResourceType Type { get; set; }

            /// <summary>
            /// Response data.
            /// </summary>
            [JsonProperty("response")]
            public Response Response { get; set; }

            /// <summary>
            /// Frame identifier.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket is closed.
        /// </summary>
        public class WebSocketClosedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketClosed";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }
        }

        /// <summary>
        /// Fired upon WebSocket creation.
        /// </summary>
        public class WebSocketCreatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketCreated";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// WebSocket request URL.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Request initiator.
            /// </summary>
            [JsonProperty("initiator")]
            public Initiator Initiator { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket message error occurs.
        /// </summary>
        public class WebSocketFrameErrorEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketFrameError";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// WebSocket error message.
            /// </summary>
            [JsonProperty("errorMessage")]
            public string ErrorMessage { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket message is received.
        /// </summary>
        public class WebSocketFrameReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketFrameReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// WebSocket response data.
            /// </summary>
            [JsonProperty("response")]
            public WebSocketFrame Response { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket message is sent.
        /// </summary>
        public class WebSocketFrameSentEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketFrameSent";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// WebSocket response data.
            /// </summary>
            [JsonProperty("response")]
            public WebSocketFrame Response { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket handshake response becomes available.
        /// </summary>
        public class WebSocketHandshakeResponseReceivedEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketHandshakeResponseReceived";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// WebSocket response data.
            /// </summary>
            [JsonProperty("response")]
            public WebSocketResponse Response { get; set; }
        }

        /// <summary>
        /// Fired when WebSocket is about to initiate handshake.
        /// </summary>
        public class WebSocketWillSendHandshakeRequestEvent : ICommand
        {
            string ICommand.Name { get; } = "Network.webSocketWillSendHandshakeRequest";

            /// <summary>
            /// Request identifier.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Timestamp.
            /// </summary>
            [JsonProperty("timestamp")]
            public MonotonicTime Timestamp { get; set; }

            /// <summary>
            /// UTC Timestamp.
            /// </summary>
            [JsonProperty("wallTime")]
            public TimeSinceEpoch WallTime { get; set; }

            /// <summary>
            /// WebSocket request data.
            /// </summary>
            [JsonProperty("request")]
            public WebSocketRequest Request { get; set; }
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

            /// <summary>
            /// Id of the node to get highlight object for.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        public class GetHighlightObjectForTestResponse
        {

            /// <summary>
            /// Highlight data for the node.
            /// </summary>
            [JsonProperty("highlight")]
            public object Highlight { get; set; }
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

            /// <summary>
            /// Identifier of the frame to highlight.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// The content box highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("contentColor")]
            public DOM.RGBA ContentColor { get; set; }

            /// <summary>
            /// The content box highlight outline color (default: transparent).
            /// </summary>
            [JsonProperty("contentOutlineColor")]
            public DOM.RGBA ContentOutlineColor { get; set; }
        }

        /// <summary>
        /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
        /// objectId must be specified.
        /// </summary>
        public class HighlightNodeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightNode";

            /// <summary>
            /// A descriptor for the highlight appearance.
            /// </summary>
            [JsonProperty("highlightConfig")]
            public HighlightConfig HighlightConfig { get; set; }

            /// <summary>
            /// Identifier of the node to highlight.
            /// </summary>
            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }

            /// <summary>
            /// Identifier of the backend node to highlight.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }

            /// <summary>
            /// JavaScript object id of the node to be highlighted.
            /// </summary>
            [JsonProperty("objectId")]
            public Runtime.RemoteObjectId ObjectId { get; set; }
        }

        /// <summary>
        /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
        /// </summary>
        public class HighlightQuadCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightQuad";

            /// <summary>
            /// Quad to highlight
            /// </summary>
            [JsonProperty("quad")]
            public DOM.Quad Quad { get; set; }

            /// <summary>
            /// The highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("color")]
            public DOM.RGBA Color { get; set; }

            /// <summary>
            /// The highlight outline color (default: transparent).
            /// </summary>
            [JsonProperty("outlineColor")]
            public DOM.RGBA OutlineColor { get; set; }
        }

        /// <summary>
        /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
        /// </summary>
        public class HighlightRectCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.highlightRect";

            /// <summary>
            /// X coordinate
            /// </summary>
            [JsonProperty("x")]
            public int X { get; set; }

            /// <summary>
            /// Y coordinate
            /// </summary>
            [JsonProperty("y")]
            public int Y { get; set; }

            /// <summary>
            /// Rectangle width
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Rectangle height
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// The highlight fill color (default: transparent).
            /// </summary>
            [JsonProperty("color")]
            public DOM.RGBA Color { get; set; }

            /// <summary>
            /// The highlight outline color (default: transparent).
            /// </summary>
            [JsonProperty("outlineColor")]
            public DOM.RGBA OutlineColor { get; set; }
        }

        /// <summary>
        /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
        /// Backend then generates 'inspectNodeRequested' event upon element selection.
        /// </summary>
        public class SetInspectModeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setInspectMode";

            /// <summary>
            /// Set an inspection mode.
            /// </summary>
            [JsonProperty("mode")]
            public InspectMode Mode { get; set; }

            /// <summary>
            /// A descriptor for the highlight appearance of hovered-over nodes. May be omitted if `enabled
            /// == false`.
            /// </summary>
            [JsonProperty("highlightConfig")]
            public HighlightConfig HighlightConfig { get; set; }
        }

        public class SetPausedInDebuggerMessageCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setPausedInDebuggerMessage";

            /// <summary>
            /// The message to display, also triggers resume and step over controls.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }
        }

        /// <summary>
        /// Requests that backend shows debug borders on layers
        /// </summary>
        public class SetShowDebugBordersCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowDebugBorders";

            /// <summary>
            /// True for showing debug borders
            /// </summary>
            [JsonProperty("show")]
            public bool Show { get; set; }
        }

        /// <summary>
        /// Requests that backend shows the FPS counter
        /// </summary>
        public class SetShowFPSCounterCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowFPSCounter";

            /// <summary>
            /// True for showing the FPS counter
            /// </summary>
            [JsonProperty("show")]
            public bool Show { get; set; }
        }

        /// <summary>
        /// Requests that backend shows paint rectangles
        /// </summary>
        public class SetShowPaintRectsCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowPaintRects";

            /// <summary>
            /// True for showing paint rectangles
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }
        }

        /// <summary>
        /// Requests that backend shows scroll bottleneck rects
        /// </summary>
        public class SetShowScrollBottleneckRectsCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowScrollBottleneckRects";

            /// <summary>
            /// True for showing scroll bottleneck rects
            /// </summary>
            [JsonProperty("show")]
            public bool Show { get; set; }
        }

        /// <summary>
        /// Requests that backend shows hit-test borders on layers
        /// </summary>
        public class SetShowHitTestBordersCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowHitTestBorders";

            /// <summary>
            /// True for showing hit-test borders
            /// </summary>
            [JsonProperty("show")]
            public bool Show { get; set; }
        }

        /// <summary>
        /// Paints viewport size upon main frame resize.
        /// </summary>
        public class SetShowViewportSizeOnResizeCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setShowViewportSizeOnResize";

            /// <summary>
            /// Whether to paint size or not.
            /// </summary>
            [JsonProperty("show")]
            public bool Show { get; set; }
        }

        public class SetSuspendedCommand : ICommand
        {
            string ICommand.Name { get; } = "Overlay.setSuspended";

            /// <summary>
            /// Whether overlay should be suspended and not consume any resources until resumed.
            /// </summary>
            [JsonProperty("suspended")]
            public bool Suspended { get; set; }
        }

        /// <summary>
        /// Fired when the node should be inspected. This happens after call to `setInspectMode` or when
        /// user manually inspects an element.
        /// </summary>
        public class InspectNodeRequestedEvent : ICommand
        {
            string ICommand.Name { get; } = "Overlay.inspectNodeRequested";

            /// <summary>
            /// Id of the node to inspect.
            /// </summary>
            [JsonProperty("backendNodeId")]
            public DOM.BackendNodeId BackendNodeId { get; set; }
        }

        /// <summary>
        /// Fired when the node should be highlighted. This happens after call to `setInspectMode`.
        /// </summary>
        public class NodeHighlightRequestedEvent : ICommand
        {
            string ICommand.Name { get; } = "Overlay.nodeHighlightRequested";

            [JsonProperty("nodeId")]
            public DOM.NodeId NodeId { get; set; }
        }

        /// <summary>
        /// Fired when user asks to capture screenshot of some area on the page.
        /// </summary>
        public class ScreenshotRequestedEvent : ICommand
        {
            string ICommand.Name { get; } = "Overlay.screenshotRequested";

            /// <summary>
            /// Viewport to capture, in device independent pixels (dip).
            /// </summary>
            [JsonProperty("viewport")]
            public Page.Viewport Viewport { get; set; }
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

            [JsonProperty("scriptSource")]
            public string ScriptSource { get; set; }
        }

        public class AddScriptToEvaluateOnLoadResponse
        {

            /// <summary>
            /// Identifier of the added script.
            /// </summary>
            [JsonProperty("identifier")]
            public ScriptIdentifier Identifier { get; set; }
        }

        /// <summary>
        /// Evaluates given script in every frame upon creation (before loading frame's scripts).
        /// </summary>
        public class AddScriptToEvaluateOnNewDocumentCommand : ICommand<AddScriptToEvaluateOnNewDocumentResponse>
        {
            string ICommand.Name { get; } = "Page.addScriptToEvaluateOnNewDocument";

            [JsonProperty("source")]
            public string Source { get; set; }

            /// <summary>
            /// If specified, creates an isolated world with the given name and evaluates given script in it.
            /// This world name will be used as the ExecutionContextDescription::name when the corresponding
            /// event is emitted.
            /// </summary>
            [JsonProperty("worldName")]
            public string WorldName { get; set; }
        }

        public class AddScriptToEvaluateOnNewDocumentResponse
        {

            /// <summary>
            /// Identifier of the added script.
            /// </summary>
            [JsonProperty("identifier")]
            public ScriptIdentifier Identifier { get; set; }
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

            /// <summary>
            /// Capture the screenshot of a given region only.
            /// </summary>
            [JsonProperty("clip")]
            public Viewport Clip { get; set; }

            /// <summary>
            /// Capture the screenshot from the surface, rather than the view. Defaults to true.
            /// </summary>
            [JsonProperty("fromSurface")]
            public bool FromSurface { get; set; }
        }

        public class CaptureScreenshotResponse
        {

            /// <summary>
            /// Base64-encoded image data.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
        }

        /// <summary>
        /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
        /// iframes, shadow DOM, external resources, and element-inline styles.
        /// </summary>
        public class CaptureSnapshotCommand : ICommand<CaptureSnapshotResponse>
        {
            string ICommand.Name { get; } = "Page.captureSnapshot";

            /// <summary>
            /// Format (defaults to mhtml).
            /// </summary>
            [JsonProperty("format")]
            public string Format { get; set; }
        }

        public class CaptureSnapshotResponse
        {

            /// <summary>
            /// Serialized page data.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
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

            /// <summary>
            /// Id of the frame in which the isolated world should be created.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// An optional name which is reported in the Execution Context.
            /// </summary>
            [JsonProperty("worldName")]
            public string WorldName { get; set; }

            /// <summary>
            /// Whether or not universal access should be granted to the isolated world. This is a powerful
            /// option, use with caution.
            /// </summary>
            [JsonProperty("grantUniveralAccess")]
            public bool GrantUniveralAccess { get; set; }
        }

        public class CreateIsolatedWorldResponse
        {

            /// <summary>
            /// Execution context of the isolated world.
            /// </summary>
            [JsonProperty("executionContextId")]
            public Runtime.ExecutionContextId ExecutionContextId { get; set; }
        }

        /// <summary>
        /// Deletes browser cookie with given name, domain and path.
        /// </summary>
        [Obsolete]
        public class DeleteCookieCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.deleteCookie";

            /// <summary>
            /// Name of the cookie to remove.
            /// </summary>
            [JsonProperty("cookieName")]
            public string CookieName { get; set; }

            /// <summary>
            /// URL to match cooke domain and path.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
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

            /// <summary>
            /// Manifest location.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("errors")]
            public AppManifestError[] Errors { get; set; }

            /// <summary>
            /// Manifest content.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
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

            /// <summary>
            /// Array of cookie objects.
            /// </summary>
            [JsonProperty("cookies")]
            public Network.Cookie[] Cookies { get; set; }
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

            /// <summary>
            /// Present frame tree structure.
            /// </summary>
            [JsonProperty("frameTree")]
            public FrameTree FrameTree { get; set; }
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

            /// <summary>
            /// Metrics relating to the layout viewport.
            /// </summary>
            [JsonProperty("layoutViewport")]
            public LayoutViewport LayoutViewport { get; set; }

            /// <summary>
            /// Metrics relating to the visual viewport.
            /// </summary>
            [JsonProperty("visualViewport")]
            public VisualViewport VisualViewport { get; set; }

            /// <summary>
            /// Size of scrollable area.
            /// </summary>
            [JsonProperty("contentSize")]
            public DOM.Rect ContentSize { get; set; }
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

            /// <summary>
            /// Index of the current navigation history entry.
            /// </summary>
            [JsonProperty("currentIndex")]
            public int CurrentIndex { get; set; }

            /// <summary>
            /// Array of navigation history entries.
            /// </summary>
            [JsonProperty("entries")]
            public NavigationEntry[] Entries { get; set; }
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

            /// <summary>
            /// Frame id to get resource for.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// URL of the resource to get content for.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class GetResourceContentResponse
        {

            /// <summary>
            /// Resource content.
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }

            /// <summary>
            /// True, if content was served as base64.
            /// </summary>
            [JsonProperty("base64Encoded")]
            public bool Base64Encoded { get; set; }
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

            /// <summary>
            /// Present frame / resource tree structure.
            /// </summary>
            [JsonProperty("frameTree")]
            public FrameResourceTree FrameTree { get; set; }
        }

        /// <summary>
        /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
        /// </summary>
        public class HandleJavaScriptDialogCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.handleJavaScriptDialog";

            /// <summary>
            /// Whether to accept or dismiss the dialog.
            /// </summary>
            [JsonProperty("accept")]
            public bool Accept { get; set; }

            /// <summary>
            /// The text to enter into the dialog prompt before accepting. Used only if this is a prompt
            /// dialog.
            /// </summary>
            [JsonProperty("promptText")]
            public string PromptText { get; set; }
        }

        /// <summary>
        /// Navigates current page to the given URL.
        /// </summary>
        public class NavigateCommand : ICommand<NavigateResponse>
        {
            string ICommand.Name { get; } = "Page.navigate";

            /// <summary>
            /// URL to navigate the page to.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Referrer URL.
            /// </summary>
            [JsonProperty("referrer")]
            public string Referrer { get; set; }

            /// <summary>
            /// Intended transition type.
            /// </summary>
            [JsonProperty("transitionType")]
            public TransitionType TransitionType { get; set; }

            /// <summary>
            /// Frame id to navigate, if not specified navigates the top frame.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }
        }

        public class NavigateResponse
        {

            /// <summary>
            /// Frame id that has navigated (or failed to navigate)
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// Loader identifier.
            /// </summary>
            [JsonProperty("loaderId")]
            public Network.LoaderId LoaderId { get; set; }

            /// <summary>
            /// User friendly error message, present if and only if navigation has failed.
            /// </summary>
            [JsonProperty("errorText")]
            public string ErrorText { get; set; }
        }

        /// <summary>
        /// Navigates current page to the given history entry.
        /// </summary>
        public class NavigateToHistoryEntryCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.navigateToHistoryEntry";

            /// <summary>
            /// Unique id of the entry to navigate to.
            /// </summary>
            [JsonProperty("entryId")]
            public int EntryId { get; set; }
        }

        /// <summary>
        /// Print page as PDF.
        /// </summary>
        public class PrintToPDFCommand : ICommand<PrintToPDFResponse>
        {
            string ICommand.Name { get; } = "Page.printToPDF";

            /// <summary>
            /// Paper orientation. Defaults to false.
            /// </summary>
            [JsonProperty("landscape")]
            public bool Landscape { get; set; }

            /// <summary>
            /// Display header and footer. Defaults to false.
            /// </summary>
            [JsonProperty("displayHeaderFooter")]
            public bool DisplayHeaderFooter { get; set; }

            /// <summary>
            /// Print background graphics. Defaults to false.
            /// </summary>
            [JsonProperty("printBackground")]
            public bool PrintBackground { get; set; }

            /// <summary>
            /// Scale of the webpage rendering. Defaults to 1.
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }

            /// <summary>
            /// Paper width in inches. Defaults to 8.5 inches.
            /// </summary>
            [JsonProperty("paperWidth")]
            public double PaperWidth { get; set; }

            /// <summary>
            /// Paper height in inches. Defaults to 11 inches.
            /// </summary>
            [JsonProperty("paperHeight")]
            public double PaperHeight { get; set; }

            /// <summary>
            /// Top margin in inches. Defaults to 1cm (~0.4 inches).
            /// </summary>
            [JsonProperty("marginTop")]
            public double MarginTop { get; set; }

            /// <summary>
            /// Bottom margin in inches. Defaults to 1cm (~0.4 inches).
            /// </summary>
            [JsonProperty("marginBottom")]
            public double MarginBottom { get; set; }

            /// <summary>
            /// Left margin in inches. Defaults to 1cm (~0.4 inches).
            /// </summary>
            [JsonProperty("marginLeft")]
            public double MarginLeft { get; set; }

            /// <summary>
            /// Right margin in inches. Defaults to 1cm (~0.4 inches).
            /// </summary>
            [JsonProperty("marginRight")]
            public double MarginRight { get; set; }

            /// <summary>
            /// Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string, which means
            /// print all pages.
            /// </summary>
            [JsonProperty("pageRanges")]
            public string PageRanges { get; set; }

            /// <summary>
            /// Whether to silently ignore invalid but successfully parsed page ranges, such as '3-2'.
            /// Defaults to false.
            /// </summary>
            [JsonProperty("ignoreInvalidPageRanges")]
            public bool IgnoreInvalidPageRanges { get; set; }

            /// <summary>
            /// HTML template for the print header. Should be valid HTML markup with following
            /// classes used to inject printing values into them:
            /// - `date`: formatted print date
            /// - `title`: document title
            /// - `url`: document location
            /// - `pageNumber`: current page number
            /// - `totalPages`: total pages in the document
            /// 
            /// For example, `&lt;span class=title&gt;&lt;/span&gt;` would generate span containing the title.
            /// </summary>
            [JsonProperty("headerTemplate")]
            public string HeaderTemplate { get; set; }

            /// <summary>
            /// HTML template for the print footer. Should use the same format as the `headerTemplate`.
            /// </summary>
            [JsonProperty("footerTemplate")]
            public string FooterTemplate { get; set; }

            /// <summary>
            /// Whether or not to prefer page size as defined by css. Defaults to false,
            /// in which case the content will be scaled to fit the paper size.
            /// </summary>
            [JsonProperty("preferCSSPageSize")]
            public bool PreferCSSPageSize { get; set; }
        }

        public class PrintToPDFResponse
        {

            /// <summary>
            /// Base64-encoded pdf data.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
        }

        /// <summary>
        /// Reloads given page optionally ignoring the cache.
        /// </summary>
        public class ReloadCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.reload";

            /// <summary>
            /// If true, browser cache is ignored (as if the user pressed Shift+refresh).
            /// </summary>
            [JsonProperty("ignoreCache")]
            public bool IgnoreCache { get; set; }

            /// <summary>
            /// If set, the script will be injected into all frames of the inspected page after reload.
            /// Argument will be ignored if reloading dataURL origin.
            /// </summary>
            [JsonProperty("scriptToEvaluateOnLoad")]
            public string ScriptToEvaluateOnLoad { get; set; }
        }

        /// <summary>
        /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
        /// </summary>
        [Obsolete]
        public class RemoveScriptToEvaluateOnLoadCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.removeScriptToEvaluateOnLoad";

            [JsonProperty("identifier")]
            public ScriptIdentifier Identifier { get; set; }
        }

        /// <summary>
        /// Removes given script from the list.
        /// </summary>
        public class RemoveScriptToEvaluateOnNewDocumentCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.removeScriptToEvaluateOnNewDocument";

            [JsonProperty("identifier")]
            public ScriptIdentifier Identifier { get; set; }
        }

        /// <summary>
        /// Acknowledges that a screencast frame has been received by the frontend.
        /// </summary>
        public class ScreencastFrameAckCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.screencastFrameAck";

            /// <summary>
            /// Frame number.
            /// </summary>
            [JsonProperty("sessionId")]
            public int SessionId { get; set; }
        }

        /// <summary>
        /// Searches for given string in resource content.
        /// </summary>
        public class SearchInResourceCommand : ICommand<SearchInResourceResponse>
        {
            string ICommand.Name { get; } = "Page.searchInResource";

            /// <summary>
            /// Frame id for resource to search in.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// URL of the resource to search in.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// String to search for.
            /// </summary>
            [JsonProperty("query")]
            public string Query { get; set; }

            /// <summary>
            /// If true, search is case sensitive.
            /// </summary>
            [JsonProperty("caseSensitive")]
            public bool CaseSensitive { get; set; }

            /// <summary>
            /// If true, treats string parameter as regex.
            /// </summary>
            [JsonProperty("isRegex")]
            public bool IsRegex { get; set; }
        }

        public class SearchInResourceResponse
        {

            /// <summary>
            /// List of search matches.
            /// </summary>
            [JsonProperty("result")]
            public Debugger.SearchMatch[] Result { get; set; }
        }

        /// <summary>
        /// Enable Chrome's experimental ad filter on all sites.
        /// </summary>
        public class SetAdBlockingEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setAdBlockingEnabled";

            /// <summary>
            /// Whether to block ads.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Enable page Content Security Policy by-passing.
        /// </summary>
        public class SetBypassCSPCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setBypassCSP";

            /// <summary>
            /// Whether to bypass page CSP.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
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

            /// <summary>
            /// Overriding width value in pixels (minimum 0, maximum 10000000). 0 disables the override.
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Overriding height value in pixels (minimum 0, maximum 10000000). 0 disables the override.
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// Overriding device scale factor value. 0 disables the override.
            /// </summary>
            [JsonProperty("deviceScaleFactor")]
            public double DeviceScaleFactor { get; set; }

            /// <summary>
            /// Whether to emulate mobile device. This includes viewport meta tag, overlay scrollbars, text
            /// autosizing and more.
            /// </summary>
            [JsonProperty("mobile")]
            public bool Mobile { get; set; }

            /// <summary>
            /// Scale to apply to resulting view image.
            /// </summary>
            [JsonProperty("scale")]
            public double Scale { get; set; }

            /// <summary>
            /// Overriding screen width value in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("screenWidth")]
            public int ScreenWidth { get; set; }

            /// <summary>
            /// Overriding screen height value in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("screenHeight")]
            public int ScreenHeight { get; set; }

            /// <summary>
            /// Overriding view X position on screen in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("positionX")]
            public int PositionX { get; set; }

            /// <summary>
            /// Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).
            /// </summary>
            [JsonProperty("positionY")]
            public int PositionY { get; set; }

            /// <summary>
            /// Do not set visible view size, rely upon explicit setVisibleSize call.
            /// </summary>
            [JsonProperty("dontSetVisibleSize")]
            public bool DontSetVisibleSize { get; set; }

            /// <summary>
            /// Screen orientation override.
            /// </summary>
            [JsonProperty("screenOrientation")]
            public Emulation.ScreenOrientation ScreenOrientation { get; set; }

            /// <summary>
            /// The viewport dimensions and scale. If not set, the override is cleared.
            /// </summary>
            [JsonProperty("viewport")]
            public Viewport Viewport { get; set; }
        }

        /// <summary>
        /// Overrides the Device Orientation.
        /// </summary>
        [Obsolete]
        public class SetDeviceOrientationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDeviceOrientationOverride";

            /// <summary>
            /// Mock alpha
            /// </summary>
            [JsonProperty("alpha")]
            public double Alpha { get; set; }

            /// <summary>
            /// Mock beta
            /// </summary>
            [JsonProperty("beta")]
            public double Beta { get; set; }

            /// <summary>
            /// Mock gamma
            /// </summary>
            [JsonProperty("gamma")]
            public double Gamma { get; set; }
        }

        /// <summary>
        /// Set generic font families.
        /// </summary>
        public class SetFontFamiliesCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setFontFamilies";

            /// <summary>
            /// Specifies font families to set. If a font family is not specified, it won't be changed.
            /// </summary>
            [JsonProperty("fontFamilies")]
            public FontFamilies FontFamilies { get; set; }
        }

        /// <summary>
        /// Set default font sizes.
        /// </summary>
        public class SetFontSizesCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setFontSizes";

            /// <summary>
            /// Specifies font sizes to set. If a font size is not specified, it won't be changed.
            /// </summary>
            [JsonProperty("fontSizes")]
            public FontSizes FontSizes { get; set; }
        }

        /// <summary>
        /// Sets given markup as the document's HTML.
        /// </summary>
        public class SetDocumentContentCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDocumentContent";

            /// <summary>
            /// Frame id to set HTML for.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// HTML content to set.
            /// </summary>
            [JsonProperty("html")]
            public string Html { get; set; }
        }

        /// <summary>
        /// Set the behavior when downloading a file.
        /// </summary>
        public class SetDownloadBehaviorCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setDownloadBehavior";

            /// <summary>
            /// Whether to allow all or deny all download requests, or use default Chrome behavior if
            /// available (otherwise deny).
            /// </summary>
            [JsonProperty("behavior")]
            public string Behavior { get; set; }

            /// <summary>
            /// The default path to save downloaded files to. This is requred if behavior is set to 'allow'
            /// </summary>
            [JsonProperty("downloadPath")]
            public string DownloadPath { get; set; }
        }

        /// <summary>
        /// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
        /// unavailable.
        /// </summary>
        [Obsolete]
        public class SetGeolocationOverrideCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setGeolocationOverride";

            /// <summary>
            /// Mock latitude
            /// </summary>
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            /// <summary>
            /// Mock longitude
            /// </summary>
            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            /// <summary>
            /// Mock accuracy
            /// </summary>
            [JsonProperty("accuracy")]
            public double Accuracy { get; set; }
        }

        /// <summary>
        /// Controls whether page will emit lifecycle events.
        /// </summary>
        public class SetLifecycleEventsEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setLifecycleEventsEnabled";

            /// <summary>
            /// If true, starts emitting lifecycle events.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Toggles mouse event-based touch event emulation.
        /// </summary>
        [Obsolete]
        public class SetTouchEmulationEnabledCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.setTouchEmulationEnabled";

            /// <summary>
            /// Whether the touch event emulation should be enabled.
            /// </summary>
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            /// <summary>
            /// Touch/gesture events configuration. Default: current platform.
            /// </summary>
            [JsonProperty("configuration")]
            public string Configuration { get; set; }
        }

        /// <summary>
        /// Starts sending each frame using the `screencastFrame` event.
        /// </summary>
        public class StartScreencastCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.startScreencast";

            /// <summary>
            /// Image compression format.
            /// </summary>
            [JsonProperty("format")]
            public string Format { get; set; }

            /// <summary>
            /// Compression quality from range [0..100].
            /// </summary>
            [JsonProperty("quality")]
            public int Quality { get; set; }

            /// <summary>
            /// Maximum screenshot width.
            /// </summary>
            [JsonProperty("maxWidth")]
            public int MaxWidth { get; set; }

            /// <summary>
            /// Maximum screenshot height.
            /// </summary>
            [JsonProperty("maxHeight")]
            public int MaxHeight { get; set; }

            /// <summary>
            /// Send every n-th frame.
            /// </summary>
            [JsonProperty("everyNthFrame")]
            public int EveryNthFrame { get; set; }
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

            /// <summary>
            /// Target lifecycle state
            /// </summary>
            [JsonProperty("state")]
            public string State { get; set; }
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

            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Seeds compilation cache for given url. Compilation cache does not survive
        /// cross-process navigation.
        /// </summary>
        public class AddCompilationCacheCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.addCompilationCache";

            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Base64-encoded data
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
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

            /// <summary>
            /// Message to be displayed in the report.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Specifies the endpoint group to deliver the report to.
            /// </summary>
            [JsonProperty("group")]
            public string Group { get; set; }
        }

        /// <summary>
        /// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
        /// </summary>
        public class WaitForDebuggerCommand : ICommand
        {
            string ICommand.Name { get; } = "Page.waitForDebugger";
        }

        public class DomContentEventFiredEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.domContentEventFired";

            [JsonProperty("timestamp")]
            public Network.MonotonicTime Timestamp { get; set; }
        }

        /// <summary>
        /// Fired when frame has been attached to its parent.
        /// </summary>
        public class FrameAttachedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameAttached";

            /// <summary>
            /// Id of the frame that has been attached.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// Parent frame identifier.
            /// </summary>
            [JsonProperty("parentFrameId")]
            public FrameId ParentFrameId { get; set; }

            /// <summary>
            /// JavaScript stack trace of when frame was attached, only set if frame initiated from script.
            /// </summary>
            [JsonProperty("stack")]
            public Runtime.StackTrace Stack { get; set; }
        }

        /// <summary>
        /// Fired when frame no longer has a scheduled navigation.
        /// </summary>
        public class FrameClearedScheduledNavigationEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameClearedScheduledNavigation";

            /// <summary>
            /// Id of the frame that has cleared its scheduled navigation.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }
        }

        /// <summary>
        /// Fired when frame has been detached from its parent.
        /// </summary>
        public class FrameDetachedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameDetached";

            /// <summary>
            /// Id of the frame that has been detached.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }
        }

        /// <summary>
        /// Fired once navigation of the frame has completed. Frame is now associated with the new loader.
        /// </summary>
        public class FrameNavigatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameNavigated";

            /// <summary>
            /// Frame object.
            /// </summary>
            [JsonProperty("frame")]
            public Frame Frame { get; set; }
        }

        public class FrameResizedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameResized";
        }

        /// <summary>
        /// Fired when frame schedules a potential navigation.
        /// </summary>
        public class FrameScheduledNavigationEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameScheduledNavigation";

            /// <summary>
            /// Id of the frame that has scheduled a navigation.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// Delay (in seconds) until the navigation is scheduled to begin. The navigation is not
            /// guaranteed to start.
            /// </summary>
            [JsonProperty("delay")]
            public double Delay { get; set; }

            /// <summary>
            /// The reason for the navigation.
            /// </summary>
            [JsonProperty("reason")]
            public string Reason { get; set; }

            /// <summary>
            /// The destination URL for the scheduled navigation.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// Fired when frame has started loading.
        /// </summary>
        public class FrameStartedLoadingEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameStartedLoading";

            /// <summary>
            /// Id of the frame that has started loading.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }
        }

        /// <summary>
        /// Fired when frame has stopped loading.
        /// </summary>
        public class FrameStoppedLoadingEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.frameStoppedLoading";

            /// <summary>
            /// Id of the frame that has stopped loading.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }
        }

        /// <summary>
        /// Fired when interstitial page was hidden
        /// </summary>
        public class InterstitialHiddenEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.interstitialHidden";
        }

        /// <summary>
        /// Fired when interstitial page was shown
        /// </summary>
        public class InterstitialShownEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.interstitialShown";
        }

        /// <summary>
        /// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) has been
        /// closed.
        /// </summary>
        public class JavascriptDialogClosedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.javascriptDialogClosed";

            /// <summary>
            /// Whether dialog was confirmed.
            /// </summary>
            [JsonProperty("result")]
            public bool Result { get; set; }

            /// <summary>
            /// User input in case of prompt.
            /// </summary>
            [JsonProperty("userInput")]
            public string UserInput { get; set; }
        }

        /// <summary>
        /// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) is about to
        /// open.
        /// </summary>
        public class JavascriptDialogOpeningEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.javascriptDialogOpening";

            /// <summary>
            /// Frame url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Message that will be displayed by the dialog.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Dialog type.
            /// </summary>
            [JsonProperty("type")]
            public DialogType Type { get; set; }

            /// <summary>
            /// True iff browser is capable showing or acting on the given dialog. When browser has no
            /// dialog handler for given target, calling alert while Page domain is engaged will stall
            /// the page execution. Execution can be resumed via calling Page.handleJavaScriptDialog.
            /// </summary>
            [JsonProperty("hasBrowserHandler")]
            public bool HasBrowserHandler { get; set; }

            /// <summary>
            /// Default dialog prompt.
            /// </summary>
            [JsonProperty("defaultPrompt")]
            public string DefaultPrompt { get; set; }
        }

        /// <summary>
        /// Fired for top level page lifecycle events such as navigation, load, paint, etc.
        /// </summary>
        public class LifecycleEventEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.lifecycleEvent";

            /// <summary>
            /// Id of the frame.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// Loader identifier. Empty string if the request is fetched from worker.
            /// </summary>
            [JsonProperty("loaderId")]
            public Network.LoaderId LoaderId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("timestamp")]
            public Network.MonotonicTime Timestamp { get; set; }
        }

        public class LoadEventFiredEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.loadEventFired";

            [JsonProperty("timestamp")]
            public Network.MonotonicTime Timestamp { get; set; }
        }

        /// <summary>
        /// Fired when same-document navigation happens, e.g. due to history API usage or anchor navigation.
        /// </summary>
        public class NavigatedWithinDocumentEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.navigatedWithinDocument";

            /// <summary>
            /// Id of the frame.
            /// </summary>
            [JsonProperty("frameId")]
            public FrameId FrameId { get; set; }

            /// <summary>
            /// Frame's new url.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// Compressed image data requested by the `startScreencast`.
        /// </summary>
        public class ScreencastFrameEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.screencastFrame";

            /// <summary>
            /// Base64-encoded compressed image.
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }

            /// <summary>
            /// Screencast frame metadata.
            /// </summary>
            [JsonProperty("metadata")]
            public ScreencastFrameMetadata Metadata { get; set; }

            /// <summary>
            /// Frame number.
            /// </summary>
            [JsonProperty("sessionId")]
            public int SessionId { get; set; }
        }

        /// <summary>
        /// Fired when the page with currently enabled screencast was shown or hidden `.
        /// </summary>
        public class ScreencastVisibilityChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.screencastVisibilityChanged";

            /// <summary>
            /// True if the page is visible.
            /// </summary>
            [JsonProperty("visible")]
            public bool Visible { get; set; }
        }

        /// <summary>
        /// Fired when a new window is going to be opened, via window.open(), link click, form submission,
        /// etc.
        /// </summary>
        public class WindowOpenEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.windowOpen";

            /// <summary>
            /// The URL for the new window.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Window name.
            /// </summary>
            [JsonProperty("windowName")]
            public string WindowName { get; set; }

            /// <summary>
            /// An array of enabled window features.
            /// </summary>
            [JsonProperty("windowFeatures")]
            public string[] WindowFeatures { get; set; }

            /// <summary>
            /// Whether or not it was triggered by user gesture.
            /// </summary>
            [JsonProperty("userGesture")]
            public bool UserGesture { get; set; }
        }

        /// <summary>
        /// Issued for every compilation cache generated. Is only available
        /// if Page.setGenerateCompilationCache is enabled.
        /// </summary>
        public class CompilationCacheProducedEvent : ICommand
        {
            string ICommand.Name { get; } = "Page.compilationCacheProduced";

            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Base64-encoded data
            /// </summary>
            [JsonProperty("data")]
            public string Data { get; set; }
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

            /// <summary>
            /// Time domain
            /// </summary>
            [JsonProperty("timeDomain")]
            public string TimeDomain { get; set; }
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

            /// <summary>
            /// Current values for run-time metrics.
            /// </summary>
            [JsonProperty("metrics")]
            public Metric[] Metrics { get; set; }
        }

        /// <summary>
        /// Current values of the metrics.
        /// </summary>
        public class MetricsEvent : ICommand
        {
            string ICommand.Name { get; } = "Performance.metrics";

            /// <summary>
            /// Current values of the metrics.
            /// </summary>
            [JsonProperty("metrics")]
            public Metric[] Metrics { get; set; }

            /// <summary>
            /// Timestamp title.
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }
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

            /// <summary>
            /// If true, all certificate errors will be ignored.
            /// </summary>
            [JsonProperty("ignore")]
            public bool Ignore { get; set; }
        }

        /// <summary>
        /// Handles a certificate error that fired a certificateError event.
        /// </summary>
        [Obsolete]
        public class HandleCertificateErrorCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.handleCertificateError";

            /// <summary>
            /// The ID of the event.
            /// </summary>
            [JsonProperty("eventId")]
            public int EventId { get; set; }

            /// <summary>
            /// The action to take on the certificate error.
            /// </summary>
            [JsonProperty("action")]
            public CertificateErrorAction Action { get; set; }
        }

        /// <summary>
        /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
        /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
        /// </summary>
        [Obsolete]
        public class SetOverrideCertificateErrorsCommand : ICommand
        {
            string ICommand.Name { get; } = "Security.setOverrideCertificateErrors";

            /// <summary>
            /// If true, certificate errors will be overridden.
            /// </summary>
            [JsonProperty("override")]
            public bool Override { get; set; }
        }

        /// <summary>
        /// There is a certificate error. If overriding certificate errors is enabled, then it should be
        /// handled with the `handleCertificateError` command. Note: this event does not fire if the
        /// certificate error has been allowed internally. Only one client per target should override
        /// certificate errors at the same time.
        /// </summary>
        [Obsolete]
        public class CertificateErrorEvent : ICommand
        {
            string ICommand.Name { get; } = "Security.certificateError";

            /// <summary>
            /// The ID of the event.
            /// </summary>
            [JsonProperty("eventId")]
            public int EventId { get; set; }

            /// <summary>
            /// The type of the error.
            /// </summary>
            [JsonProperty("errorType")]
            public string ErrorType { get; set; }

            /// <summary>
            /// The url that was requested.
            /// </summary>
            [JsonProperty("requestURL")]
            public string RequestURL { get; set; }
        }

        /// <summary>
        /// The security state of the page changed.
        /// </summary>
        public class SecurityStateChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "Security.securityStateChanged";

            /// <summary>
            /// Security state.
            /// </summary>
            [JsonProperty("securityState")]
            public SecurityState SecurityState { get; set; }

            /// <summary>
            /// True if the page was loaded over cryptographic transport such as HTTPS.
            /// </summary>
            [JsonProperty("schemeIsCryptographic")]
            public bool SchemeIsCryptographic { get; set; }

            /// <summary>
            /// List of explanations for the security state. If the overall security state is `insecure` or
            /// `warning`, at least one corresponding explanation should be included.
            /// </summary>
            [JsonProperty("explanations")]
            public SecurityStateExplanation[] Explanations { get; set; }

            /// <summary>
            /// Information about insecure content on the page.
            /// </summary>
            [JsonProperty("insecureContentStatus")]
            public InsecureContentStatus InsecureContentStatus { get; set; }

            /// <summary>
            /// Overrides user-visible description of the state.
            /// </summary>
            [JsonProperty("summary")]
            public string Summary { get; set; }
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

            [JsonProperty("origin")]
            public string Origin { get; set; }

            [JsonProperty("registrationId")]
            public string RegistrationId { get; set; }

            [JsonProperty("data")]
            public string Data { get; set; }
        }

        public class DisableCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.disable";
        }

        public class DispatchSyncEventCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.dispatchSyncEvent";

            [JsonProperty("origin")]
            public string Origin { get; set; }

            [JsonProperty("registrationId")]
            public string RegistrationId { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("lastChance")]
            public bool LastChance { get; set; }
        }

        public class EnableCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.enable";
        }

        public class InspectWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.inspectWorker";

            [JsonProperty("versionId")]
            public string VersionId { get; set; }
        }

        public class SetForceUpdateOnPageLoadCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.setForceUpdateOnPageLoad";

            [JsonProperty("forceUpdateOnPageLoad")]
            public bool ForceUpdateOnPageLoad { get; set; }
        }

        public class SkipWaitingCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.skipWaiting";

            [JsonProperty("scopeURL")]
            public string ScopeURL { get; set; }
        }

        public class StartWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.startWorker";

            [JsonProperty("scopeURL")]
            public string ScopeURL { get; set; }
        }

        public class StopAllWorkersCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.stopAllWorkers";
        }

        public class StopWorkerCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.stopWorker";

            [JsonProperty("versionId")]
            public string VersionId { get; set; }
        }

        public class UnregisterCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.unregister";

            [JsonProperty("scopeURL")]
            public string ScopeURL { get; set; }
        }

        public class UpdateRegistrationCommand : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.updateRegistration";

            [JsonProperty("scopeURL")]
            public string ScopeURL { get; set; }
        }

        public class WorkerErrorReportedEvent : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.workerErrorReported";

            [JsonProperty("errorMessage")]
            public ServiceWorkerErrorMessage ErrorMessage { get; set; }
        }

        public class WorkerRegistrationUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.workerRegistrationUpdated";

            [JsonProperty("registrations")]
            public ServiceWorkerRegistration[] Registrations { get; set; }
        }

        public class WorkerVersionUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "ServiceWorker.workerVersionUpdated";

            [JsonProperty("versions")]
            public ServiceWorkerVersion[] Versions { get; set; }
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

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// Comma separated list of StorageType to clear.
            /// </summary>
            [JsonProperty("storageTypes")]
            public string StorageTypes { get; set; }
        }

        /// <summary>
        /// Returns usage and quota in bytes.
        /// </summary>
        public class GetUsageAndQuotaCommand : ICommand<GetUsageAndQuotaResponse>
        {
            string ICommand.Name { get; } = "Storage.getUsageAndQuota";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        public class GetUsageAndQuotaResponse
        {

            /// <summary>
            /// Storage usage (bytes).
            /// </summary>
            [JsonProperty("usage")]
            public double Usage { get; set; }

            /// <summary>
            /// Storage quota (bytes).
            /// </summary>
            [JsonProperty("quota")]
            public double Quota { get; set; }

            /// <summary>
            /// Storage usage per type (bytes).
            /// </summary>
            [JsonProperty("usageBreakdown")]
            public UsageForType[] UsageBreakdown { get; set; }
        }

        /// <summary>
        /// Registers origin to be notified when an update occurs to its cache storage list.
        /// </summary>
        public class TrackCacheStorageForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.trackCacheStorageForOrigin";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        /// <summary>
        /// Registers origin to be notified when an update occurs to its IndexedDB.
        /// </summary>
        public class TrackIndexedDBForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.trackIndexedDBForOrigin";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        /// <summary>
        /// Unregisters origin from receiving notifications for cache storage.
        /// </summary>
        public class UntrackCacheStorageForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.untrackCacheStorageForOrigin";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        /// <summary>
        /// Unregisters origin from receiving notifications for IndexedDB.
        /// </summary>
        public class UntrackIndexedDBForOriginCommand : ICommand
        {
            string ICommand.Name { get; } = "Storage.untrackIndexedDBForOrigin";

            /// <summary>
            /// Security origin.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        /// <summary>
        /// A cache's contents have been modified.
        /// </summary>
        public class CacheStorageContentUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Storage.cacheStorageContentUpdated";

            /// <summary>
            /// Origin to update.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// Name of cache in origin.
            /// </summary>
            [JsonProperty("cacheName")]
            public string CacheName { get; set; }
        }

        /// <summary>
        /// A cache has been added/deleted.
        /// </summary>
        public class CacheStorageListUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Storage.cacheStorageListUpdated";

            /// <summary>
            /// Origin to update.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
        }

        /// <summary>
        /// The origin's IndexedDB object store has been modified.
        /// </summary>
        public class IndexedDBContentUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Storage.indexedDBContentUpdated";

            /// <summary>
            /// Origin to update.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            /// Database to update.
            /// </summary>
            [JsonProperty("databaseName")]
            public string DatabaseName { get; set; }

            /// <summary>
            /// ObjectStore to update.
            /// </summary>
            [JsonProperty("objectStoreName")]
            public string ObjectStoreName { get; set; }
        }

        /// <summary>
        /// The origin's IndexedDB database list has been modified.
        /// </summary>
        public class IndexedDBListUpdatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Storage.indexedDBListUpdated";

            /// <summary>
            /// Origin to update.
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }
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

            /// <summary>
            /// Information about the GPUs on the system.
            /// </summary>
            [JsonProperty("gpu")]
            public GPUInfo Gpu { get; set; }

            /// <summary>
            /// A platform-dependent description of the model of the machine. On Mac OS, this is, for
            /// example, 'MacBookPro'. Will be the empty string if not supported.
            /// </summary>
            [JsonProperty("modelName")]
            public string ModelName { get; set; }

            /// <summary>
            /// A platform-dependent description of the version of the machine. On Mac OS, this is, for
            /// example, '10.1'. Will be the empty string if not supported.
            /// </summary>
            [JsonProperty("modelVersion")]
            public string ModelVersion { get; set; }

            /// <summary>
            /// The command line string used to launch the browser. Will be the empty string if not
            /// supported.
            /// </summary>
            [JsonProperty("commandLine")]
            public string CommandLine { get; set; }
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

            /// <summary>
            /// An array of process info blocks.
            /// </summary>
            [JsonProperty("processInfo")]
            public ProcessInfo[] ProcessInfo { get; set; }
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

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Attaches to the target with given id.
        /// </summary>
        public class AttachToTargetCommand : ICommand<AttachToTargetResponse>
        {
            string ICommand.Name { get; } = "Target.attachToTarget";

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }

            /// <summary>
            /// Enables "flat" access to the session via specifying sessionId attribute in the commands.
            /// </summary>
            [JsonProperty("flatten")]
            public bool Flatten { get; set; }
        }

        public class AttachToTargetResponse
        {

            /// <summary>
            /// Id assigned to the session.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }
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

            /// <summary>
            /// Id assigned to the session.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }
        }

        /// <summary>
        /// Closes the target. If the target is a page that gets closed too.
        /// </summary>
        public class CloseTargetCommand : ICommand<CloseTargetResponse>
        {
            string ICommand.Name { get; } = "Target.closeTarget";

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        public class CloseTargetResponse
        {

            [JsonProperty("success")]
            public bool Success { get; set; }
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

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }

            /// <summary>
            /// Binding name, 'cdp' if not specified.
            /// </summary>
            [JsonProperty("bindingName")]
            public string BindingName { get; set; }
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

            /// <summary>
            /// The id of the context created.
            /// </summary>
            [JsonProperty("browserContextId")]
            public BrowserContextID BrowserContextId { get; set; }
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

            /// <summary>
            /// An array of browser context ids.
            /// </summary>
            [JsonProperty("browserContextIds")]
            public BrowserContextID[] BrowserContextIds { get; set; }
        }

        /// <summary>
        /// Creates a new page.
        /// </summary>
        public class CreateTargetCommand : ICommand<CreateTargetResponse>
        {
            string ICommand.Name { get; } = "Target.createTarget";

            /// <summary>
            /// The initial URL the page will be navigated to.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Frame width in DIP (headless chrome only).
            /// </summary>
            [JsonProperty("width")]
            public int Width { get; set; }

            /// <summary>
            /// Frame height in DIP (headless chrome only).
            /// </summary>
            [JsonProperty("height")]
            public int Height { get; set; }

            /// <summary>
            /// The browser context to create the page in.
            /// </summary>
            [JsonProperty("browserContextId")]
            public BrowserContextID BrowserContextId { get; set; }

            /// <summary>
            /// Whether BeginFrames for this target will be controlled via DevTools (headless chrome only,
            /// not supported on MacOS yet, false by default).
            /// </summary>
            [JsonProperty("enableBeginFrameControl")]
            public bool EnableBeginFrameControl { get; set; }
        }

        public class CreateTargetResponse
        {

            /// <summary>
            /// The id of the page opened.
            /// </summary>
            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Detaches session with given id.
        /// </summary>
        public class DetachFromTargetCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.detachFromTarget";

            /// <summary>
            /// Session to detach.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }

            /// <summary>
            /// Deprecated.
            /// </summary>
            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Deletes a BrowserContext. All the belonging pages will be closed without calling their
        /// beforeunload hooks.
        /// </summary>
        public class DisposeBrowserContextCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.disposeBrowserContext";

            [JsonProperty("browserContextId")]
            public BrowserContextID BrowserContextId { get; set; }
        }

        /// <summary>
        /// Returns information about a target.
        /// </summary>
        public class GetTargetInfoCommand : ICommand<GetTargetInfoResponse>
        {
            string ICommand.Name { get; } = "Target.getTargetInfo";

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        public class GetTargetInfoResponse
        {

            [JsonProperty("targetInfo")]
            public TargetInfo TargetInfo { get; set; }
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

            /// <summary>
            /// The list of targets.
            /// </summary>
            [JsonProperty("targetInfos")]
            public TargetInfo[] TargetInfos { get; set; }
        }

        /// <summary>
        /// Sends protocol message over session with given id.
        /// </summary>
        public class SendMessageToTargetCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.sendMessageToTarget";

            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Identifier of the session.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }

            /// <summary>
            /// Deprecated.
            /// </summary>
            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Controls whether to automatically attach to new targets which are considered to be related to
        /// this one. When turned on, attaches to all existing related targets as well. When turned off,
        /// automatically detaches from all currently attached targets.
        /// </summary>
        public class SetAutoAttachCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setAutoAttach";

            /// <summary>
            /// Whether to auto-attach to related targets.
            /// </summary>
            [JsonProperty("autoAttach")]
            public bool AutoAttach { get; set; }

            /// <summary>
            /// Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
            /// to run paused targets.
            /// </summary>
            [JsonProperty("waitForDebuggerOnStart")]
            public bool WaitForDebuggerOnStart { get; set; }

            /// <summary>
            /// Enables "flat" access to the session via specifying sessionId attribute in the commands.
            /// </summary>
            [JsonProperty("flatten")]
            public bool Flatten { get; set; }
        }

        /// <summary>
        /// Controls whether to discover available targets and notify via
        /// `targetCreated/targetInfoChanged/targetDestroyed` events.
        /// </summary>
        public class SetDiscoverTargetsCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setDiscoverTargets";

            /// <summary>
            /// Whether to discover available targets.
            /// </summary>
            [JsonProperty("discover")]
            public bool Discover { get; set; }
        }

        /// <summary>
        /// Enables target discovery for the specified locations, when `setDiscoverTargets` was set to
        /// `true`.
        /// </summary>
        public class SetRemoteLocationsCommand : ICommand
        {
            string ICommand.Name { get; } = "Target.setRemoteLocations";

            /// <summary>
            /// List of remote locations.
            /// </summary>
            [JsonProperty("locations")]
            public RemoteLocation[] Locations { get; set; }
        }

        /// <summary>
        /// Issued when attached to target because of auto-attach or `attachToTarget` command.
        /// </summary>
        public class AttachedToTargetEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.attachedToTarget";

            /// <summary>
            /// Identifier assigned to the session used to send/receive messages.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }

            [JsonProperty("targetInfo")]
            public TargetInfo TargetInfo { get; set; }

            [JsonProperty("waitingForDebugger")]
            public bool WaitingForDebugger { get; set; }
        }

        /// <summary>
        /// Issued when detached from target for any reason (including `detachFromTarget` command). Can be
        /// issued multiple times per target if multiple sessions have been attached to it.
        /// </summary>
        public class DetachedFromTargetEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.detachedFromTarget";

            /// <summary>
            /// Detached session identifier.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }

            /// <summary>
            /// Deprecated.
            /// </summary>
            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Notifies about a new protocol message received from the session (as reported in
        /// `attachedToTarget` event).
        /// </summary>
        public class ReceivedMessageFromTargetEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.receivedMessageFromTarget";

            /// <summary>
            /// Identifier of a session which sends a message.
            /// </summary>
            [JsonProperty("sessionId")]
            public SessionID SessionId { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Deprecated.
            /// </summary>
            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Issued when a possible inspection target is created.
        /// </summary>
        public class TargetCreatedEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.targetCreated";

            [JsonProperty("targetInfo")]
            public TargetInfo TargetInfo { get; set; }
        }

        /// <summary>
        /// Issued when a target is destroyed.
        /// </summary>
        public class TargetDestroyedEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.targetDestroyed";

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }
        }

        /// <summary>
        /// Issued when a target has crashed.
        /// </summary>
        public class TargetCrashedEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.targetCrashed";

            [JsonProperty("targetId")]
            public TargetID TargetId { get; set; }

            /// <summary>
            /// Termination status type.
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// Termination error code.
            /// </summary>
            [JsonProperty("errorCode")]
            public int ErrorCode { get; set; }
        }

        /// <summary>
        /// Issued when some information about a target has changed. This only happens between
        /// `targetCreated` and `targetDestroyed`.
        /// </summary>
        public class TargetInfoChangedEvent : ICommand
        {
            string ICommand.Name { get; } = "Target.targetInfoChanged";

            [JsonProperty("targetInfo")]
            public TargetInfo TargetInfo { get; set; }
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

            /// <summary>
            /// Port number to bind.
            /// </summary>
            [JsonProperty("port")]
            public int Port { get; set; }
        }

        /// <summary>
        /// Request browser port unbinding.
        /// </summary>
        public class UnbindCommand : ICommand
        {
            string ICommand.Name { get; } = "Tethering.unbind";

            /// <summary>
            /// Port number to unbind.
            /// </summary>
            [JsonProperty("port")]
            public int Port { get; set; }
        }

        /// <summary>
        /// Informs that port was successfully bound and got a specified connection id.
        /// </summary>
        public class AcceptedEvent : ICommand
        {
            string ICommand.Name { get; } = "Tethering.accepted";

            /// <summary>
            /// Port number that was successfully bound.
            /// </summary>
            [JsonProperty("port")]
            public int Port { get; set; }

            /// <summary>
            /// Connection id to be used.
            /// </summary>
            [JsonProperty("connectionId")]
            public string ConnectionId { get; set; }
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

            /// <summary>
            /// A list of supported tracing categories.
            /// </summary>
            [JsonProperty("categories")]
            public string[] Categories { get; set; }
        }

        /// <summary>
        /// Record a clock sync marker in the trace.
        /// </summary>
        public class RecordClockSyncMarkerCommand : ICommand
        {
            string ICommand.Name { get; } = "Tracing.recordClockSyncMarker";

            /// <summary>
            /// The ID of this clock sync marker
            /// </summary>
            [JsonProperty("syncId")]
            public string SyncId { get; set; }
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

            /// <summary>
            /// GUID of the resulting global memory dump.
            /// </summary>
            [JsonProperty("dumpGuid")]
            public string DumpGuid { get; set; }

            /// <summary>
            /// True iff the global memory dump succeeded.
            /// </summary>
            [JsonProperty("success")]
            public bool Success { get; set; }
        }

        /// <summary>
        /// Start trace events collection.
        /// </summary>
        public class StartCommand : ICommand
        {
            string ICommand.Name { get; } = "Tracing.start";

            /// <summary>
            /// Category/tag filter
            /// </summary>
            [JsonProperty("categories")]
            public string Categories { get; set; }

            /// <summary>
            /// Tracing options
            /// </summary>
            [JsonProperty("options")]
            public string Options { get; set; }

            /// <summary>
            /// If set, the agent will issue bufferUsage events at this interval, specified in milliseconds
            /// </summary>
            [JsonProperty("bufferUsageReportingInterval")]
            public double BufferUsageReportingInterval { get; set; }

            /// <summary>
            /// Whether to report trace events as series of dataCollected events or to save trace to a
            /// stream (defaults to `ReportEvents`).
            /// </summary>
            [JsonProperty("transferMode")]
            public string TransferMode { get; set; }

            /// <summary>
            /// Compression format to use. This only applies when using `ReturnAsStream`
            /// transfer mode (defaults to `none`)
            /// </summary>
            [JsonProperty("streamCompression")]
            public StreamCompression StreamCompression { get; set; }

            [JsonProperty("traceConfig")]
            public TraceConfig TraceConfig { get; set; }
        }

        public class BufferUsageEvent : ICommand
        {
            string ICommand.Name { get; } = "Tracing.bufferUsage";

            /// <summary>
            /// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
            /// total size.
            /// </summary>
            [JsonProperty("percentFull")]
            public double PercentFull { get; set; }

            /// <summary>
            /// An approximate number of events in the trace log.
            /// </summary>
            [JsonProperty("eventCount")]
            public double EventCount { get; set; }

            /// <summary>
            /// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
            /// total size.
            /// </summary>
            [JsonProperty("value")]
            public double Value { get; set; }
        }

        /// <summary>
        /// Contains an bucket of collected trace events. When tracing is stopped collected events will be
        /// send as a sequence of dataCollected events followed by tracingComplete event.
        /// </summary>
        public class DataCollectedEvent : ICommand
        {
            string ICommand.Name { get; } = "Tracing.dataCollected";

            [JsonProperty("value")]
            public object[] Value { get; set; }
        }

        /// <summary>
        /// Signals that tracing is stopped and there is no trace buffers pending flush, all data were
        /// delivered via dataCollected events.
        /// </summary>
        public class TracingCompleteEvent : ICommand
        {
            string ICommand.Name { get; } = "Tracing.tracingComplete";

            /// <summary>
            /// A handle of the stream that holds resulting trace data.
            /// </summary>
            [JsonProperty("stream")]
            public IO.StreamHandle Stream { get; set; }

            /// <summary>
            /// Compression format of returned stream.
            /// </summary>
            [JsonProperty("streamCompression")]
            public StreamCompression StreamCompression { get; set; }
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

            /// <summary>
            /// Message to be displayed in the report.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Specifies the endpoint group to deliver the report to.
            /// </summary>
            [JsonProperty("group")]
            public string Group { get; set; }
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

            /// <summary>
            /// If specified, only requests matching any of these patterns will produce
            /// fetchRequested event and will be paused until clients response. If not set,
            /// all requests will be affected.
            /// </summary>
            [JsonProperty("patterns")]
            public RequestPattern[] Patterns { get; set; }

            /// <summary>
            /// If true, authRequired events will be issued and requests will be paused
            /// expecting a call to continueWithAuth.
            /// </summary>
            [JsonProperty("handleAuthRequests")]
            public bool HandleAuthRequests { get; set; }
        }

        /// <summary>
        /// Causes the request to fail with specified reason.
        /// </summary>
        public class FailRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.failRequest";

            /// <summary>
            /// An id the client received in requestPaused event.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Causes the request to fail with the given reason.
            /// </summary>
            [JsonProperty("errorReason")]
            public Network.ErrorReason ErrorReason { get; set; }
        }

        /// <summary>
        /// Provides response to the request.
        /// </summary>
        public class FulfillRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.fulfillRequest";

            /// <summary>
            /// An id the client received in requestPaused event.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// An HTTP response code.
            /// </summary>
            [JsonProperty("responseCode")]
            public int ResponseCode { get; set; }

            /// <summary>
            /// Response headers.
            /// </summary>
            [JsonProperty("responseHeaders")]
            public HeaderEntry[] ResponseHeaders { get; set; }

            /// <summary>
            /// A response body.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }

            /// <summary>
            /// A textual representation of responseCode.
            /// If absent, a standard phrase mathcing responseCode is used.
            /// </summary>
            [JsonProperty("responsePhrase")]
            public string ResponsePhrase { get; set; }
        }

        /// <summary>
        /// Continues the request, optionally modifying some of its parameters.
        /// </summary>
        public class ContinueRequestCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.continueRequest";

            /// <summary>
            /// An id the client received in requestPaused event.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// If set, the request url will be modified in a way that's not observable by page.
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// If set, the request method is overridden.
            /// </summary>
            [JsonProperty("method")]
            public string Method { get; set; }

            /// <summary>
            /// If set, overrides the post data in the request.
            /// </summary>
            [JsonProperty("postData")]
            public string PostData { get; set; }

            /// <summary>
            /// If set, overrides the request headrts.
            /// </summary>
            [JsonProperty("headers")]
            public HeaderEntry[] Headers { get; set; }
        }

        /// <summary>
        /// Continues a request supplying authChallengeResponse following authRequired event.
        /// </summary>
        public class ContinueWithAuthCommand : ICommand
        {
            string ICommand.Name { get; } = "Fetch.continueWithAuth";

            /// <summary>
            /// An id the client received in authRequired event.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// Response to  with an authChallenge.
            /// </summary>
            [JsonProperty("authChallengeResponse")]
            public AuthChallengeResponse AuthChallengeResponse { get; set; }
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

            /// <summary>
            /// Identifier for the intercepted request to get body for.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        public class GetResponseBodyResponse
        {

            /// <summary>
            /// Response body.
            /// </summary>
            [JsonProperty("body")]
            public string Body { get; set; }

            /// <summary>
            /// True, if content was sent as base64.
            /// </summary>
            [JsonProperty("base64Encoded")]
            public bool Base64Encoded { get; set; }
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

            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }
        }

        public class TakeResponseBodyAsStreamResponse
        {

            [JsonProperty("stream")]
            public IO.StreamHandle Stream { get; set; }
        }

        /// <summary>
        /// Issued when the domain is enabled and the request URL matches the
        /// specified filter. The request is paused until the client responds
        /// with one of continueRequest, failRequest or fulfillRequest.
        /// The stage of the request can be determined by presence of responseErrorReason
        /// and responseStatusCode -- the request is at the response stage if either
        /// of these fields is present and in the request stage otherwise.
        /// </summary>
        public class RequestPausedEvent : ICommand
        {
            string ICommand.Name { get; } = "Fetch.requestPaused";

            /// <summary>
            /// Each request the page makes will have a unique id.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// The details of the request.
            /// </summary>
            [JsonProperty("request")]
            public Network.Request Request { get; set; }

            /// <summary>
            /// The id of the frame that initiated the request.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// How the requested resource will be used.
            /// </summary>
            [JsonProperty("resourceType")]
            public Network.ResourceType ResourceType { get; set; }

            /// <summary>
            /// Response error if intercepted at response stage.
            /// </summary>
            [JsonProperty("responseErrorReason")]
            public Network.ErrorReason ResponseErrorReason { get; set; }

            /// <summary>
            /// Response code if intercepted at response stage.
            /// </summary>
            [JsonProperty("responseStatusCode")]
            public int ResponseStatusCode { get; set; }

            /// <summary>
            /// Response headers if intercepted at the response stage.
            /// </summary>
            [JsonProperty("responseHeaders")]
            public HeaderEntry[] ResponseHeaders { get; set; }
        }

        /// <summary>
        /// Issued when the domain is enabled with handleAuthRequests set to true.
        /// The request is paused until client responds with continueWithAuth.
        /// </summary>
        public class AuthRequiredEvent : ICommand
        {
            string ICommand.Name { get; } = "Fetch.authRequired";

            /// <summary>
            /// Each request the page makes will have a unique id.
            /// </summary>
            [JsonProperty("requestId")]
            public RequestId RequestId { get; set; }

            /// <summary>
            /// The details of the request.
            /// </summary>
            [JsonProperty("request")]
            public Network.Request Request { get; set; }

            /// <summary>
            /// The id of the frame that initiated the request.
            /// </summary>
            [JsonProperty("frameId")]
            public Page.FrameId FrameId { get; set; }

            /// <summary>
            /// How the requested resource will be used.
            /// </summary>
            [JsonProperty("resourceType")]
            public Network.ResourceType ResourceType { get; set; }

            /// <summary>
            /// Details of the Authorization Challenge encountered.
            /// If this is set, client should respond with continueRequest that
            /// contains AuthChallengeResponse.
            /// </summary>
            [JsonProperty("authChallenge")]
            public AuthChallenge AuthChallenge { get; set; }
        }
    }
}
