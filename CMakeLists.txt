cmake_minimum_required(VERSION 3.0.0)
project(trygl VERSION 0.1.0)

include(CTest)
enable_testing()



find_package(glfw3 3.3 REQUIRED)

add_executable(trygl main.cpp glad/src/glad.c shader.h shader.cpp stb/stb_image.cpp)
include_directories(glad/include)
include_directories(glm)
target_link_libraries(trygl glfw ${CMAKE_DL_LIBS})

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
