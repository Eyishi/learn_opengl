#version 330 core
out vec4 FragColor;

uniform vec3 lightCubeColor;//随着光照颜色改变光照物体的颜色
void main()
{
    FragColor = vec4(lightCubeColor,1.0f); 
}