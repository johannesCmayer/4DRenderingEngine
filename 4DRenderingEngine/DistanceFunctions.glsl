//Single Objects

float udBox(vec3 point, vec3 position, vec3 size)
{
    return length(max(abs(point + position) - size, 0.0));
}

float dSphere (vec3 point, vec3 position, float r)
{
    return length(point - position) - r;
}

//Repeated

float repSphere( vec3 p, vec3 c )
{
    vec3 q = mod(p,c)-0.5*c;
    return dSphere( q , vec3(0.,0.,0.), 1.);
}

float repCube( vec3 p, vec3 c )
{
    vec3 q = mod(p,c)-0.5 * c;
    return udBox( q , vec3(0.,0.,0.), vec3(1., 1., 1.));
}

//Operations

float opDisplace( vec3 p )
{
    float d1 = repCube(p, vec3(20., 20., 20.));
    float d2 = (sin(2.*p.x)*sin(2.*p.y)*sin(2.*p.z)) * 2.;
    return d1+d2;
}