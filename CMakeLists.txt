cmake_minimum_required(VERSION 3.0.0)
project(trygl VERSION 0.1.0)

include(CTest)
enable_testing()



find_package(glfw3 3.3 REQUIRED)

add_executable(trygl 
    main.cpp 
    glad/src/glad.c 
    shader.h 
    shader.cpp 
    camera.h 
    camera.cpp 
    stb/stb_image.cpp 
    glm/gtc/matrix_transform.hpp 
    glm/gtc/type_ptr.hpp 
    glm/glm.hpp
    mesh.h
    mesh.cpp
    model.h
    model.cpp
)

include_directories(glad/include)
include_directories(glm)
include_directories(assimp/include)
target_link_libraries(trygl 
    glfw
    ${ASSIMP_LIBRARIES}
    "/home/user/Documents/opengl/assimp/bin/libassimp.so.5.2.5" 
    ${CMAKE_DL_LIBS})

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
