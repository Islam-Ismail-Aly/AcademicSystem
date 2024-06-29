namespace Academic.Application.Constants
{
    public static class BranchControllerSwaggerAttributes
    {
        public const string GetAllBranchesSummary = "Retrieves all branches, including their supervisors.";
        public const string GetBranchByIdSummary = "Retrieves a single branch by ID, including its supervisor.";
        public const string GetBranchNamesSummary = "Retrieves the names of all branches.";
        public const string GetBranchNamesByIdSummary = "Retrieves the name of a specific branch by ID.";
        public const string AddBranchSummary = "Adds a new branch.";
        public const string UpdateBranchSummary = "Updates an existing branch.";
        public const string DeleteBranchSummary = "Deletes an existing branch.";

        public const string GetAllBranchesResponse200 = "A list of branches with detailed information.";
        public const string GetAllBranchesResponse404 = "If no branches are found.";

        public const string GetBranchByIdResponse200 = "If the branch is found.";
        public const string GetBranchByIdResponse404 = "If the branch is not found.";

        public const string GetBranchNamesResponse200 = "A list of branch names.";
        public const string GetBranchNamesResponse404 = "If no branches are found.";

        public const string GetBranchNamesByIdResponse200 = "If the branch name is found.";
        public const string GetBranchNamesByIdResponse404 = "If the branch name is not found.";

        public const string AddBranchResponse201 = "Branch added successfully.";
        public const string AddBranchResponse400 = "Invalid branch data.";

        public const string UpdateBranchResponse204 = "Branch updated successfully.";
        public const string UpdateBranchResponse400 = "Invalid branch data.";
        public const string UpdateBranchResponse404 = "If the branch is not found.";

        public const string DeleteBranchResponse204 = "Branch deleted successfully.";
        public const string DeleteBranchResponse404 = "If the branch is not found.";
    }
}
