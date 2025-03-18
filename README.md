# skill-matrix-management

Please don't push anything to main branch, create different branch and save your work there.
Thank you.

# File/Folder Structure
![Screenshot 2025-03-18 102419](https://github.com/user-attachments/assets/b2917dd2-4dde-4eaa-afa2-7e3f9f908572)

# Branching Strategy
![Screenshot 2025-03-18 102440](https://github.com/user-attachments/assets/5a662c4b-8767-4228-bd20-bba28cc08971)

# Git Workflow

## **Branching Strategy**

- Always checkout the **`dev`** branch before starting work.
- Create a new branch for each feature from **`dev`** using the naming convention `feature/<feature-name>`.
- Work on the feature branch, commit changes, and push it to the remote repository.
- Once the feature is complete and tested, create a **Pull Request (PR)** to merge it into `dev`.

---

## **Steps to Follow**

### 1️⃣ **Switch to `dev` Branch**
```sh
# Ensure you are on the latest `dev` branch before creating a new feature branch
git checkout dev  # Switch to dev branch
git pull origin dev  # Get the latest changes from remote dev branch
```

### 2️⃣ **Create a New Feature Branch**
```sh
# Replace <feature-name> with the actual feature name
git checkout -b feature/<feature-name>
```

### 3️⃣ **Work on Your Feature**
```sh
# Make changes to the code, then stage and commit them
git add .  # Add all modified files
git commit -m "Add <feature-name> functionality"
```

### 4️⃣ **Push the Feature Branch to Remote**
```sh
git push origin feature/<feature-name>
```

### 5️⃣ **Create a Pull Request (PR)**
- Go to the GitHub/GitLab repository.
- Navigate to the **Pull Requests** section.
- Click **New Pull Request**.
- Set the **base branch** to `dev` and the **compare branch** to `feature/<feature-name>`.
- Add a description and reviewers, then click **Create Pull Request**.

### 6️⃣ **After the Feature is Merged**
```sh
# Switch back to dev and update your local repository
git checkout dev
git pull origin dev

# Delete the feature branch locally and remotely
git branch -d feature/<feature-name>
git push origin --delete feature/<feature-name>
```

---

## **Important Notes**
- Always create a **new branch from `dev`**, NOT from `main` or `staging`.
- Follow **proper commit messages** that describe changes clearly.
- Do **not push directly to `dev` or `main`**; always use Pull Requests.
- Keep your local `dev` branch updated before creating a new feature branch.

📌 **Happy Coding! 🚀**
