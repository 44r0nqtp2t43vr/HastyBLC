var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".addCommentBtn").click(function () {
        var reviewId = $(this).data("review-id");
        var bookId = $(this).data("book-id");

        $("#addComReviewId").val(reviewId);
        $("#addComBookId").val(bookId);

        jq("#addCommentModal").modal("show");
    });
});
