using AspectInjector.Broker;
using System;
using System.Reflection;
using Aquality.Selenium.Core.Logging;
using Humanizer;
using Allure.Net.Commons;
using Allure.Net.Commons.Steps;

namespace Aquality.Selenium.Template.CustomAttributes
{
    [Aspect(Scope.Global)]
    public class TraceAspect
    {
        private static Logger Logger => Logger.Instance;

        [Advice(Kind.Around, Targets = Target.Method)]
        public object LogMethodEntry(
            [Argument(Source.Metadata)] MethodBase methodBase,
            [Argument(Source.Type)] Type classType,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Name)] string name,
            [Argument(Source.Target)] Func<object[], object> method)
        {
            var options = methodBase.GetCustomAttribute<LogStepAttribute>();
            var logLevel = options?.StepType ?? StepType.Step;
            var stepName = name.Humanize();
            if (arguments.Length > 0)
            {
                stepName =  $"{stepName} with parameters: {string.Join("-", arguments)}";
            }
            
            LogStep(stepName, classType.Name, logLevel.ToString());

            //The logic is related to Allure.If you don't plan to use Allure, delete the following code:
            var stepResult = string.IsNullOrEmpty(stepName)
               ? new StepResult { name = name, parameters = AllureStepParameterHelper.CreateParameters(arguments) }
               : new StepResult { name = stepName, parameters = AllureStepParameterHelper.CreateParameters(arguments) };

            object result;
            try
            {
                AllureLifecycle.Instance.StartStep(stepResult);
                result = method(arguments);
                AllureLifecycle.Instance.StopStep(step => stepResult.status = Status.passed);
            }
            catch (Exception e)
            {
                AllureLifecycle.Instance.StopStep(step =>
                {
                    step.statusDetails = new StatusDetails
                    {
                        message = e.Message,
                        trace = e.StackTrace
                    };
                    step.status = Status.failed;
                });
                throw;
            }

            return result;
            //End of Allure Logic
        }

        private static void LogStep(string stepInfo, string stepMethod, string stepType)
        {
            var shift = new string('#', 10);
            Logger.Info($"{shift} {stepType} {shift} {Environment.NewLine}{stepMethod}: {stepInfo}");
        }
    }
}
