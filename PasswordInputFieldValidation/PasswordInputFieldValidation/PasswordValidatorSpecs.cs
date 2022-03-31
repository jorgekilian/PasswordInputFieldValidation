using NUnit.Framework;

namespace PasswordInputFieldValidation {
    public class PasswordValidatorSpecs {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void no_validate_password_when_string_be_less_8_characters_long() {
            var password = "a";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate);
        }
    }

    public class PasswordInputField {
        public static bool Validate(string s) {
            throw new System.NotImplementedException();
        }
    }
}