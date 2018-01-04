node('master')
{
    stage('import')
    {
        try{
            git url:'https://github.com/Jatubs/RevatureProject2.git'
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
    stage('build')
    {
        try{
            dir('MinionChat')
            {
                bat 'nuget restore'
                bat 'msbuild /t:clean,build MinionChat.csproj'
            }
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
    stage('analyze')
    {
        try{
            dir('MinionChat')
            {
                bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe begin /k:jsw204'
                bat 'msbuild /t:build MinionChat.csproj'
                bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe end'
            }
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
    stage('test')
    {
        try{
            
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
    stage('package')
    {
        try{
            
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
    stage('deploy')
    {
        try{
            
        } catch(error){
            //slackSendmessage:{env.BUILD_NUMBER} color:'Danger'
        }
    }
}