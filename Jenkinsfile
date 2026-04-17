
pipeline {
    agent any

    stages {

        stage('Build') {
            steps {
                echo "Building..."
            }
        }

        stage('Test') {
            steps {
                echo "Running tests..."
            }
        }

        stage('Deploy') {
            when {
                branch 'main'
            }
            steps {
                echo "Deploying to production..."
            }
        }
    }
}
