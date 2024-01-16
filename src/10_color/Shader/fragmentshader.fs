#version 330 core
out vec4 FragColor;


//uniform sampler2D texture1;
//uniform sampler2D texture2;

uniform vec3 lightcolor ;
uniform vec3 objcolor ;

void main()
{
    //FragColor = mix(texture(texture1, TexCoord), texture(texture2, vec2(1.0f-TexCoord.x,TexCoord.y)), 0.2);
    FragColor = vec4(lightcolor * objcolor,1.0f);
}