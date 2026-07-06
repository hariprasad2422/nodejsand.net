pipeline {
    agent any

    tools {
        nodejs 'NodeJS'
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Backend') {
            steps {
                dir('backend/ImageUploader.Api') {
                    sh 'dotnet restore'
                    sh 'dotnet publish -c Release -o publish'
                }
            }
        }

        stage('Build Frontend') {
            steps {
                dir('frontend') {
                    sh 'npm install'
                    sh 'npm run build'
                }
            }
        }

        stage('Archive Backend Artifact') {
            steps {
                archiveArtifacts artifacts: 'backend/ImageUploader.Api/publish/**', fingerprint: true
            }
        }

        stage('Archive Frontend Artifact') {
            steps {
                archiveArtifacts artifacts: 'frontend/dist/**', fingerprint: true
            }
        }

    }

    post {
        success {
            echo 'Frontend and Backend artifacts created successfully.'
        }

        failure {
            echo 'Build failed.'
        }
    }
}
