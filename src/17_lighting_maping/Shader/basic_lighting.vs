#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoord;

out vec3 FragPos;//片段位置
out vec3 Normal;//法线
out vec2 TexCoord;//纹理坐标


uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    FragPos = vec3(model * vec4(aPos, 1.0));
    Normal = mat3(transpose(inverse(model))) * aNormal;//把当变换物体的时候法线也随之改变  
    TexCoord = aTexCoord;
    gl_Position = projection * view * vec4(FragPos, 1.0);
}