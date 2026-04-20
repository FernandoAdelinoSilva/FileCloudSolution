# FileCloudSolution
Cloud Storage System

Your task is to implement a simple cloud storage system that maps objects(files) to their metainformation.

Specifically, the storage should maintain files and information about them (name, size etc). Note that this system should be in-memory.

Level 1: The cloud storage system should support adding a new file and retrieving and deleting files.

Level 2: the cloud storage sys should support displaying the largest file

Level 3: the cloud storage system should support adding users with limited capacities and merging two users

level 4: the cloud storage system should support backing up and restoring users files

===========================================================================================

Features - C# Backend API
    - Endpoints with operations:
        - Get All Files
        - Get File By Name
        - Add File - Validation if file already exists and throw exception
    - Singleton Repository Files 
    - Unit Tests to validate operations
    - CICD - Build solution and run unit tests