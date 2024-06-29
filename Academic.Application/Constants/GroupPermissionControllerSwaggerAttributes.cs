namespace Academic.Application.Constants
{
    public class GroupPermissionControllerSwaggerAttributes
    {
        // Group operations
        public const string GetAllGroupsSummary = "Retrieve all groups.";
        public const string GetAllGroupsResponse200 = "Successfully retrieved all groups.";
        public const string GetAllGroupsResponse404 = "No groups found.";

        public const string GetGroupByIdSummary = "Retrieve a group by ID.";
        public const string GetGroupByIdResponse200 = "Successfully retrieved the group.";
        public const string GetGroupByIdResponse404 = "Group not found.";

        public const string AddGroupSummary = "Add a new group.";
        public const string AddGroupResponse201 = "Group added successfully.";
        public const string AddGroupResponse400 = "Invalid request.";

        public const string UpdateGroupSummary = "Update an existing group.";
        public const string UpdateGroupResponse204 = "Group updated successfully.";
        public const string UpdateGroupResponse400 = "Invalid request.";
        public const string UpdateGroupResponse404 = "Group not found.";

        public const string DeleteGroupSummary = "Delete a group.";
        public const string DeleteGroupResponse204 = "Group deleted successfully.";
        public const string DeleteGroupResponse404 = "Group not found.";

        // Permission operations
        public const string GetAllPermissionsSummary = "Retrieve all permissions.";
        public const string GetAllPermissionsResponse200 = "Successfully retrieved all permissions.";
        public const string GetAllPermissionsResponse404 = "No permissions found.";

        public const string GetPermissionByIdSummary = "Retrieve a permission by ID.";
        public const string GetPermissionByIdResponse200 = "Successfully retrieved the permission.";
        public const string GetPermissionByIdResponse404 = "Permission not found.";

        public const string AddPermissionSummary = "Add a new permission.";
        public const string AddPermissionResponse201 = "Permission added successfully.";
        public const string AddPermissionResponse400 = "Invalid request.";

        public const string UpdatePermissionSummary = "Update an existing permission.";
        public const string UpdatePermissionResponse204 = "Permission updated successfully.";
        public const string UpdatePermissionResponse400 = "Invalid request.";
        public const string UpdatePermissionResponse404 = "Permission not found.";

        public const string DeletePermissionSummary = "Delete a permission.";
        public const string DeletePermissionResponse204 = "Permission deleted successfully.";
        public const string DeletePermissionResponse404 = "Permission not found.";

        // GroupPermission operations
        public const string GetAllGroupPermissionsSummary = "Retrieve all group permissions.";
        public const string GetAllGroupPermissionsResponse200 = "Successfully retrieved all group permissions.";
        public const string GetAllGroupPermissionsResponse404 = "No group permissions found.";

        public const string GetGroupPermissionByIdSummary = "Retrieve a group permission by Group ID and Permission ID.";
        public const string GetGroupPermissionByIdResponse200 = "Successfully retrieved the group permission.";
        public const string GetGroupPermissionByIdResponse404 = "Group permission not found.";

        public const string AddGroupPermissionSummary = "Add a new group permission.";
        public const string AddGroupPermissionResponse201 = "Group permission added successfully.";
        public const string AddGroupPermissionResponse400 = "Invalid request.";

        public const string UpdateGroupPermissionSummary = "Update an existing group permission.";
        public const string UpdateGroupPermissionResponse204 = "Group permission updated successfully.";
        public const string UpdateGroupPermissionResponse400 = "Invalid request.";
        public const string UpdateGroupPermissionResponse404 = "Group permission not found.";

        public const string DeleteGroupPermissionSummary = "Delete a group permission.";
        public const string DeleteGroupPermissionResponse204 = "Group permission deleted successfully.";
        public const string DeleteGroupPermissionResponse404 = "Group permission not found.";
    }
}
