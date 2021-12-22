using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tutorial.Helpers
{
    // This helper will help creating an proper email anchor tag.
    public class CustomEmailTagHelper : TagHelper
    {
        // To be able to get the value of the attribute
        // dynamically create a field.
        public string MyEmail { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Convert this custom tag to an anchor tag.
            output.TagName = "a";

            // Define the attributes of the tag helper.
            // We can use SetAttribute method to do that.
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            // It is also possible adding an attribute with Add.
            output.Attributes.Add("id", "my-email-id");

            // To be able to set the content use SetContent or SetHtmlContent.
            output.Content.SetContent(MyEmail);
        }
    }
}
