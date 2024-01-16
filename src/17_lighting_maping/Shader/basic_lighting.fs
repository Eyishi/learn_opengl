#version 330 core
out vec4 FragColor;


//物体的材质
struct Material
{
    sampler2D diffuse;//漫反射贴图
    sampler2D specular;//镜面光贴图
    float shininess;//镜面高光的散射/半径。
};
//光对环境光，漫反射光，镜面反射
struct Light
{
    vec3 Postion;//光的位置

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
in vec3 Normal;  //法向量
in vec3 FragPos;  //片段的位置

in vec2 TexCoord;//漫反射纹理坐标
uniform vec3 viewPos;//观看位置

uniform Material material;
uniform Light light;
void main()
{
    // 环境光
   
    vec3 ambient = light.ambient*vec3(texture2D(material.diffuse,TexCoord));
    //漫反射
    vec3 norm = normalize(Normal);//法线
    vec3 lightDir = normalize(light.Postion - FragPos);//光照方向
    float diff = max(dot(norm, lightDir), 0.0);
   
    vec3 diffuse =  light.diffuse *diff*vec3(texture2D(material.diffuse,TexCoord));
    //镜面反射
    vec3 viewDir = normalize(viewPos - FragPos);//观察方向
    vec3 reflectDir = reflect(-lightDir, norm);//反射方向
    float spec = pow(max(dot(viewDir, reflectDir), 0.0),material.shininess);
    vec3 specular =  light.specular* spec*vec3(texture2D(material.specular,TexCoord));


    vec3 result = specular+ambient + diffuse;
    FragColor = vec4(result, 1.0);
} 