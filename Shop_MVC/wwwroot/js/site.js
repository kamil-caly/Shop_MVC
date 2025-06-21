// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// For Toast Notification
document.addEventListener("DOMContentLoaded", function () {
    var toastEl = document.getElementById("customToast");
    if (toastEl) {
        var toast = new bootstrap.Toast(toastEl);
        toast.show();
    }
});

function showToast(res) {
    const toastContainer = document.getElementById('toastContainer');

    const toastId = 'toast-' + Date.now();

    const toastHtml = `
        <div id="${toastId}" class="toast text-white bg-${res.type} border-0 show" role="alert" aria-live="assertive" aria-atomic="true" data-bs-autohide="true" data-bs-delay="5000">
            <div class="d-flex">
                <div class="toast-body">${res.message}</div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>
        </div>
    `;

    toastContainer.insertAdjacentHTML('beforeend', toastHtml);

    const toastEl = document.getElementById(toastId);
    const bsToast = new bootstrap.Toast(toastEl);
    bsToast.show();

    // Automatyczne usunięcie po zamknięciu
    toastEl.addEventListener('hidden.bs.toast', () => {
        toastEl.remove();
    });
}

window.showToast = showToast;
