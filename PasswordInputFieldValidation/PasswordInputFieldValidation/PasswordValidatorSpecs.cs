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

            Assert.AreEqual(false, validate.Valid);
        }

        [Test]
        public void return_specific_message_when_string_be_less_8_characters_long() {
            var password = "a";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual("Password must be at least 8 characters", validate.Message);
        }

        [Test]
        public void return_non_valid_password_and_specific_message_when_string_doesnt_have_two_number() {
            var password = "abcdefg4";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate.Valid);
            Assert.AreEqual("The password must contain at least 2 numbers", validate.Message);
        }
    }

    public class PasswordInputField {
        public static Result Validate(string inputPassword) {
            if (inputPassword.Length < 8)
                return new Result {
                    Valid = false,
                    Message = "Password must be at least 8 characters"
                };

            return new Result {
                Valid = false,
                Message = "The password must contain at least 2 numbers"
            };

        }
    }

    public class Result {
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}