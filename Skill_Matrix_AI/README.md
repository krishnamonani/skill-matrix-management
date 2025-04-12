

```markdown
# Skill Matrix AI - OCR PDF Processing with FastAPI

This project allows you to process PDF files using OCR (Optical Character Recognition), recommend skills based on user input, and answer questions from the processed PDFs via a FastAPI-powered API.

## Prerequisites

Before you can run the project locally, you need to have the following installed:

- Python 3.9+
- Tesseract OCR (for PDF OCR processing)
- Virtualenv (optional, but recommended)

### Install Python

Ensure you have Python 3.9 or higher installed. You can download it from the official Python website: https://www.python.org/downloads/

### Install Tesseract OCR

You need to install Tesseract OCR on your system. Follow the instructions based on your operating system:

- **Windows**: [Tesseract installation for Windows](https://github.com/UB-Mannheim/tesseract/wiki)
- **macOS**: Install via Homebrew:
  ```bash
  brew install tesseract
  ```
- **Linux**: Install via apt (for Debian-based systems):
  ```bash
  sudo apt-get install tesseract-ocr
  ```

You can verify the installation of Tesseract by running the following command:
```bash
tesseract --version
```

## Getting Started

### 1. Clone the Repository

First, clone the project repository to your local machine.

```bash
git clone https://github.com/your-username/skill-matrix-ai.git
cd skill-matrix-ai
```

### 2. Set up the Python Environment

To create a virtual environment and install dependencies:

#### Create a virtual environment:

```bash
python -m venv venv
```

#### Activate the virtual environment:

- On Windows:
    ```bash
    .\venv\Scripts\activate
    ```

- On macOS/Linux:
    ```bash
    source venv/bin/activate
    ```

#### Install dependencies:

```bash
pip install -r requirements.txt
```

### 3. Run the FastAPI Application

Once your virtual environment is set up and dependencies are installed, you can run the FastAPI application.

```bash
uvicorn src.api.main:app --reload
```

This will start the FastAPI server at `http://localhost:8000`.

## API Endpoints

- **Swagger UI**: You can interact with the API via Swagger UI at `http://localhost:8000/docs`.

- **PDF Upload Endpoint**: `/upload-pdf/` (POST) to upload and process a PDF.
- **Skill Recommendation Endpoint**: `/recommend-skill/` (POST) to get skill recommendations based on user input.
- **Ask Question Endpoint**: `/ask-question/` (POST) to ask questions based on the uploaded PDFs.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
```

This version includes just the setup steps and instructions on how to run the project locally. It avoids the API details and focuses on making the environment ready and running the FastAPI server. Let me know if you need any further adjustments!
