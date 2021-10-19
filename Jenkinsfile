pipeline {
    agent any
    
    environment {
            EMAIL_INFORM = 'bartlomiej.sapala@ibcs.pl'
    }
    
    stages {
        stage('Restore packages'){
           steps{
               bat 'dotnet restore Kartoteka-BartłomiejSapala.sln'
            }
         }
        stage('Clean'){
           steps{
               bat 'dotnet clean Kartoteka-BartłomiejSapala.sln --configuration Release'
            }
         }
        
        stage('Build project'){
            steps{
                bat 'dotnet build Kartoteka-BartłomiejSapala.sln'
            }
        }



    }
    post {  
         failure {  
             mail bcc: '', body: "<br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "ERROR CI: Project name -> ${env.JOB_NAME}", to: "${EMAIL_INFORM}";  
         }  
 
     }  
}
