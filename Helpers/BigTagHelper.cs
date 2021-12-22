using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tutorial.Helpers
{
    // To be able to target any tag use this attribute.
    // This is to create a big tag.
    [HtmlTargetElement("big")]
    // This is to create an attribute to a tag.
    [HtmlTargetElement(Attributes = "big")]
    // These to are separated because they have
    // an 'or' like relationship.
    public class BigTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Replace the tag name.
            output.TagName = "h3";

            // Remove the all big attributes already assigned.
            output.Attributes.RemoveAll("big");

            // Add an attribute to the tag.
            output.Attributes.SetAttribute("class", "h3");
        }
    }
}
