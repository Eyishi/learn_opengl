#version 330 core
out vec4 FragColor;

in vec3 Normal;  //法向量
in vec3 FragPos;  //片段的位置
  
uniform vec3 lightPos; //光的位置
uniform vec3 lightColor;//光的颜色
uniform vec3 objectColor;//物体的颜色
uniform vec3 viewPos;//镜面反射

void main()
{
    // 环境光
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    //漫反射
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;
    
    //镜面反射
    float specularStrength = 0.5;//反射强度
    vec3 viewDir = normalize(viewPos - FragPos);//观察方向
    vec3 reflectDir = reflect(-lightDir, norm);//反射方向
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor;


    vec3 result = (specular+ambient + diffuse) * objectColor;
    FragColor = vec4(result, 1.0);
} 