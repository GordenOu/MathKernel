# MathKernel

|Windows|Ubuntu|
|:--:|:--:|
|[![Build Status](https://ouqihao.visualstudio.com/_apis/public/build/definitions/7aefdc78-6fcf-404e-bde3-b65de2ea15b7/4/badge)](https://ouqihao.visualstudio.com/MathKernel/_build)|[![Build Status](http://www.gordenou.net:8111/app/rest/builds/buildType:(id:MathKernel_Build)/statusIcon.svg)](http://www.gordenou.net:8111/viewType.html?buildTypeId=MathKernel_Build&guest=1)|

Makes the math routines in [Intel Math Kernel Library](https://software.intel.com/intel-mkl/) available in .NET:

## Linear Algebra
BLAS (Basic Linear Algebra Subprograms) routines with decent performance are essential to most .NET applications that involve numerical computation. Managed code performs quite well for some 1 dimensional operations but it won't be able to compete with heavily hand-optimized native libraries. Since [OpenBLAS](http://www.openblas.net/) stopped releasing the binaries, MKL could be the only reasonable solution for a long time.

## Vector Mathematical Functions
Single precision math functions are not yet available in the framework ([#1551](https://github.com/dotnet/corefx/issues/1151)), these vector operations can partially solve the problem.

## Statistics
We have Average, Min, Max and Aggregate methods in LINQ, and System.Random with a wrong implementation ([#5974](https://github.com/dotnet/coreclr/issues/5974)). If one needs high-quality statistic functions, a quick solution was to invoke std::mersenne_twister_engine in STL, now we may have a better option.

## FFT
If I understand it correctly, MKL now comes with a more friendly license than [FFTW](http://www.fftw.org/).

## DNN
Under investigation.

# Status
- [ ] BLAS
    - [x] Level 1
    - [ ] Level 2
    - [ ] Level 3
- [ ] Others

# Preparation
1. Build the solution.
2. Install the Visual Studio Extension produced by ./Source/MathKernel.Analyzers.Vsix, so that the compiler can detect inconsistent duplications: ![Analyzer](https://cloud.githubusercontent.com/assets/16680828/18606874/ba128910-7cee-11e6-8fea-37ac179ce888.png)
3. Install [Math Kernel Library](https://software.intel.com/intel-mkl/), or any software that redistributes MKL (e.g., [Anaconda](https://www.continuum.io/) and [Microsoft R Open](https://mran.microsoft.com/open/)). Depending on environment variable settings, one may need to copy the binaries (e.g., mkl_rt.dll) into ./Native/MKL/.

# Design
To avoid compromising performance and generality, the level of abstraction should be just enough for argument validation and object lifetime management. This means the intended usage pattern is like
```
GEMM(1, A, B, 0, C)
```
instead of 
```
C = A * B
```
or
```
A.Multiply(B, C)
```

This project ignores:
* x86
* Naming guidelines
