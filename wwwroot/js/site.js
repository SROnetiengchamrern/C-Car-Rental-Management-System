// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function () {
    const sidebar = document.getElementById("adminSidebar");
    const backdrop = document.getElementById("sidebarBackdrop");
    const openBtn = document.getElementById("sidebarToggle");
    const closeBtn = document.getElementById("sidebarClose");

    function openSidebar() {
        sidebar?.classList.add("open");
        backdrop?.classList.add("show");
    }

    function closeSidebar() {
        sidebar?.classList.remove("open");
        backdrop?.classList.remove("show");
    }

    openBtn?.addEventListener("click", openSidebar);
    closeBtn?.addEventListener("click", closeSidebar);
    backdrop?.addEventListener("click", closeSidebar);
})();

(function () {
    if (typeof window.jQuery === "undefined" || typeof window.jQuery.fn.DataTable === "undefined") {
        return;
    }

    const $ = window.jQuery;

    $(".datatable").each(function () {
        const $table = $(this);

        if ($.fn.DataTable.isDataTable($table)) {
            return;
        }

        const columnCount = $table.find("thead th").length;
        const actionColumnIndex = columnCount - 1;
        const firstHeader = ($table.find("thead th").first().text() || "").trim().toLowerCase();
        const nonOrderable = [actionColumnIndex];
        if (firstHeader === "image") {
            nonOrderable.unshift(0);
        }

        $table.DataTable({
            pageLength: 10,
            lengthMenu: [5, 10, 25, 50, 100],
            ordering: true,
            searching: true,
            info: true,
            autoWidth: false,
            responsive: false,
            language: {
                search: "Search:",
                lengthMenu: "Show _MENU_ entries",
                info: "Showing _START_ to _END_ of _TOTAL_",
                infoEmpty: "No records available",
                zeroRecords: "No matching records found",
                paginate: {
                    previous: "Prev",
                    next: "Next"
                }
            },
            columnDefs: [
                {
                    targets: nonOrderable,
                    orderable: false,
                    searchable: false
                }
            ],
            order: []
        });
    });
})();
