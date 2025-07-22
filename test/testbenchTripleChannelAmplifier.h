#ifndef TESTBENCHTRIPLECHANNELAMPLIFIER_H
#define TESTBENCHTRIPLECHANNELAMPLIFIER_H


#include "testbenchDualChannelAmplifier.h"

class TestbenchTripleChannelAmplifier : public TestbenchDualChannelAmplifier {
public:
    TestbenchTripleChannelAmplifier();
    virtual ~TestbenchTripleChannelAmplifier();

    // Переопределение метода источника питания
    virtual void PowerSupply() const override;
};

#endif // TESTBENCHDUALCHANNELAMPLIFIER_H
