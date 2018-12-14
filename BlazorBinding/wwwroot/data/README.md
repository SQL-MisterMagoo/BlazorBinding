# BlazorBinding
Sample Blazor App demonstrating various data binding scenarios

## Simple Cascade
Demonstrates how CascadingValue is a one-way data transfer, which updates the subscriber but not the publisher.

## Cascade With Callback
Demonstrates how you can add a Callback Action to update the CascadingValue from subscriber to publisher.

## Simple Binding
Demonstrates the use of parameter binding, which is a one-way binding like the CascadingValue, but specific to the bound Component.

## Simple Binding With Callback
Demonstrates how you can add a Callback Action to update the parent values from the child.

## Value Binding
Demonstrates how the bind-Value syntax works in a one-way mode, like simple binding.
*This is considered to be a bug by many*

## Value Binding With Callback
Demonstrates how you can update the parent from a child component by invoking the _required_ ValueChanged Action.

## Value Binding With Callback + Refresh
Demonstrates how you can ensure the parent knows a child component has updated data, and trigger a refresh.

## The Problem With Clicks - "Propagation"
Demonstrates how events on standard html elements propagate in Blazor. This is very bad.

## Using CascadingValue To Share A Global Component - Dialog
Demonstrates how to use CascadingValue to share a component from MainLayout so that it is globally accessible.

### Summary

In all cases, some kind of callback action is required to notify the parent component of a change in the data.
This is, in my opinion OK - as it gives me control of the data and UI - however, some people consider the manual intervention required to be a bug.

I have not included any examples of using "State" to achieve two way binding, although that is also possible, it would also require some kind of callback notification.
