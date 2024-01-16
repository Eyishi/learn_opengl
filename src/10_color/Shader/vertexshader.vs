#version 330 core
layout (location = 0) in vec3 aPos;



//mvp变换
uniform mat4 model;//模型变换
uniform mat4 view;//视图变换
uniform mat4 projection;//投影变换
void main()
{
    gl_Position = projection*view*model*vec4(aPos, 1.0f);
   
 
}