var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".addReviewBtn").click(function () {
        var bookId = $(this).data("book-id");

        $("#addReviewBookId").val(bookId);

        jq("#addReviewModal").modal("show");
    });
    jq(".addCommentBtn").click(function () {
        var reviewId = $(this).data("review-id");

        $("#addComReviewId").val(reviewId);

        jq("#addCommentModal").modal("show");
    });
});
