#version 330 core

in vec2 TexCoords;
in vec3 FragPos;

out vec4 FragColor;

uniform sampler2D woodenFloor;

#define LIGHTS 4

uniform vec3 ViewPos;
uniform vec3 pointLights[LIGHTS];

void main() {

    vec3 result = texture(woodenFloor, TexCoords).rgb * 0.1;
    for(int i = 0; i < LIGHTS; i++) {
        vec3 lightDir = normalize(pointLights[i] - FragPos);
        vec3 normal = vec3(0.0, 1.0, 0.0);
        float diffuse = max(dot(lightDir, normal), 0.0);
        vec3 reflectDir = reflect(-lightDir, normal);
        vec3 viewDir = normalize(ViewPos - FragPos);
        vec3 halfwayDir = normalize(viewDir + lightDir);
        float specular = pow(max(dot(normal, halfwayDir), 0.0), 32.0);
        // float specular = pow(max(dot(viewDir, reflectDir), 0.0), 32.0);
        float distance = length(pointLights[i] - FragPos);
        float attenuation = 1.0 / (distance * distance);
        result += (vec3(1.0) * specular * (texture(woodenFloor, TexCoords).rgb) * attenuation) + (vec3(0.7) * diffuse * (texture(woodenFloor, TexCoords).rgb) * attenuation);
        
    }
    result = pow(result, vec3(1.0 / 2.2));
    FragColor = vec4(result, 0.0);
}