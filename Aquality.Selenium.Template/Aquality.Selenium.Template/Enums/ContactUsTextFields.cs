using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Aquality.Selenium.Template.Enums
{
    public enum ContactUsTextFields
    {
        [Description("Please fill in the required field.")]
        Name,
        [Description("Email address seems invalid.")]
        Email,
        Company,
        Phone,
        [Description("Please fill in the required field.")]
        ProjectDescription
    }

    public static class ContactUsTextFieldsExtension
    {
        private static IDictionary<ContactUsTextFields, string> TextFieldsId = new Dictionary<ContactUsTextFields, string>()
        {
             {ContactUsTextFields.Name, "your-name"},
             {ContactUsTextFields.Email, "your-email"},
             {ContactUsTextFields.Company, "your-company"},
             {ContactUsTextFields.Phone, "your-phone"},
             {ContactUsTextFields.ProjectDescription, "your-message"},
        };

        public static string GetId(this ContactUsTextFields textField)
        {
            if (!TextFieldsId.ContainsKey(textField))
            {
                throw new NotSupportedException($"Id for {textField} text field is not defined");
            }

            return TextFieldsId[textField];
        }
    }

}