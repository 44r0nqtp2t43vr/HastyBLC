var jq = jQuery.noConflict();
jq(document).ready(function () {
    
    jq('.editReviewBtn').on('click', function () {
        var reviewId = jq(this).data('review-id');
        var name = jq(this).data('review-name');
        var email = jq(this).data('review-user-email');
        var rating = jq(this).data('review-rating');
        var description = jq(this).data('review-description');

        jq('#editReviewId').val(reviewId);
        jq('#editReviewName').val(name);
        jq('#editReviewUserEmail').val(email);
        jq('#editReviewDescription').val(description);

        // Debugging log
        console.log("Selected Rating: ", rating);

        // Check the radio button that matches the rating
        jq('#editReviewModal input[name="Rating"]').each(function () {
            if (parseInt(jq(this).val()) === rating) {
                jq(this).prop('checked', true);
            }
        });

        jq('#editReviewModal').modal('show');
    });

    // Debugging: Check change event on rating radio buttons
    jq('#editReviewModal input[name="Rating"]').change(function () {
        console.log("New Rating Selected: ", jq(this).val());
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
