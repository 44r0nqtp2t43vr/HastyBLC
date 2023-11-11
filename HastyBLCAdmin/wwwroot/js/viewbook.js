var jq = jQuery.noConflict();
jq(document).ready(function () {
    /*jq(".editGenreBtn").click(function () {
        var genreId = $(this).data("genre-id");
        var genreName = $(this).data("genre-name");

        $("#editGenreId").val(genreId);
        $("#editGenreName").val(genreName);

        jq("#editGenreModal").modal("show");
    });*/
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
