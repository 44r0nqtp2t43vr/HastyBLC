var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".editRoleBtn").click(function () {
        var roleId = $(this).data("role-id");
        var roleName = $(this).data("role-name");

        $("#editRoleId").val(roleId);
        $("#editRoleName").val(roleName);

        jq("#editRoleModal").modal("show");
    });
    jq(".editUserBtn").click(function () {
        var userId = $(this).data("user-id");
        var userName = $(this).data("user-name");
        var userEmail = $(this).data("user-email");

        $("#editUserId").val(userId);
        $("#editUserName").val(userName);
        $("#editUserEmail").val(userEmail);
        $("#editUserPassword").val("noedit");
        $("#editUserConfirmPassword").val("noedit");

        jq("#editUserModal").modal("show");
    });
    jq(".addUserRoleBtn").click(function () {
        var userId = $(this).data("user-id");

        $("#addUserRoleUserId").val(userId);

        jq("#addUserRoleModal").modal("show");
    });
});
