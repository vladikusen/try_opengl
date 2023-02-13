#version 330 core

out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

struct LightSource {
   vec3 position;
   vec3 direction;

   vec3 ambient;
   vec3 diffuse;
   vec3 specular;
};

uniform LightSource lightSource;
uniform vec3 viewPos; 
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

void main() {
   vec3 ambient = lightSource.ambient * texture(texture_diffuse1, TexCoords).rgb;

   vec3 lightDir = normalize(lightSource.position - FragPos);
   vec3 norm = normalize(Normal);
   float diff = max(dot(norm, lightDir), 0.0);
   vec3 diffuse = lightSource.diffuse * diff * texture(texture_diffuse1, TexCoords).rgb;
   vec3 viewDir = normalize(viewPos - FragPos);
   vec3 reflectDir = reflect(-lightDir, norm);
   float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32.0);

   vec3 specular = lightSource.specular * spec * texture(texture_specular1, TexCoords).rgb;

   FragColor = vec4(ambient + diffuse + specular, 1.0);
}