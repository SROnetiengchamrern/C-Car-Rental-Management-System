// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function () {
    const sidebar = document.getElementById("adminSidebar");
    const backdrop = document.getElementById("sidebarBackdrop");
    const openBtn = document.getElementById("sidebarToggle");
    const closeBtn = document.getElementById("sidebarClose");

    if (!sidebar) {
        return;
    }

    function openSidebar() {
        sidebar.classList.add("open");
        backdrop?.classList.add("show");
    }

    function closeSidebar() {
        sidebar.classList.remove("open");
        backdrop?.classList.remove("show");
    }

    openBtn?.addEventListener("click", openSidebar);
    closeBtn?.addEventListener("click", closeSidebar);
    backdrop?.addEventListener("click", closeSidebar);
})();
