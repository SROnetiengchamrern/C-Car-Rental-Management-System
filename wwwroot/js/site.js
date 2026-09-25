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
    function enhanceSelect(select) {
        if (!select || select.closest(".select-wrap") || select.multiple) {
            return;
        }

        const wrap = document.createElement("div");
        wrap.className = "select-wrap";
        select.parentNode.insertBefore(wrap, select);
        wrap.appendChild(select);

        const icon = document.createElement("i");
        icon.className = "bi bi-chevron-down select-wrap-icon";
        icon.setAttribute("aria-hidden", "true");
        wrap.appendChild(icon);
    }

    document
        .querySelectorAll("form select.form-control, form select.form-select, .auth-form select, .admin-content form select")
        .forEach(enhanceSelect);
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

(function () {
    const STORAGE_KEY = "bookingAlertLastId";
    const POLL_MS = 6000;
    const SHOW_MS = 5000;
    const alertsUrl = "/BookingRequests/Alerts";
    const host = document.getElementById("bookingAlertHost");
    const badge = document.getElementById("bookingRequestBadge");

    if (!host) {
        return;
    }

    const queue = [];
    let showing = false;
    let showingTimer = null;
    let lastId = Number(localStorage.getItem(STORAGE_KEY) || "0");

    function updateBadge(count) {
        if (!badge) return;
        if (count > 0) {
            badge.textContent = count > 99 ? "99+" : String(count);
            badge.classList.remove("d-none");
        } else {
            badge.classList.add("d-none");
        }
    }

    function enqueue(items) {
        if (!items || !items.length) return;
        items.forEach(function (item) {
            if (queue.some(function (q) { return q.bookingRequestId === item.bookingRequestId; })) return;
            queue.push(item);
        });
        pump();
    }

    function pump() {
        if (showing || queue.length === 0) return;
        showing = true;
        var item = queue.shift();
        showToast(item);
        if (item.bookingRequestId > lastId) {
            lastId = item.bookingRequestId;
            localStorage.setItem(STORAGE_KEY, String(lastId));
        }
        showingTimer = window.setTimeout(function () {
            hideToast();
            showing = false;
            showingTimer = null;
            pump();
        }, SHOW_MS);
    }

    function showToast(item) {
        var start = item.startDate ? new Date(item.startDate).toLocaleDateString() : "";
        var end = item.endDate ? new Date(item.endDate).toLocaleDateString() : "";
        host.innerHTML =
            '<div class="booking-alert-toast">' +
            '<div class="booking-alert-icon"><i class="bi bi-bell-fill"></i></div>' +
            '<div class="booking-alert-body">' +
            '<div class="booking-alert-title">New booking request</div>' +
            '<div class="booking-alert-name">' + escapeHtml(item.fullName) + '</div>' +
            '<div class="booking-alert-meta">' + escapeHtml(item.carName || "") + " · " + start + " – " + end + "</div>" +
            '<div class="booking-alert-ref">' + escapeHtml(item.reference || "") + "</div>" +
            "</div>" +
            '<a class="booking-alert-link" href="/BookingRequests/Details/' + item.bookingRequestId + '">View</a>' +
            '<button type="button" class="booking-alert-close" aria-label="Dismiss">&times;</button>' +
            '<div class="booking-alert-progress"></div>' +
            "</div>";

        var closeBtn = host.querySelector(".booking-alert-close");
        if (closeBtn) {
            closeBtn.addEventListener("click", function () {
                if (showingTimer) {
                    window.clearTimeout(showingTimer);
                    showingTimer = null;
                }
                hideToast();
                showing = false;
                pump();
            });
        }
    }

    function hideToast() {
        host.innerHTML = "";
    }

    function escapeHtml(value) {
        return String(value == null ? "" : value)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;");
    }

    async function poll() {
        try {
            var afterId = lastId > 0 ? lastId : 0;
            var res = await fetch(alertsUrl + "?afterId=" + afterId, {
                headers: { Accept: "application/json" },
                credentials: "same-origin"
            });
            if (!res.ok) return;
            var data = await res.json();
            updateBadge(data.newCount || 0);

            if (lastId <= 0) {
                lastId = data.maxId || 0;
                localStorage.setItem(STORAGE_KEY, String(lastId));
                return;
            }

            if (data.items && data.items.length) {
                enqueue(data.items);
            }
        } catch (e) {
            /* ignore */
        }
    }

    poll();
    window.setInterval(poll, POLL_MS);
})();
