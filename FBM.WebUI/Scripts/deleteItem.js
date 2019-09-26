ApproveModal.Confirm = function (el) {
    var url = $(el).attr("data-url");
    debugger;
    if (url != null) {
        HideApproveModal();
        GoUrl(url);
        return;
    }
    else {
        ApproveModal.CallBack();
        ApproveModal.CallBack = null;
        HideApproveModal();
    }
}
ApproveModal.Reject = function (el) {
    HideApproveModal();
}

function ApproveAndRedirect(url, msg) {

    var message = "Silmek istediğinize emin misiniz?";

    if (msg != undefined) {
        message = msg;
    }

    $("#ApproveModalTitle").text(message);
    $("#ApproveModalAnchor").attr("data-url", url);

    ShowApproveModal();
}

function ShowApproveModal() {
    $("#ApproveModal").modal('show');
}

function HideApproveModal() {
    $("#ApproveModal").modal('hide');
}
function GoUrl(url) {
    window.location.href = url;
}