// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", (event) => {
    const textareaEl = document.getElementById("textareaEl")
    const charCount = document.getElementById("charCount")

    if (textareaEl && charCount) {
        textareaEl.addEventListener("input", () => {
            const newCount = 150 - textareaEl.value.length
            charCount.textContent = `${newCount}`
        })
    }
})