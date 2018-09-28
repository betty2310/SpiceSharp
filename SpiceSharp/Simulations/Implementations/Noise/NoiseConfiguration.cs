﻿using SpiceSharp.Attributes;

namespace SpiceSharp.Simulations
{
    /// <summary>
    /// A configuration for a <see cref="Noise"/> analysis.
    /// </summary>
    public class NoiseConfiguration : ParameterSet
    {
        /// <summary>
        /// Gets or sets the noise output node identifier.
        /// </summary>
        /// <value>
        /// The output identifier.
        /// </value>
        [ParameterName("output"), ParameterInfo("Noise output summation node")]
        public Identifier Output { get; set; }

        /// <summary>
        /// Gets or sets the noise output reference node identifier.
        /// </summary>
        /// <value>
        /// The output reference node identifier.
        /// </value>
        [ParameterName("outputref"), ParameterInfo("Noise output reference node")]
        public Identifier OutputRef { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the AC source used as input reference.
        /// </summary>
        /// <value>
        /// The input source identifier.
        /// </value>
        [ParameterName("input"), ParameterInfo("Name of the AC source used as input reference")]
        public Identifier Input { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoiseConfiguration"/> class.
        /// </summary>
        public NoiseConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoiseConfiguration"/> class.
        /// </summary>
        /// <param name="output">The output node identifier.</param>
        /// <param name="reference">The reference node identifier.</param>
        /// <param name="input">The input source identifier.</param>
        public NoiseConfiguration(Identifier output, Identifier reference, Identifier input)
        {
            Output = output;
            OutputRef = reference;
            Input = input;
        }
    }
}