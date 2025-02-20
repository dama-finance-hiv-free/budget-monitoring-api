// @ts-nocheck
/**
 * Handle password toggle
 * */

document.addEventListener("DOMContentLoaded", () => {
    const passwordToggleBtn = document.querySelector("#password-toggle");

    if (passwordToggleBtn) {
        passwordToggleBtn.addEventListener("click", (e) => {
            const passwordInput = document.querySelector(".form__input_password");
            const passwordIcons = Array.from(
                document.querySelectorAll(".password_icon")
            );

            if (passwordToggleBtn.dataset.icon === "show") {
                // show password and change icon to hidden icon
                passwordInput.type = "text";
                passwordIcons.map((input) => {
                    if (input.dataset.name === "show") {
                        input.classList.add("hidden");
                    } else {
                        input.classList.remove("hidden");
                    }
                });

                passwordToggleBtn.dataset.icon = "hide";
            } else {
                // show password and change icon to hidden icon
                passwordInput.type = "password";
                passwordIcons.map((input) => {
                    if (input.dataset.name === "hide") {
                        input.classList.add("hidden");
                    } else {
                        input.classList.remove("hidden");
                    }
                });

                passwordToggleBtn.dataset.icon = "show";
            }
        });
    }
});
