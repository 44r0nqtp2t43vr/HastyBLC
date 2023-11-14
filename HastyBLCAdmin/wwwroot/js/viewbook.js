var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".editReviewBtn").click(function () {
        var reviewId = $(this).data("review-id");
        var reviewName = $(this).data("review-name");
        var reviewRating = $(this).data("review-rating");
        var reviewUserEmail = $(this).data("review-user-email");
        var reviewDescription = $(this).data("review-description");

        $("#editReviewId").val(reviewId);
        $("#editReviewName").val(reviewName);
        $("#editReviewUserEmail").val(reviewUserEmail);
        $("input[name='Rating'][value='" + reviewRating + "']").prop("checked", true);
        $("#editReviewDescription").val(reviewDescription);

        jq("#editReviewModal").modal("show");
    });
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
