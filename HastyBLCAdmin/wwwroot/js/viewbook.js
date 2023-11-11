var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".editCommentBtn").click(function () {
        var commentId = $(this).data("comment-id");
        var commentName = $(this).data("comment-name");
        var commentUserEmail = $(this).data("comment-user-email");
        var commentDescription = $(this).data("comment-description");

        $("#editCommentId").val(commentId);
        $("#editCommentName").val(commentName);
        $("#editCommentUserEmail").val(commentUserEmail);
        $("#editCommentDescription").val(commentDescription);

        jq("#editCommentModal").modal("show");
    });
    jq(".deleteReviewBtn").click(function () {
        var reviewId = $(this).data("review-id");

        $("#deleteReviewId").val(reviewId);

        jq("#deleteReviewModal").modal("show");
    });
    jq(".deleteCommentBtn").click(function () {
        var commentId = $(this).data("comment-id");

        $("#deleteCommentId").val(commentId);

        jq("#deleteCommentModal").modal("show");
    });
});
