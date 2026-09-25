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

(function () {
    var OPEN_KEY = "adminCalcOpen";
    var STATE_KEY = "adminCalcState";
    var fab = document.getElementById("calcFab");
    var popup = document.getElementById("calcPopup");
    var closeBtn = document.getElementById("calcClose");
    var displayEl = document.getElementById("calcDisplay");
    var expressionEl = document.getElementById("calcExpression");
    var keys = document.getElementById("calcKeys");

    if (!fab || !popup || !displayEl || !keys) {
        return;
    }

    var state = {
        display: "0",
        expression: "",
        previous: null,
        operator: null,
        waitingForOperand: false
    };

    function loadState() {
        try {
            var raw = localStorage.getItem(STATE_KEY);
            if (!raw) return;
            var saved = JSON.parse(raw);
            if (saved && typeof saved === "object") {
                state.display = saved.display || "0";
                state.expression = saved.expression || "";
                state.previous = typeof saved.previous === "number" ? saved.previous : null;
                state.operator = saved.operator || null;
                state.waitingForOperand = !!saved.waitingForOperand;
            }
        } catch (e) {
            /* ignore */
        }
    }

    function saveState() {
        localStorage.setItem(STATE_KEY, JSON.stringify(state));
    }

    function isOpen() {
        return localStorage.getItem(OPEN_KEY) === "1";
    }

    function setOpen(open) {
        localStorage.setItem(OPEN_KEY, open ? "1" : "0");
        popup.hidden = !open;
        fab.classList.toggle("is-hidden", open);
        popup.classList.toggle("is-open", open);
    }

    function render() {
        displayEl.textContent = state.display;
        expressionEl.textContent = state.expression;
    }

    function inputDigit(digit) {
        if (state.waitingForOperand) {
            state.display = digit === "." ? "0." : digit;
            state.waitingForOperand = false;
        } else if (digit === ".") {
            if (state.display.indexOf(".") === -1) {
                state.display += ".";
            }
        } else if (state.display === "0") {
            state.display = digit;
        } else {
            if (state.display.replace(".", "").length >= 12) return;
            state.display += digit;
        }
        saveState();
        render();
    }

    function formatNumber(value) {
        if (!isFinite(value)) return "Error";
        var text = String(Number(value.toPrecision(12)));
        if (text.length > 14) {
            text = Number(value).toExponential(6);
        }
        return text;
    }

    function compute(a, op, b) {
        switch (op) {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            case "/": return b === 0 ? NaN : a / b;
            case "%": return a % b;
            default: return b;
        }
    }

    function opSymbol(op) {
        return ({ "+": "+", "-": "−", "*": "×", "/": "÷", "%": "%" })[op] || op;
    }

    function setOperator(nextOp) {
        var input = parseFloat(state.display);
        if (state.operator && !state.waitingForOperand && state.previous !== null) {
            var result = compute(state.previous, state.operator, input);
            state.display = formatNumber(result);
            state.previous = isFinite(result) ? result : null;
        } else {
            state.previous = input;
        }
        state.operator = nextOp;
        state.waitingForOperand = true;
        state.expression = formatNumber(state.previous) + " " + opSymbol(nextOp);
        saveState();
        render();
    }

    function equals() {
        if (state.operator === null || state.previous === null) return;
        var input = parseFloat(state.display);
        var result = compute(state.previous, state.operator, input);
        state.expression =
            formatNumber(state.previous) + " " + opSymbol(state.operator) + " " + formatNumber(input) + " =";
        state.display = formatNumber(result);
        state.previous = null;
        state.operator = null;
        state.waitingForOperand = true;
        saveState();
        render();
    }

    function clearAll() {
        state.display = "0";
        state.expression = "";
        state.previous = null;
        state.operator = null;
        state.waitingForOperand = false;
        saveState();
        render();
    }

    function backspace() {
        if (state.waitingForOperand) return;
        if (state.display.length <= 1 || (state.display.length === 2 && state.display.startsWith("-"))) {
            state.display = "0";
        } else {
            state.display = state.display.slice(0, -1);
        }
        saveState();
        render();
    }

    keys.addEventListener("click", function (e) {
        var btn = e.target.closest("button");
        if (!btn) return;
        if (btn.dataset.num !== undefined) inputDigit(btn.dataset.num);
        else if (btn.dataset.op) setOperator(btn.dataset.op);
        else if (btn.dataset.action === "equals") equals();
        else if (btn.dataset.action === "clear") clearAll();
        else if (btn.dataset.action === "back") backspace();
    });

    fab.addEventListener("click", function () {
        setOpen(true);
    });

    closeBtn.addEventListener("click", function () {
        setOpen(false);
    });

    loadState();
    render();
    // Persist across page navigation: reopen if user had it open
    setOpen(isOpen());
})();
