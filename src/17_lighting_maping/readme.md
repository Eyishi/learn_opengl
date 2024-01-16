## 光照贴图

- #### **漫反射贴图**

​		就相当于是漫反射照在物体上的颜色

​	移除了环境光材质颜色向量，因为环境光颜色在几乎所有情况下都等于漫反射颜色，所以我们不需要将它们分开储存：

```c++
struct Material {
    sampler2D diffuse;
    vec3      specular;
    float     shininess;
}; 
...
in vec2 TexCoords;
```

![image-20240116151001504](C:\Users\19720\AppData\Roaming\Typora\typora-user-images\image-20240116151001504.png)

​	光打在物体上的区域，都展现出高光

- ### 镜面反射贴图

​		在物体上不同位置对镜面反射程度的不同，呈现出对高光的不同表现

```c++
struct Material {
    sampler2D diffuse;
    sampler2D specular;
    float     shininess;
}; 
...
in vec2 TexCoords;
```

添加镜面纹理之后

<img src="C:\Users\19720\AppData\Roaming\Typora\typora-user-images\image-20240116150757067.png" alt="image-20240116150757067" style="zoom: 80%;" />

只有边框的金属富有高光的感觉