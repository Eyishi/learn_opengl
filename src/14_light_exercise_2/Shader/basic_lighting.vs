#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out vec3 fragcolor;//输出的颜色

uniform vec3 lightPos; //光的位置
uniform vec3 lightColor;//光的颜色
uniform vec3 objectColor;//物体的颜色
uniform vec3 viewPos;//镜面反射,观察方向

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    vec3 Normal = mat3(transpose(inverse(model))) * aNormal;//把当变换物体的时候法线也随之改变  
    
    //环境光
    float ambientStrength =0.5f;//环境光强度
    vec3 ambient = ambientStrength * lightColor;

    //漫反射
    
    vec3 norm = normalize(Normal);
    vec3 lightDir =  normalize(lightPos- aPos);//光的方向
    float diff =max(normalize(dot(norm,lightDir)),0.0f);
    vec3 diffuse=diff*lightColor;

    //镜面反射
    float specularStrength = 0.5;//反射强度
    vec3 viewDir = normalize(viewPos-aPos);
     vec3 reflectDir = reflect(-lightDir, norm);//反射方向
     float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular =  specularStrength * spec * lightColor;

    
    fragcolor = (ambient+diffuse+specular)*objectColor;
    gl_Position = projection * view * model*vec4(aPos, 1.0);
}