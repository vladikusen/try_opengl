#version 330 core

out vec4 FragColor;

in vec3 FragPos;  
in vec3 Normal;  
  
uniform vec3 cameraPos;
uniform samplerCube skybox;

// vec3 CalcDirLight(DirLight light, vec3 normal, vec3 viewDir);
// vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir);
// vec3 CalcSpotLight(SpotLight light, vec3 normal, vec3 fragPos);

float near = 0.1;
float far = 100.0;

float LinearizeDepth(float depth) {
   float z = depth * 2.0 - 1.0;
   return (2.0 * near * far) / (far + near - z * (far - near));
}

void main()
{
   vec3 I = normalize(FragPos - cameraPos);
   vec3 R = reflect(I, normalize(Normal));
   FragColor = vec4(texture(skybox, R).rgb, 1.0);
    
} 

// vec3 CalcDirLight(DirLight light, vec3 normal, vec3 viewDir) {
//    vec3 lightDir = normalize(-light.direction);
//    float diff = max(dot(normal, lightDir), 0.0);
//    vec3 reflectDir = reflect(-lightDir, normal);
//    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

//    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));
//    vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoords));
//    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));

//    return (ambient + diffuse + specular);
// }

// vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir) {
//    vec3 lightDir = normalize(light.position - fragPos);
//    float diff = max(dot(normal, lightDir), 0.0);
//    vec3 reflectDir = reflect(-lightDir, normal);
//    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

//    float distance = length(light.position - fragPos);
//    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

//    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));
//    vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoords));
//    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));

//    ambient *= attenuation;
//    diffuse *= attenuation;
//    specular *= attenuation;


//    return (ambient + diffuse + specular);
// }

// vec3 CalcSpotLight(SpotLight light, vec3 normal, vec3 fragPos) {
//    vec3 lightDir = normalize(light.position - fragPos);

//    float theta = dot(lightDir, normalize(-light.direction));
//    float epsilon = light.cutOff - light.outCutOff;
//    float intensity = clamp((theta - light.outCutOff) / epsilon, 0.0, 1.0);

//    float distance = length(light.position - fragPos);
//    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

//    float diff = max(dot(normal, lightDir), 0.0);
//    vec3 reflectDir = reflect(-lightDir, normal);
//    float spec = pow(max(dot(light.direction, reflectDir), 0.0), material.shininess);

//    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));
//    vec3 diffuse =  light.diffuse * diff * vec3(texture(material.diffuse, TexCoords));
//    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));


//    diffuse *= intensity;
//    specular *= intensity;
//    return (ambient + diffuse + specular);
// }

